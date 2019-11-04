using System;
using System.Configuration;
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

        [TestMethod]
        public void Given_Wizard_When_IsFilled_Then_ShouldCompleteTheForm()
        {
            _driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["url"]);

            var isEmployee = true;
            var step1 = new StepOnePage(_driver, isEmployee);
            var step2 = new StepTwoPage(_driver);
            var step3 = new StepThreePage(_driver);
            var step4 = new StepFourPage(_driver);

            step1.Handle();
            step2.Handle();
            if (isEmployee)
            {
                step3.Handle();
            }

            step4.Handle();
        }
    }
}
