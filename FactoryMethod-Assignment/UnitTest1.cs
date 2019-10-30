using System.Configuration;
using FactoryMethod_Assignment.Methods;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FactoryMethod_Assignment
{
    [TestClass]
    public class Test
    {
        [TestInitialize]
        public void SetupTest()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void TearDownTest()
        {
            _driver.Close();
            _driver.Quit();
            _driver.Dispose();
        }

        private IWebDriver _driver;

        [TestMethod]
        public void Given_UsersPage_When_IsLoaded_Then_ShouldHaveUsersOrderedByFirstNameAlphabetically()
        {
            var clientName = ConfigurationManager.AppSettings["clientName"];
            UsersMethods usersMethods;
            if (clientName == "test1")
            {
                usersMethods = new CustomUsersMethods(_driver);
            }
            else
            {
                usersMethods = new NormalUsersMethods(_driver);
            }
            var isOrderedCorrectly = usersMethods.VerifyIfTheOrderIsCorrect();

            Assert.IsTrue(isOrderedCorrectly);
        }
    }
}