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
        //Attributes
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
        public int Id { get; private set; }
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

        //Constructors
        public Customer() :
            this(InstanceCount + 1, "Baggins", "Frodo", "Frodo.Baggins@hobbiton.me", new List<Address>())
        { }
        public Customer(int customerId) :
            this(customerId, "Baggins", "Frodo", "Frodo.Baggins@hobbiton.me", new List<Address>())
        { }
        public Customer(string fullName) :
            this(InstanceCount + 1, GetLastNameFromFullName(fullName), GetFirstNameFromFullName(fullName), GetEmailAddressFromFullName(fullName), new List<Address>())
        { }

        public Customer(int customerId, string fullName) :
            this(customerId, GetLastNameFromFullName(fullName), GetFirstNameFromFullName(fullName), GetEmailAddressFromFullName(fullName), new List<Address>())
        { }
        public Customer(string fullName, string emailAddress) :
            this(InstanceCount + 1, GetLastNameFromFullName(fullName), GetFirstNameFromFullName(fullName), emailAddress, new List<Address>())
        { }
        public Customer(int customerId, string fullName, string emailAddress) :
            this(customerId, GetLastNameFromFullName(fullName), GetFirstNameFromFullName(fullName), emailAddress, new List<Address>())
        { }
        public Customer(string lastName, string firstName, string emailAddress) :
            this(InstanceCount + 1, lastName, firstName, emailAddress, new List<Address>())
        { }
        public Customer(int customerId, string lastName, string firstName, string emailAddress) :
            this(customerId, lastName, firstName, emailAddress, new List<Address>())
        { }

        public Customer(int customerId, string lastName, string firstName, string emailAddress, List<Address> addresses)
        {
            SetCustomerId(customerId);
            LastName = lastName;
            FirstName = firstName;
            EmailAddress = emailAddress;
            Addresses = addresses;
            InstanceCount += 1;
        }

        //Methods
        public void SetCustomerId(int customerId)
        {
            if (customerId > InstanceCount)
            {
                Id = customerId;
            }
            else
            {
                Id = InstanceCount + 1;
            }
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

        public static string GetLastNameFromFullName(string fullName)
        {
            var lastName = fullName;
            var names = fullName.Split(' ');
            var lastNamePosition = 1;
            if (names.Length < 2)
            {
                names = fullName.Split(',');
                lastNamePosition = 0;
                var cnt = 0;
                foreach (string name in names)
                {
                    names[cnt] = Regex.Replace(name, @"\s+", "");
                    cnt++;
                }
            }
            lastName = names[lastNamePosition];

            return lastName;
        }

        public static string GetFirstNameFromFullName(string fullName)
        {
            var firstName = fullName;
            var names = fullName.Split(' ');
            var firstNamePosition = 0;
            if (names.Length < 2)
            {
                names = fullName.Split(',');
                firstNamePosition = 1;
                var cnt = 0;
                foreach (string name in names)
                {
                    names[cnt] = Regex.Replace(name, @"\s+", "");
                    cnt++;
                }
            }
            firstName = names[firstNamePosition];

            return firstName;
        }

        public static string GetEmailAddressFromFullName(string fullName)
        {
            var emailAddress = fullName;
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
            var firstName = names[firstNamePosition];
            var lastName = names[lastNamePosition];

            emailAddress = firstName + "." + lastName + SetEmailSuffix(firstName, lastName);

            return emailAddress;
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

        public static string SetEmailSuffix(string firstName, string lastName)
        {
            var emailSuffix = "@example.com";

            if (IsHobbit(firstName, lastName))
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

        public static bool IsHobbit(string firstName, string lastName)
        {
            var isHobbit = false;
            var hobbitFirstNames = new List<string>() { "Frodo", "Bilbo" };
            var hobbitLastNames = new List<string>() { "Baggins" };

            if (hobbitFirstNames.Any(hobbitFirstName => hobbitFirstName == firstName)
                || hobbitLastNames.Any(hobbitLastName => hobbitLastName == lastName))
            {
                isHobbit = true;
            }

            return isHobbit;
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
            var logString = this.Id + ": " +
                this.FullName + ": " +
                "Email: " + this.EmailAddress + " " +
                "Status: " + this.EntityState.ToString();

            return logString;
        }
    }
}
