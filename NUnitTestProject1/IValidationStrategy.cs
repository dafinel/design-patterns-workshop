using RA;

namespace Strategy
{
    public interface IValidationStrategy
    {
        void Assert(ResponseContext response);
    }
}