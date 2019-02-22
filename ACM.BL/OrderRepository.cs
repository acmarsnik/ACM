using System;
using System.Collections.Generic;
using System.Text;

namespace ACM.BL
{
    public class OrderRepository
    {
        public Order Retrieve(int orderId)
        {
            //TODO: Write Code that retrieves the defined order;
            return new Order();
        }
        public List<Order> Retrieve()
        {
            //TODO: Write Code that retrieves all orders;
            return new List<Order>();
        }
        public bool Save()
        {
            //TODO: Write Code that saves the defined order;
            return true;
        }
    }
}
