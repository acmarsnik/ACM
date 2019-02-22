using System;
using System.Collections.Generic;
using System.Text;

namespace ACM.BL
{
    public class CustomerRepository
    {
        public Customer Retrieve(int customerId)
        {
            var customer = new Customer(customerId);
            //TODO: Write Code that retrieves the defined customer;

            //return new Customer();

            //Temporary hard coded values to return a populated customer
            if (customerId == 1)
            {
                customer.EmailAddress = "fbaggins@hobbiton.me";
                customer.FirstName = "Frodo";
                customer.LastName = "Baggins";
            }

            return customer;
        }
        public List<Customer> Retrieve()
        {
            //TODO: Write Code that retrieves all customers;
            var customers = new List<Customer>();
            customers.Add(new Customer()
            {
                EmailAddress = "fbaggins@hobbiton.me",
                FirstName = "Frodo",
                LastName = "Baggins"
            });
            customers.Add(new Customer()
            {
                EmailAddress = "bbaggins@hobbiton.me",
                FirstName = "Bilbo",
                LastName = "Baggins"
            });
            customers.Add(new Customer()
            {
                EmailAddress = "rosiejones@example.com",
                FirstName = "Rosie",
                LastName = "Jones"
            });
            return new List<Customer>();
        }
        public bool Save()
        {
            //TODO: Write Code that saves the defined customer;
            return true;
        }
    }
}
