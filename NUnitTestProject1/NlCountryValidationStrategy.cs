using RA;

namespace Strategy
{
    public class NlCountryValidationStrategy : IValidationStrategy
    {
        public void Assert(ResponseContext response)
        {
            response.TestBody("Line 1", body => body.Line1[0] == "Fill Line 1 if Country is NL")
                .TestBody("PostalCode", body => body.PostalCode[0] == "Postal Code is not in correct format if Country is NL")
                .AssertAll();
        }
    }
}