using System;
using System.Collections.Generic;
using System.Text;

namespace ACM.BL
{
    public class OrderItem
    {
        //Attributes
        public static int InstanceCount { get; set; }
        public int OrderItemId { get; set; }
        public Product Quantity { get; set; }
        public int PurchasePrice { get; set; }

        //Constructors
        public OrderItem() : this(InstanceCount + 1, new Product(), 0)
        { }

        public OrderItem(int orderItemId) : this(orderItemId, new Product(), 0)
        { }

        public OrderItem(int orderItemId, Product quantity) : this(orderItemId, quantity, 0)
        { }

        public OrderItem(int orderItemId, Product quantity, int purchasePrice)
        {
            OrderItemId = orderItemId;
            Quantity = quantity;
            PurchasePrice = purchasePrice;
            InstanceCount += 1;
        }
    }
}
