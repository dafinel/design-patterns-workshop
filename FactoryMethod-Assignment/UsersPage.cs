using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FactoryMethod
{
    public class UsersPage
    {
        private readonly IWebDriver _webDriver;
        private List<UserInfo> _users;

        public UsersPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _users =  new List<UserInfo>();
        }

        public void Load()
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
                    State = columns[4].Text,
                    HouseNumber = columns[5].Text,
                    City = columns[6].Text
                };

                var clientName = ConfigurationManager.AppSettings["clientName"];
                if (clientName == "test1")
                {
                    user.PostalCode = columns[7].Text;
                    user.State = columns[8].Text;
                    user.Country = columns[9].Text;
                }
                else
                {
                    user.State = columns[7].Text;
                    user.Country = columns[8].Text;
                }

                _users.Add(user);
            }
        }

        public bool IsFirstUser(UserInfo user)
        {
            var firstUser = _users.FirstOrDefault();
            if (firstUser == null)
            {
                return false;
            }

            var clientName = ConfigurationManager.AppSettings["clientName"];
            if (clientName == "test1")
            {
                return firstUser.First == user.First && firstUser.Last == user.Last && firstUser.PostalCode == user.PostalCode;
            }

            return firstUser.First == user.First && firstUser.Last == user.Last;
        }
    }
}