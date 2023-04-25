using FactoryMethod;
using FactoryMethod_Assignment.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod_Assignment.Methods
{
    internal class StandardUsersMethods: UsersMethods
    {
        public StandardUsersMethods(IWebDriver webDriver) : base(webDriver)
        {
        }

        public override UsersPage CreateUsersPage(IWebDriver webDriver)
        {
            return new StandardUsersPage(webDriver);
        }
    }
}
