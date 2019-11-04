using System;
using System.Configuration;
using Facade.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Facade_Assignment
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
        public void Given_Wizard_When_IsFilled_Then_ShouldCompleteTheForm()
        {
            _driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["url"]);

            var wizard = new WizardFacade(_driver);
            wizard.Fill();
        }

    }
}
