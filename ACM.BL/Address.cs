using System;
using System.Collections.Generic;
using System.Text;

namespace ACM.BL
{
    public class Address
    {
        //Attributes
        public static int InstanceCount { get; set; }
        public int Id { get; set; }
        public int Type { get; set; }
        public string StreetLine1 { get; set; }
        public string StreetLine2 { get; set; }
        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        //Constructors
        public Address() :
            this(InstanceCount + 1, 0, "", "", "New York", "NY", "11111", "USA")
        { }

        public Address(int id) :
            this(id, 0, "", "", "New York", "NY", "11111", "USA")
        { }

        public Address(int id, int type) :
            this(id, type, "", "", "New York", "NY", "11111", "USA")
        { }
        public Address(int id, int type, string streetLine1) :
            this(id, type, streetLine1, "", "New York", "NY", "11111", "USA")
        { }
        public Address(int id, int type, string streetLine1, string streetLine2) :
        this(id, type, streetLine1, streetLine2, "New York", "NY", "11111", "USA")
        { }

        public Address(int id, int type, string streetLine1, string streetLine2, string city) :
            this(id, type, streetLine1, streetLine2, city, "NY", "10025", "USA")
        { }

        public Address(int id, int type, string streetLine1, string streetLine2, string city, string stateOrProvince) :
                this(id, type, streetLine1, streetLine2, city, stateOrProvince, "11111", "USA")
        { }

        public Address(int id, int type, string streetLine1, string streetLine2, string city, string stateOrProvince, string postalCode) :
                    this(id, type, streetLine1, streetLine2, city, stateOrProvince, postalCode, "USA")
        { }

        public Address(int id, int type, string streetLine1, string streetLine2, string city, string stateOrProvince, string postalCode, string country)
        {
            Id = id;
            Type = type;
            StreetLine1 = streetLine1;
            StreetLine2 = streetLine2;
            City = city;
            StateOrProvince = stateOrProvince;
            PostalCode = postalCode;
            Country = country;
            InstanceCount += 1;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        //Methods
    }
}
