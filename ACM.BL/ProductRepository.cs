using System;
using System.Collections.Generic;
using System.Text;

namespace ACM.BL
{
    public class ProductRepository
    {
        public Product Retrieve(int productId)
        {
            //TODO: Write Code that retrieves the defined product;
            Product product = new Product(productId);
            object myObject = new object();

            Console.WriteLine("Object: " + myObject.ToString());
            Console.WriteLine("Product: " + product.ToString());

            if (productId == 2)
            {
                product.ProductName = "Sunflowers";
                product.Description = "Sunflower Description";
                product.CurrentPrice = 15.96M;
            }

            return new Product();
        }
        public List<Product> Retrieve()
        {
            //TODO: Write Code that retrieves all products;
            return new List<Product>();
        }
        public bool Save()
        {
            //TODO: Write Code that saves the defined product;
            return true;
        }
    }
}
