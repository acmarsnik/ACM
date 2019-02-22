using Acme.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACM.BL
{
    public class Product : EntityBase, ILoggable
    {
        public Product()
        {

        }

        public Product(int productId)
        {
            ProductId = productId;
        }

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
