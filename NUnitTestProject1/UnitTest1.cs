using System.Collections.Generic;
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

        private readonly Dictionary<string, IValidationStrategy> AssertStrategies = new Dictionary<string, IValidationStrategy>
        {
            {"NL", new NlCountryValidationStrategy()},
            {"RO", new RoCountryValidationStrategy()},
            {"US", new UsCountryValidationStrategy()}
        };

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

            var strategy = AssertStrategies[Country];
            strategy.Assert(response);
        }
    }
}
