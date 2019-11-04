using System;
using System.Configuration;
using ChainOfResponsability.Handlers;
using ChainOfResponsability.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ChainOfResponsability_Assignment
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

        [DataTestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void Given_Wizard_When_IsFilled_Then_ShouldCompleteTheForm(bool isEmployee)
        {
            _driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["url"]);

            var handler = new StepOneHandler(_driver, isEmployee);
            handler.Handle();
        }
    }
}
