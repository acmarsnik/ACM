using System;
using System.Collections.Generic;
using System.Text;

namespace ACM.BL
{
    public class OrderItem
    {
        
        public OrderItem()
        {

        }

        public OrderItem(int orderItemId)
        {
            OrderItemId = orderItemId;
        }

        public int OrderItemId { get; set; }
        public Product Quantity { get; set; }
        public int PurchasePrice { get; set; }
    }
}
