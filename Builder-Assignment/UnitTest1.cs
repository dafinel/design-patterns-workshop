using System;
using System.Collections.Generic;
using Builder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RA;

namespace Builder_Assignment
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Given_OrderAPI_When_ANewOrderWasAdded_Then_ShouldHaveOkResponse()
        {
            new RestAssured()
                .Given()
                .Name("Add new order")
                .Body(new Order
                {
                    UserInfo = new Userinfo
                    {
                        Email = "andrei.anton@centric.eu",
                        FirstName = "Andrei",
                        LastName = "Anton"
                    },
                    BillingAddress = new Address
                    {
                        City = "Iasi",
                        Country = "Romania",
                        PostalCode = "700032",
                        Line1 = "Str. Palat 3c",
                        Line2 = "UBC 4"
                    },
                    ShippingAddress = new Address
                    {
                        City = "Iasi",
                        Country = "Romania",
                        PostalCode = "700032",
                        Line1 = "Str. Palat 3c",
                        Line2 = "UBC 4"
                    },
                    MonthYear = "03/2019",
                    OrderId = 78676,
                    OrderTime = DateTime.Now,
                    Payment = new Payment
                    {
                        Ammount = 144.87f,
                        Currency = "RON",
                        Type = "Card"
                    },
                    Products = new List<Product>
                    {
                        new Product
                        {
                            Name = "Pizza Capriciosa",
                            Quantity = 1
                        },
                        new Product
                        {
                            Name = "Pizza Full Meat",
                            Quantity = 2
                        },
                        new Product
                        {
                            Name = "Meniu Crispy",
                            Quantity = 1
                        }
                    }
                })
                .When()
                .Post("https://test1-workshop.azurewebsites.net/api/test/")
                .Then()
                .TestStatus("Test Status", x => x == 200);
        }
    }
}
