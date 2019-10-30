using System.Collections.Generic;
using OpenQA.Selenium;

namespace AbstractFactory.Pages
{
    public abstract class UsersPage
    {
        protected readonly IWebDriver WebDriver;
        protected List<UserInfo> Users;

        protected UsersPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
            Users =  new List<UserInfo>();
        }

        public abstract void Load();
        public abstract bool IsFirstUser(UserInfo user);
    }
}