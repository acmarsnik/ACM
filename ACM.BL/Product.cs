using Acme.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACM.BL
{
    public class Product : EntityBase, ILoggable
    {
        //Attributes
        public static int InstanceCount { get; set; }
        public int ProductId { get; set; }
        private String _ProductName;

        public String ProductName
        {
            get
            {
                return _ProductName.InsertSpaces();
            }
            set { _ProductName = value; }
        }

        public string Description { get; set; }
        public decimal CurrentPrice { get; set; }

        //Constructors
        public Product() : this(InstanceCount + 1, "", "", 0)
        { }

        public Product(int productId) : this(productId, "", "", 0)
        { }
        public Product(int productId, string productName) : this(productId, productName, "", 0)
        { }
        public Product(int productId, string productName, string description) : this(productId, productName, description, 0)
        { }

        public Product(int productId, string productName, string description, decimal currentPrice)
        {
            ProductId = productId;
            ProductName = productName;
            Description = description;
            CurrentPrice = currentPrice;
            InstanceCount += 1;
        }

        //Methods
        public override string ToString()
        {
            return ProductName;
        }

        public override bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrWhiteSpace(ProductName)) isValid = false;
            //if (CurrentPrice == null) isValid = false;

            return isValid;
        }

        public string Log()
        {
            var logString = this.ProductId + ": " +
                this.ProductName + ": " +
                "Detail: " + this.Description + " " +
                "Status: " + this.EntityState.ToString();

            return logString;
        }

    }
}
