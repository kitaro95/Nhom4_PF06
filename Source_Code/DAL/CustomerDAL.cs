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
        public Customer VerifyCustomer(string CustomerUsername, string CustomerPassword)
        {
            query = @"Select * from Customer where Username = '"+ CustomerUsername+ "' and Password ='"+CustomerPassword+"';";
            MySqlCommand command = new MySqlCommand(query,connection);
            reader = command.ExecuteReader();
            Customer customer = null;
            if (reader.Read())
            {
                System.Console.WriteLine("dang nhap thanh cong");
                customer = GetCustomerInfo(reader);
                
            }
            else
            {
              System.Console.WriteLine("Sai ten dang nhap hoac mat khau");
            }
            reader.Close();
            DatabaseAccess.CloseConnection();
            return customer;

        }
        private Customer GetCustomerInfo(MySqlDataReader reader)
        {
            Customer cust = new Customer();
            if (!reader.IsDBNull(1) )
            {
                System.Console.WriteLine("abcd");
            cust.CustomerEmail = reader.GetString("Email");

            }
            cust.CustomerEmail = "";
            cust.CustomerUsername = reader.GetString("Username");
            cust.CustomerGender = reader.GetString("Gender");
            cust.CustomerID = reader.GetInt32("CustomerID");
            cust.CustomerName = reader.GetString("Name");
            cust.CustomerBirthday = reader.GetDateTime("Birthday");
            cust.CustomerPhonenumber = reader.GetString("Phonenumber");
            cust.CustomerAddress = reader.GetString("Address");
            cust.CustomerPassword = reader.GetString("Password");
            return cust;
        }
        public int VerifyRegister(string Username,string Email)
        {
            int a;
            query = @"Select * from Customer where Username = '"+ Username+ "' or Email ='"+Email+"';";
            MySqlCommand command = new MySqlCommand(query,connection);
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                System.Console.WriteLine("tai khoan hoac email da ton tai");
                a = 1;
            }
            else
            {
              System.Console.WriteLine("dang ky thanh cong");
              a = 2;
            }
            reader.Close();
            DatabaseAccess.CloseConnection();
            return a;
        }
        public int Register(string Username, string Password, string Email)
        {
            try
            {
                DatabaseAccess.OpenConnection();
            query =@"insert into Customer(Username,Password,Email) values ('"+Username+"','"+Password+"','"+Email+"');";
            MySqlCommand command = new MySqlCommand(query,connection);
            command.ExecuteNonQuery();
            }
            catch{}
            finally
            {
            DatabaseAccess.CloseConnection();
            }
            return 100;
        }
    }

   
}