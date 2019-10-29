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
        [TestMethod]
        public void SearchOnGoogle()
        {
            var googlePage = new GooglePage();
            googlePage.Load();
            googlePage.SearchOn("centric it solutions iasi");

            var searchResultPage = new GoogleSeachResultPage();
            searchResultPage.Load();

            Assert.AreEqual(searchResultPage.FirstSearchTitle, "Centric IT Solutions Romania - Acasă | Facebook");
        }


        [TestCleanup]
        public void TearDownTest()
        {
            WebDriver.Instance.Close();
            WebDriver.Instance.Dispose();
        }
    }
}
