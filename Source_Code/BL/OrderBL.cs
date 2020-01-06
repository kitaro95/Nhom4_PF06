using System;
using Persistion;
using DAL;
using System.Collections.Generic;

namespace BL
{
    public class orderBL
    {
        private OrderDAL orderDAL;

        public orderBL()
        {
           orderDAL = new OrderDAL();
        }
        public bool CreatOrder(Order order)
        {
           return orderDAL.CreatOrder(order);
        }
        public List<Order> OrderHistory(int CustomerID)
        {
            return orderDAL.OrderHistory(CustomerID);
        }
    }
}