using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FactoryMethod
{
    public abstract class UsersPage
    {
        protected readonly IWebDriver _webDriver;
        protected List<UserInfo> _users;

        public UsersPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _users =  new List<UserInfo>();
        }

        public abstract void Load();

        public abstract bool IsFirstUser(UserInfo user);
    }
}