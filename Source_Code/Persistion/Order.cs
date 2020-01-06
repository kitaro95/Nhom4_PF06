using System;
using System.Collections.Generic;

namespace Persistion
{
    public class Order
    {
        public int OrderID {get;set;}
        
        public Customer OrderCustomer {get;set;}

        public DateTime OrderDate {get;set;}

        public Mobile OrderMobile {get;set;}

        public List<Mobile> ListMobiles;
        public int Amount {get;set;}
    }
}    