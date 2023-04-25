using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryMethod;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FactoryMethod_Assignment.Pages
{
    public class StandardUsersPage : UsersPage
    {
        public StandardUsersPage(IWebDriver webDriver): base(webDriver)
        {
            
        }
        public override void Load()
        {
            IWebElement table = null;
            var wait = new WebDriverWait(_webDriver, System.TimeSpan.FromSeconds(15));
            wait.Until(driver => table = driver.FindElement(By.TagName("tbody")));

            var rows = table.FindElements(By.TagName("tr"));

            foreach (var row in rows)
            {
                var columns = row.FindElements(By.TagName("td"));
                var user = new UserInfo
                {
                    First = columns[0].Text,
                    Last = columns[1].Text,
                    Email = columns[2].Text,
                    Phone = columns[3].Text,
                    Street = columns[4].Text,
                    HouseNumber = columns[5].Text,
                    City = columns[6].Text,
                    State = columns[7].Text,
                    Country = columns[8].Text
                };

                _users.Add(user);
            }
        }

        public override bool IsFirstUser(UserInfo user)
        {
            var firstUser = _users.FirstOrDefault();
            if (firstUser == null)
            {
                return false;
            }
            return firstUser.First == user.First && firstUser.Last == user.Last;
        }
    }
}
