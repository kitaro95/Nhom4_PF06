using System;
using Persistion;
using DAL;

namespace BL
{
    public class CustomerBL
    {
        private CustomerDAL customerDAL;

        public CustomerBL()
        {
            customerDAL = new CustomerDAL();
        }
        public int VerifyLogin(string CustomerUsername, string CustomerPassword)
        {
            return customerDAL.VerifyLogin(CustomerUsername, CustomerPassword);
        }
        public Customer GetCustomer(string CustomerUsername)
        {
            return customerDAL.GetCustomer(CustomerUsername);
        }

        public int VerifyRegister(string Username, string Email)
        {
            return customerDAL.VerifyRegister(Username, Email);
        }
        public int Register(string Username, string Password, string Email, string Address, string Name, int Age, int Phonenumber, int CMT)
        {
            return customerDAL.Register(Username, Password, Email, Address, Name, Age, Phonenumber, CMT);
        }
    }

}