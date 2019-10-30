using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AbstractFactory.Pages
{
    public class MobileNormalUsersPage: UsersPage
    {
        public MobileNormalUsersPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public override void Load()
        {
            IWebElement accordion = null;
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(15));
            wait.Until(driver => accordion = driver.FindElement(By.Id("accordionExample")));

            var rows = accordion.FindElements(By.ClassName("card"));

            foreach (var row in rows)
            {
                var name = row.FindElement(By.TagName("button"));
                name.Click();
                var body = row.FindElement(By.ClassName("card-body"));

                var columns = body.FindElements(By.TagName("span"));
                var user = new UserInfo
                {
                    First = name.Text.Split(' ')[0],
                    Last = name.Text.Split(' ')[1],
                    Email = columns[0].Text,
                    Phone = columns[1].Text,
                    Street = columns[2].Text,
                    HouseNumber = columns[3].Text,
                    City = columns[4].Text,
                    State = columns[5].Text,
                    Country = columns[6].Text
                };
                Users.Add(user);
            }
        }

        public override bool IsFirstUser(UserInfo user)
        {
            var firstUser = Users.FirstOrDefault();
            return firstUser != null && firstUser.First == user.First && firstUser.Last == user.Last;
        } 
    }
}