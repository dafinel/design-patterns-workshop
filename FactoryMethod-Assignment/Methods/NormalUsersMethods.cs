using FactoryMethod_Assignment.Pages;
using OpenQA.Selenium;

namespace FactoryMethod_Assignment.Methods
{
    public class NormalUsersMethods : UsersMethods
    {
        public NormalUsersMethods(IWebDriver webDriver) : base(webDriver)
        {
        }

        public override UsersPage CreateUsersPage() => new NormalUsersPage(WebDriver);
    }
}