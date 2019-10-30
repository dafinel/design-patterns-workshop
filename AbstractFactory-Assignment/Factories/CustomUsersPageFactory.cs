using AbstractFactory.Pages;
using OpenQA.Selenium;

namespace AbstractFactory.Factories
{
    public class CustomUsersPageFactory : IUsersPageFactory
    {
        private readonly IWebDriver _webDriver;

        public CustomUsersPageFactory(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public UsersPage CreateMobilePage() => new MobileCustomUsersPage(_webDriver);

        public UsersPage CreateDesktopPage() => new CustomUsersPage(_webDriver);
    }
}