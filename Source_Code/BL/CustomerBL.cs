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
        public Customer VerifyCustomer(string CustomerUsername, string CustomerPassword)
        {
            return customerDAL.VerifyCustomer(CustomerUsername,CustomerPassword);
        }
        public int VerifyRegister(string Username, string Email)
        {
            return customerDAL.VerifyRegister(Username,Email);
        }
        public int Register(string Username, string Password, string Email)
        {
           return customerDAL.Register(Username,Password,Email);
        }
    }

}