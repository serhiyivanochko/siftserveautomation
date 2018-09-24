using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestSite
{
    [TestFixture]
    public class UnitTest1
    {
        ChromeDriver chrome;

        [TestCase("Apple",7)]
        public void SearchingResultItemsCount(string search, int count)
        {
            chrome = new ChromeDriver();

            chrome.Navigate().GoToUrl("http://atqc-shop.epizy.com/");
            chrome.FindElementByName("search").SendKeys(search);
            chrome.FindElementByClassName("fa-search").Click();

            Assert.AreEqual(chrome.FindElementsByClassName("product-layout").Count,count);
        }

        [TestCase("Apple", 4)]
        public void TestCategoryDropDown(string search, int count) {
            chrome = new ChromeDriver();

            chrome.Navigate().GoToUrl("http://atqc-shop.epizy.com/");
            chrome.FindElementByName("search").SendKeys(search);
            chrome.FindElementByClassName("fa-search").Click();
            chrome.FindElementByName("category_id").Click();
            chrome.FindElementsByTagName("option")[17].Click();
            chrome.FindElementById("button-search").Click();

            Assert.AreEqual(chrome.FindElementsByClassName("product-layout").Count, count);
        }


        [TearDown]
        public void closeBrowser()
        {
            chrome.Close();
        }

    }
}
