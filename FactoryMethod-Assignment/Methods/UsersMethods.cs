#region Using directives

using System.Configuration;
using FactoryMethod_Assignment.Pages;
using OpenQA.Selenium;

#endregion

namespace FactoryMethod_Assignment.Methods
{
    public abstract class UsersMethods
    {
        protected IWebDriver WebDriver { get; }
        protected UsersPage UsersPage;

        protected UsersMethods(IWebDriver webDriver)
        {
            WebDriver = webDriver;
           
            LoadPage();
        }

        private void LoadPage()
        {
            var url = ConfigurationManager.AppSettings["url"];
            WebDriver.Navigate().GoToUrl(url);
            UsersPage = CreateUsersPage();
            UsersPage.Load();
        }

        public abstract UsersPage CreateUsersPage();

        public bool VerifyIfTheOrderIsCorrect()
        {
            return UsersPage.IsFirstUser(new UserInfo
            {
                First = "Jacob",
                Last = "Thornton",
                PostalCode = "756y8GG"
            });
        }
    }
}