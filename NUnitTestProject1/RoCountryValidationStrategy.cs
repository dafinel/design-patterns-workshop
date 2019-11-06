using RA;

namespace Strategy
{
    public class RoCountryValidationStrategy : IValidationStrategy
    {
        public void Assert(ResponseContext response)
        {
            response.TestBody("Line 1", body => body.Line1[0] == "Fill Line 1 if Country is RO")
                .TestBody("City", body => body.City[0] == "Fill City if Country is RO")
                .AssertAll();
        }
    }
}