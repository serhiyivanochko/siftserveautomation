using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

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

        [TestCase("Apple")]
        public void TestCategoryDropDown(string search)
        {
            chrome = new ChromeDriver();

            chrome.Navigate().GoToUrl("http://atqc-shop.epizy.com/");
            chrome.FindElementByName("search").SendKeys(search);
            chrome.FindElementByClassName("fa-search").Click();
            chrome.FindElementByName("category_id").Click();

            for (int i = 0; i < chrome.FindElementsByTagName("option").Count; i++) {
                chrome.FindElementsByTagName("option")[i].Click();
                Assert.AreEqual(current.Text, chrome.FindElementsByTagName("option")[i].Text);
            }

            foreach (var current in chrome.FindElementsByTagName("option")) {
                current.Click();
                
                
            }
            
        }

        [TestCase("Apple", 4, 17)]
        public void TestCategoryResult(string search, int count, int categoryIndex) {
            chrome = new ChromeDriver();

            chrome.Navigate().GoToUrl("http://atqc-shop.epizy.com/");
            chrome.FindElementByName("search").SendKeys(search);
            chrome.FindElementByClassName("fa-search").Click();
            chrome.FindElementByName("category_id").Click();
            chrome.FindElementsByTagName("option")[categoryIndex].Click();
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
