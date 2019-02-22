using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Customer : EntityBase, ILoggable
    {
        public Customer()
            : this(InstanceCount + 1)
        {
            InstanceCount += 1;
        }
        public Customer(int customerId)
        {
            CustomerId = customerId;
            InstanceCount += 1;
        }
        public Customer(string fullName)
            : this(InstanceCount + 1, fullName)
        {
        }

        public Customer(int customerId, string fullName)
        {
            CustomerId = customerId;
            SetFirstAndLastNameWithFullName(fullName);
            var emailSuffix = SetEmailSuffix();
            EmailAddress = FirstName.ToLower()[0] + LastName.ToLower() + emailSuffix;
            InstanceCount += 1;
        }
        public Customer(string fullName, string emailAddress)
        {
            CustomerId = InstanceCount + 1;
            var names = fullName.Split(' ');
            EmailAddress = emailAddress;
            InstanceCount += 1;
        }
        public Customer(int customerId, string fullName, string emailAddress)
        {
            CustomerId = customerId;
            var names = fullName.Split(' ');
            EmailAddress = emailAddress;
            InstanceCount += 1;
        }
        public Customer(string lastName, string firstName, string emailAddress)
        {
            CustomerId = InstanceCount + 1;
            LastName = lastName;
            FirstName = firstName;
            EmailAddress = emailAddress;
            InstanceCount += 1;
        }
        public Customer(int customerId, string lastName, string firstName, string emailAddress)
        {
            CustomerId = customerId;
            LastName = lastName;
            FirstName = firstName;
            EmailAddress = emailAddress;
            InstanceCount += 1;
        }
        public void SetFirstAndLastNameWithFullName(string fullName)
        {
            var names = fullName.Split(' ');
            var lastNamePosition = 1;
            var firstNamePosition = 0;
            if (names.Length < 2)
            {
                names = fullName.Split(',');
                lastNamePosition = 0;
                firstNamePosition = 1;
                var cnt = 0;
                foreach (string name in names)
                {
                    names[cnt] = Regex.Replace(name, @"\s+", "");
                    cnt++;
                }
            }
            LastName = names[lastNamePosition];
            FirstName = names[firstNamePosition];
        }

        public string SetEmailSuffix()
        {
            var emailSuffix = "@example.com";

            if (IsHobbit())
            {
                emailSuffix = "@hobbiton.me";
            }

            return emailSuffix;
        }
        public bool IsHobbit()
        {
            var isHobbit = false;
            var hobbitFirstNames = new List<string>() { "Frodo", "Bilbo" };
            var hobbitLastNames = new List<string>() { "Baggins" };

            if (hobbitFirstNames.Any(hobbitFirstName => hobbitFirstName == FirstName)
                || hobbitLastNames.Any(hobbitLastName => hobbitLastName == LastName))
            {
                isHobbit = true;
            }

            return isHobbit;
        }
        public static int InstanceCount { get; set; }
        //Use this (LastName) format if you need to customize something in getter or setter.
        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }
        public List<Address> Addresses { get; set; }
        // Create generic property with Intellisense (Ctrl K + Ctrl X), Visual C#, prop
        public string FirstName { get; set; }
        public string EmailAddress { get; set; }
        // Private setter with Intellisense (Ctrl K + Ctrl X), Visual C#, propg
        public int CustomerId { get; private set; }
        public string FullName
        {
            get
            {
                string fullName = LastName;
                if (!string.IsNullOrEmpty(FirstName))
                {
                    if (!string.IsNullOrEmpty(fullName))
                    {
                        fullName += ", ";
                    }
                    fullName += FirstName;
                }
                return fullName;
            }
        }
        public override bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrWhiteSpace(LastName)) isValid = false;
            if (string.IsNullOrWhiteSpace(EmailAddress)) isValid = false;

            return isValid;
        }

        public override string ToString()
        {
            return FullName;
        }

        public string Log()
        {
            var logString = this.CustomerId + ": " +
                this.FullName + ": " +
                "Email: " + this.EmailAddress + " " +
                "Status: " + this.EntityState.ToString();

            return logString;
        }
    }
}
