using AbstractFactory.Pages;
using OpenQA.Selenium;

namespace AbstractFactory.Factories
{
    public class NormalUsersPageFactory : IUsersPageFactory
    {
        private readonly IWebDriver _webDriver;

        public NormalUsersPageFactory(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public UsersPage CreateMobilePage() => new MobileNormalUsersPage(_webDriver);

        public UsersPage CreateDesktopPage() => new NormalUsersPage(_webDriver);
    }
}