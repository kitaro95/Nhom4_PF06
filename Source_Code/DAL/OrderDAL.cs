using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Persistion;

namespace DAL
{
    public class OrderDAL
    {
        private string query;
        private MySqlDataReader reader;
        private MySqlConnection connection;
        public OrderDAL()
        {
            connection = DatabaseAccess.OpenConnection();
        }
        public bool CreatOrder(Order order)
        {
            bool result = false;
            if (order == null)
            {
                return result;
            }
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"Lock tables Orders write, Mobile write, Orderdetails write";
            command.ExecuteNonQuery();

            MySqlTransaction transaction = connection.BeginTransaction();
            command.Transaction = transaction;
            try
            {
                command.CommandText = "insert into Orders(Customer_order) values (@Customer_id)";
                command.Parameters.AddWithValue("@Customer_id", order.OrderCustomer.CustomerID);
                command.ExecuteNonQuery();

                query = $@"select Order_id from Orders where Customer_order = {order.OrderCustomer.CustomerID} order by Order_id desc limit 1;";
                MySqlCommand command1 = new MySqlCommand(query,connection);
                reader = command1.ExecuteReader();
                if (reader.Read())
                {
                    order.OrderID = reader.GetInt32("Order_id");
                }
                reader.Close();
                command.CommandText = "insert into OrderDetails(Order_id,Mobile_id,Amount,Order_date) values (@Order_id,@Mobile_id,@Amount,now())";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@Order_id",order.OrderID);
                command.Parameters.AddWithValue("@Mobile_id",order.OrderMobile.MobileID);
                command.Parameters.AddWithValue("@Amount",order.Amount);
                command.ExecuteNonQuery();
                command.CommandText = "update Mobile set Mobile_quantity = Mobile_quantity -@Amount where Mobile_id = '"+order.OrderMobile.MobileID+"';";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@Amount",order.Amount);
                command.ExecuteNonQuery();
                transaction.Commit();
                result = true;
            }
            catch (System.Exception e)
            {
               transaction.Rollback();
               System.Console.WriteLine(e);
               return result;
            }
            finally
            {
                command.CommandText = "unlock tables";
                command.ExecuteNonQuery();
                DatabaseAccess.CloseConnection();
            }
            return result; 
        }


        // private Mobile GetMobileInfo(MySqlDataReader reader)
        // {
        //     Mobile mobi = new Mobile();
        //     mobi.MobileID = reader.GetInt32("Mobile_id");
        //     mobi.MobileName = reader.GetString("Mobile_Name");
        //     mobi.MobilePrice = reader.GetDecimal("Mobile_price");
        //     return mobi;
        // }
        public List<Order> OrderHistory (int Customer_id)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            query = $@"select ord.Order_id as Order_id,cust.Customer_Username,cust.Customer_email,mb.Mobile_id,mb.Mobile_Name,mb.Mobile_Price,
            ordt.Order_date,ordt.Amount from Customer cust inner join Orders ord on ord.Customer_order = cust.Customer_id inner join Orderdetails ordt on ord.Order_id = ordt.Order_id
            inner join Mobile mb on ordt.Mobile_id = mb.Mobile_id where ord.Customer_order = {Customer_id};";
            MySqlCommand command = new MySqlCommand(query,connection);
            reader = command.ExecuteReader();
            List<Order> ListOrders = new List<Order>();
            if (reader == null)
            {
                System.Console.WriteLine("Bạn chưa từng đặt hàng\n");
            }
            else
            {
                while (reader.Read())
                {
                    ListOrders.Add(GetOrdered(reader));
                }
            }
            reader.Close();
            DatabaseAccess.CloseConnection();
            return ListOrders;
        }

        private Order GetOrdered(MySqlDataReader reader)
        {
            Order order = new Order();
            order.OrderMobile = new Mobile();
            order.OrderCustomer = new Customer();
            order.OrderID = reader.GetInt32("Order_id");
            order.OrderCustomer.CustomerUsername = reader.GetString("Customer_Username");
            order.OrderCustomer.CustomerEmail = reader.GetString("Customer_email");
            order.OrderMobile.MobileID = reader.GetInt32("Mobile_id");
            order.OrderMobile.MobileName = reader.GetString("Mobile_name");
            order.OrderMobile.MobilePrice = reader.GetDecimal("Mobile_Price");
            order.Amount = reader.GetInt32("Amount");
            order.OrderDate = reader.GetDateTime("Order_date");
            return order;
        }

    }
}