using System.Configuration;
using System.Drawing;
using AbstractFactory.Factories;
using AbstractFactory.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AbstractFactory
{
    [TestClass]
    public class Test
    {
        [TestInitialize]
        public void SetupTest()
        {
            _driver = new ChromeDriver();
          
        }

        [TestCleanup]
        public void TearDownTest()
        {
            _driver.Close();
            _driver.Quit();
            _driver.Dispose();
        }

        private IWebDriver _driver;

        [DataTestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void Given_UsersPage_When_IsLoaded_Then_ShouldHaveUsersOrderedByFirstNameAlphabetically(bool isMobile)
        {
            var url = ConfigurationManager.AppSettings["url"];
            _driver.Navigate().GoToUrl(url);
            UsersPage page;
            var clientName = ConfigurationManager.AppSettings["clientName"];
            IUsersPageFactory factory;

            if (clientName == "test1")
            {
                factory = new CustomUsersPageFactory(_driver);
            }
            else
            {
                factory = new NormalUsersPageFactory(_driver);
            }

            if (isMobile)
            {
                _driver.Manage().Window.Size = new Size(600, 1000);
                page = factory.CreateMobilePage();
            }
            else
            {
                _driver.Manage().Window.Maximize();
                page = factory.CreateDesktopPage();
            }

            page.Load();
            var isOrderedCorrectly = page.IsFirstUser(new UserInfo
            {
                First = "Jacob",
                Last = "Thornton",
                PostalCode = "756y8GG"
            });

            Assert.IsTrue(isOrderedCorrectly);
        }
    }
}