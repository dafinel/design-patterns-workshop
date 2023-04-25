using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryMethod;
using FactoryMethod_Assignment.Pages;
using OpenQA.Selenium;

namespace FactoryMethod_Assignment.Methods
{
    internal class WithPostCodeUsersMethods : UsersMethods
    {
        public WithPostCodeUsersMethods(IWebDriver webDriver): base(webDriver)
        {
        }

        public override UsersPage CreateUsersPage(IWebDriver webDriver)
        {
            return new WithPostCodeUsersPage(webDriver);
        }
    }
}
