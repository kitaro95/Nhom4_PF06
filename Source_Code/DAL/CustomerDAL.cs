using System;
using Persistion;
using MySql.Data.MySqlClient;
namespace DAL
{
    public class CustomerDAL
    {
        private string query;
        private MySqlDataReader reader;
        private MySqlConnection connection;
        public CustomerDAL()
        {
            connection = DatabaseAccess.OpenConnection();

        }
        public int VerifyLogin(string CustomerUsername, string CustomerPassword)
        {
            int b;
            query = @"Select * from Customer where Customer_Username = '" + CustomerUsername + "' and Customer_password ='" + CustomerPassword + "';";
            MySqlCommand command = new MySqlCommand(query, connection);
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                System.Console.WriteLine("Đăng nhập thành công");
                b = 1;;
        
            }
            else
            {
                System.Console.WriteLine("Sai tên đăng nhập hoặc mật khẩu");
                b = 0;
            }
            reader.Close();
            DatabaseAccess.CloseConnection();
            return b;

        }
        public Customer GetCustomer(string CustomerUsername)
        {
           
            DatabaseAccess.OpenConnection();
            query = @"Select * from Customer where Customer_Username = '" + CustomerUsername + "';";
            MySqlCommand command = new MySqlCommand(query, connection);
            reader = command.ExecuteReader();
            Customer customer = null;
            if (reader.Read())
            {
                customer = GetCustomerInfo(reader);
            }
            reader.Close();
            
            DatabaseAccess.CloseConnection();
            return customer;
            
            
        }
        private Customer GetCustomerInfo(MySqlDataReader reader)
        {
            Customer custom = new Customer();

            custom.CustomerEmail = reader.GetString("Customer_email");
            custom.CustomerUsername = reader.GetString("Customer_Username");
            custom.CustomerCMT = reader.GetInt32("Customer_CMT");
            custom.CustomerID = reader.GetInt32("Customer_id");
            custom.CustomerName = reader.GetString("Customer_Name");
            custom.CustomerAge = reader.GetInt32("Customer_Age");
            custom.CustomerPhonenumber = reader.GetInt32("Customer_Phone");
            custom.CustomerAddress = reader.GetString("Customer_address");
            custom.CustomerPassword = reader.GetString("Customer_password");
            return custom;

        }
        public int VerifyRegister(string Username, string Email)
        {
            int a;
            query = @"Select * from Customer where Customer_Username = '" + Username + "' or Customer_email ='" + Email + "';";
            MySqlCommand command = new MySqlCommand(query, connection);
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                System.Console.WriteLine("Tài khoản hoặc email đã tồn tại\n");
                a = 1;
            }
            else
            {
                System.Console.WriteLine("Bạn có thể sử dụng tài khoản và email này\n");
                a = 2;
            }
            reader.Close();
            DatabaseAccess.CloseConnection();
            return a;
        }
        public int Register(string Username, string Password, string Email,string Address,string Name,int Age,int Phonenumber,int CMT)
        {
            try
            {
                DatabaseAccess.OpenConnection();
                query = @"insert into Customer(Customer_Username,Customer_password,Customer_email,Customer_address,Customer_Name,Customer_Age,Customer_Phone,Customer_CMT)
                values ('" + Username + "','" + Password + "','" + Email + "','"+Address+"','"+Name+"',"+Age+","+Phonenumber+","+CMT+");";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
            catch { }
            finally
            {
                DatabaseAccess.CloseConnection();
            }
            return 10;
        }
    }


}