using System;
using System.Collections.Generic;
using ACM.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BLTest
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        [TestMethod]
        public void RetrieveTest()
        {
            //TODO: Rewrite Code when retreive customer method is implemented
            //-- Arrange
            var customer = new Customer();
            var customerRepository = new CustomerRepository();
            var expected = new Customer(1)
            {
                EmailAddress = "fbaggins@hobbiton.me",
                FirstName = "Frodo",
                LastName = "Baggins"
            };

            //-- Act
            var actual = customerRepository.Retrieve(1);


            //-- Assert
            Assert.AreEqual(expected.Id + 1, actual.Id);
            Assert.AreEqual(expected.EmailAddress, actual.EmailAddress);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.FullName, actual.FullName);

        }

        [TestMethod]
        public void RetrieveAllTest()
        {
            //TODO: Rewrite Code when retreive all customers method is implemented
            //-- Arrange
            var customer = new Customer();
            var customerRepository = new CustomerRepository();
            var customers = new List<Customer>();


            //-- Act
            var actual = customerRepository.Retrieve().GetType();
            var expected = customers.GetType();

            //-- Assert
            Assert.AreEqual(expected, actual);

        }


        [TestMethod]
        public void SaveTest()
        {
            //TODO: Rewrite Code when save customer method is implemented
            //-- Arrange
            var customer = new Customer();
            var customerRepository = new CustomerRepository();

            //-- Act
            var actual = customerRepository.Save();
            var expected = true;

            //-- Assert
            Assert.AreEqual(expected, actual);

        }
    }
}
