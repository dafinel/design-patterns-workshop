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
            var order = Order.Create()
                .WithMonthYear("03/2019")
                .WithOrderId(78676)
                .WithUserInfo(new Userinfo
                {
                    Email = "andrei.anton@centric.eu",
                    FirstName = "Andrei",
                    LastName = "Anton"
                })
                .WithBillingAddress(new Address
                {
                    City = "Iasi",
                    Country = "Romania",
                    PostalCode = "700032",
                    Line1 = "Str. Palat 3c",
                    Line2 = "UBC 4"
                })
                .WithShippingAddress(new Address
                {
                    City = "Iasi",
                    Country = "Romania",
                    PostalCode = "700032",
                    Line1 = "Str. Palat 3c",
                    Line2 = "UBC 4"
                })
                .WithPayment(new Payment
                {
                    Ammount = 144.87f,
                    Currency = "RON",
                    Type = "Card"
                })
                .WithProduct(new Product
                {
                    Name = "Pizza Capriciosa",
                    Quantity = 1
                })
                .WithProduct(new Product
                {
                    Name = "Pizza Full Meat",
                    Quantity = 2
                })
                .WithProduct(new Product
                {
                    Name = "Meniu Crispy",
                    Quantity = 1
                })
                .Build();

            new RestAssured()
                .Given()
                .Name("Add new order")
                .Body(order)
                .When()
                .Post("https://test1-workshop.azurewebsites.net/api/test/")
                .Then()
                .TestStatus("Test Status", x => x == 200);
        }
    }
}
