using FactoryMethod_Assignment.Pages;
using OpenQA.Selenium;

namespace FactoryMethod_Assignment.Methods
{
    public class CustomUsersMethods : UsersMethods
    {
        public CustomUsersMethods(IWebDriver webDriver) : base(webDriver)
        {
        }

        public override UsersPage CreateUsersPage() => new CustomUsersPage(WebDriver);
    }
}