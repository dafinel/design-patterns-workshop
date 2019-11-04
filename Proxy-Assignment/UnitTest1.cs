using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Proxy;

namespace Proxy_Assignment
{
    [TestClass]
    public class UnitTest1
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
        public void Given_Payment_When_FormIsFilledCorrectly_Then_ShouldBeRedirectedToSuccessfulPage()
        {
            var url = ConfigurationManager.AppSettings["url"];
            _driver.Navigate().GoToUrl(url);

            var paymentPage = new PaymentPage(_driver);
            paymentPage.Fill();
            paymentPage.Submit();

            var okPage = new OkPage(_driver);

            Assert.IsTrue(okPage.Is("Payment successful"));
        }
    }
}
