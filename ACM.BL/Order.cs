using Acme.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACM.BL
{
    public class Order : EntityBase, ILoggable
    {
        //Attributes
        public static int InstanceCount { get; set; }
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public Address ShippingAddress { get; set; }

        //Constructors
        public Order() : this(InstanceCount + 1, new Customer(), new DateTime(), new Address())
        { }
        public Order(int orderId) : this(orderId, new Customer(), new DateTime(), new Address())
        { }
        public Order(int orderId, Customer customer) : this(orderId, customer, new DateTime(), new Address())
        { }
        public Order(int orderId, Customer customer, DateTime orderDate) : this(orderId, customer, orderDate, new Address())
        { }

        public Order(int orderId, Customer customer, DateTime orderDate, Address shippingAddress)
        {
            OrderId = orderId;
            Customer = customer;
            OrderDate = orderDate;
            ShippingAddress = shippingAddress;
            InstanceCount += 1;
        }

        //Methods
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
