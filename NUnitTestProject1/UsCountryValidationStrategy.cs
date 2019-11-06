using RA;

namespace Strategy
{
    public class UsCountryValidationStrategy : IValidationStrategy
    {
        public void Assert(ResponseContext response)
        {
            response.TestBody("City", body => body.City[0] == "Fill City if Country is US")
                .TestBody("PostalCode", body => body.PostalCode[0] == "Postal Code is not in correct format if Country is US")
                .AssertAll();
        }
    }
}