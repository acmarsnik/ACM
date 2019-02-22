using System;
using System.Collections.Generic;
using ACM.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BLTest
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void FullNameTestValid()
        {
            // Normally Structure the body of automated code tests with the following

            //-- Arrange - Preparations we need
            Customer customer = new Customer();
            customer.FirstName = "Bilbo";
            customer.LastName = "Baggins";

            string expected = "Baggins, Bilbo";

            //-- Act - Perform the operation that we're testing
            string actual = customer.FullName;

            //-- Assert - Verifies that the expected value matches the actual value
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void FullNameFirstNameEmpty()
        {
            //-- Arrange
            // use var instead of full type name when it is clear what type it is to improve readability and conciseness of code
            var customer = new Customer();
            customer.LastName = "Baggins";

            string expected = "Baggins";

            //-- Act
            string actual = customer.FullName;

            //-- Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void FullNameLastNameEmpty()
        {
            //-- Arrange
            var customer = new Customer();
            customer.FirstName = "Bilbo";

            string expected = "Bilbo";

            //-- Act
            string actual = customer.FullName;

            //-- Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void InstanceCountTest()
        {
            //-- Arrange
            var customerBilbo = new Customer();
            customerBilbo.FirstName = "Bilbo";

            var customerFrodo = new Customer();
            customerFrodo.FirstName = "Frodo";

            var customerRosie = new Customer();
            customerRosie.FirstName = "Rosie";

            var actual = Customer.InstanceCount;
            var expected = 1;

            //-- Act

            //-- Assert
            Assert.AreEqual(expected.GetTypeCode(), actual.GetTypeCode());

        }

        [TestMethod]
        public void ValidateTest()
        {
            //-- Arrange
            var customer = new Customer();
            customer.LastName = "Baggins";
            customer.EmailAddress = "fbaggins@hobbiton.me";

            //-- Act
            var actual = customer.Validate();
            var expected = true;

            //-- Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void ValidateMissingEmailTest()
        {
            //-- Arrange
            var customer = new Customer();
            customer.LastName = "Baggins";

            //-- Act
            var actual = customer.Validate();
            var expected = false;

            //-- Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void ValidateMissingLastNameTest()
        {
            //-- Arrange
            var customer = new Customer();
            customer.EmailAddress = "test@example.com";

            //-- Act
            var actual = customer.Validate();
            var expected = false;

            //-- Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void ValidateMissingEmailAndLastNameTest()
        {
            //-- Arrange
            var customer = new Customer();

            //-- Act
            var actual = customer.Validate();
            var expected = false;

            //-- Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void FullNameConstructorTest()
        {
            //-- Arrange
            var customer = new Customer("Bilbo Baggins");
            var expectedCustomerId = 1;
            var expectedFirstName = "Bilbo";
            var expectedLastName = "Baggins";
            var expectedEmailAddress = "bbaggins@hobbiton.me";

            //-- Act

            //-- Assert
            Assert.AreEqual(expectedCustomerId.GetTypeCode(), customer.CustomerId.GetTypeCode());
            Assert.AreEqual(expectedFirstName, customer.FirstName);
            Assert.AreEqual(expectedLastName, customer.LastName);
            Assert.AreEqual(expectedEmailAddress, customer.EmailAddress);

        }

        [TestMethod]
        public void CustomerIdAndFullNameConstructorTest()
        {
            //-- Arrange
            var customer = new Customer(999999, "Bilbo Baggins");
            var expectedCustomerId = 999999;
            var expectedFirstName = "Bilbo";
            var expectedLastName = "Baggins";
            var expectedEmailAddress = "bbaggins@hobbiton.me";

            //-- Act

            //-- Assert
            Assert.AreEqual(expectedCustomerId, customer.CustomerId);
            Assert.AreEqual(expectedFirstName, customer.FirstName);
            Assert.AreEqual(expectedLastName, customer.LastName);
            Assert.AreEqual(expectedEmailAddress, customer.EmailAddress);

        }
    }
}
