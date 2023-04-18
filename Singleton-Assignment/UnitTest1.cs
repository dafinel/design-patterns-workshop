using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Singleton;

namespace Singleton_Assignment
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver _driver;

        [TestMethod]
        public void SearchOnGoogle()
        {
            var googlePage = new GooglePage(_driver);
            googlePage.Load();
            googlePage.SearchOn("centric it solutions iasi");

            var searchResultPage = new GoogleSeachResultPage(_driver);
            searchResultPage.Load();

            Assert.AreEqual(searchResultPage.FirstSearchTitle, "Working at Centric Romania: IT Careers for your Future");
        }


        [TestCleanup]
        public void TearDownTest()
        {
            _driver.Close();
        }

        [TestInitialize]
        public void SetupTest()
        {
            _driver = new ChromeDriver();
        }
    }
}
