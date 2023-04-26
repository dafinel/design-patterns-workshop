using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RA;
using Strategy;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow("NL")]
        [DataRow("RO")]
        [DataRow("US")]
        public void Given_AddressValidation_When_AddressIsIncorrect_Then_ShouldHaveValidationErrors(string country)
        {
            var response = new RestAssured()
                .Given()
                .Name("Address validation")
                .Header("Content-Type", "application/json")
                .Body(new Address
                {
                    Country = country,
                    PostalCode = "AAAA76"
                })
                .When()
                .Post("https://test1-workshop.azurewebsites.net/api/address")
                .Then()
                .TestStatus("Status", s => s == 400);

            if (country == "NL")
            {
                response.TestBody("Line 1", body => body.Line1[0] == "Fill Line 1 if Country is NL")
                    .TestBody("PostalCode", body => body.PostalCode[0] == "Postal Code is not in correct format if Country is NL")
                    .AssertAll();
            }

            if (country == "RO")
            {
                response.TestBody("Line 1", body => body.Line1[0] == "Fill Line 1 if Country is RO")
                    .TestBody("City", body => body.City[0] == "Fill City if Country is RO")
                    .AssertAll();
            }

            if (country == "US")
            {
                response.TestBody("City", body => body.City[0] == "Fill City if Country is US")
                    .TestBody("PostalCode", body => body.PostalCode[0] == "Postal Code is not in correct format if Country is US")
                    .AssertAll();
            }
        }
    }
}
