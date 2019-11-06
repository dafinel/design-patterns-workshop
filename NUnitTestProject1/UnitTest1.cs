using NUnit.Framework;
using RA;

namespace Strategy
{
    [TestFixture("NL")]
    [TestFixture("RO")]
    [TestFixture("US")]
    public class Tests
    {
        public string Country { get; }

        public Tests(string country)
        {
            Country = country;
        }

        [Test]
        public void Given_AddressValidation_When_AddressIsIncorrect_Then_ShouldHaveValidationErrors()
        {
            var response = new RestAssured()
                .Given()
                .Name("Address validation")
                .Header("Content-Type", "application/json")
                .Body(new Address
                {
                    Country = Country,
                    PostalCode = "AAAA76"
                })
                .When()
                .Post("https://test1-workshop.azurewebsites.net/api/address")
                .Then()
                .TestStatus("Status", s => s == 400);

            if (Country == "NL")
            {
                response.TestBody("Line 1", body => body.Line1[0] == "Fill Line 1 if Country is NL")
                    .TestBody("PostalCode", body => body.PostalCode[0] == "Postal Code is not in correct format if Country is NL")
                    .AssertAll();
            }

            if (Country == "RO")
            {
                response.TestBody("Line 1", body => body.Line1[0] == "Fill Line 1 if Country is RO")
                    .TestBody("City", body => body.City[0] == "Fill City if Country is RO")
                    .AssertAll();
            }

            if (Country == "US")
            {
                response.TestBody("City", body => body.City[0] == "Fill City if Country is US")
                    .TestBody("PostalCode", body => body.PostalCode[0] == "Postal Code is not in correct format if Country is US")
                    .AssertAll();
            }

        }
    }
}
