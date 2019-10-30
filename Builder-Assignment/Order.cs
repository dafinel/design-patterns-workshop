using System;
using System.Collections.Generic;

namespace Builder
{
    public class Order
    {
        public Userinfo UserInfo { get; set; }
        public Address ShippingAddress { get; set; }
        public Address BillingAddress { get; set; }
        public List<Product> Products { get; set; }
        public Payment Payment { get; set; }
        public DateTime OrderTime { get; set; }
        public int OrderId { get; set; }
        public string MonthYear { get; set; }
    }

    public class Userinfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

    public class Payment
    {
        public string Type { get; set; }
        public float Ammount { get; set; }
        public string Currency { get; set; }
    }

    public class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }

}