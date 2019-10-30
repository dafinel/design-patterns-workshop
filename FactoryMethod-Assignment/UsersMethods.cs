﻿using System.Configuration;
using System.Threading;
using OpenQA.Selenium;

namespace FactoryMethod
{
    public class UsersMethods
    {
        private readonly UsersPage _usersPage;

        public UsersMethods(IWebDriver webDriver)
        {
            var url = ConfigurationManager.AppSettings["url"];
            webDriver.Navigate().GoToUrl(url);
            _usersPage = new UsersPage(webDriver);
        }

        public void LoadPage()
        {
            _usersPage.Load();
        }

        public bool VerifyIfTheOrderIsCorrect()
        {
            return  _usersPage.IsFirstUser(new UserInfo
            {
                First = "Jacob",
                Last = "Thornton",
                PostalCode = "756y8GG"
            });
        }
    }
}