using Acme.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACM.BL
{
    public class Order: EntityBase, ILoggable
    {
        public Order()
        {

        }
        public Order(int orderId)
        {
            this.OrderId = orderId;
        }
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public Address ShippingAddress { get; set; }

        public string Log()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return OrderDate.ToShortDateString() + "(1)";
            // TODO: Replace (1) with a quantity for the order
        }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
