using System;
using System.Collections.Generic;
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

        [TestCase("Apple", 7)]
        public void SearchingResultItemsCount(string search, int count)
        {
            chrome = new ChromeDriver();

            chrome.Navigate().GoToUrl("http://atqc-shop.epizy.com/");

            chrome.FindElementByName("search").Click();
            chrome.FindElementByName("search").Clear();
            chrome.FindElementByName("search").SendKeys(search);
            chrome.FindElementByClassName("fa-search").Click();


            Assert.AreEqual(chrome.FindElementsByClassName("product-layout").Count, count);
        }

        [TestCase("Apple")]
        public void TestCategoryDropDown(string search)
        {
            chrome = new ChromeDriver();

            chrome.Navigate().GoToUrl("http://atqc-shop.epizy.com/");
            chrome.FindElementByName("search").SendKeys(search);
            chrome.FindElementByClassName("fa-search").Click();
            chrome.FindElementByName("category_id").Click();

            string openedOption = null;
            List<string> list = new List<string>();
            foreach (var current in chrome.FindElementByName("category_id").FindElements(By.TagName("option"))) {
                list.Add(current.Text);
            }
            for(int i=0;i< list .Count;i++)
            {
                var elements = chrome.FindElementByName("category_id").FindElements(By.TagName("option"));
                elements[i].Click();

                chrome.FindElementById("button-search").Click();

                IWebElement selectedOption = null;
                foreach (var current in chrome.FindElementByName("category_id").FindElements(By.TagName("option")))
                {
                    if (current.Selected)
                    {
                        selectedOption = current;
                        break;
                    }
                }

                Assert.AreEqual(list[i], selectedOption.Text);
            }


           



        }

        [TestCase("Apple", 4, 17)]
        public void TestCategoryResult(string search, int count, int categoryIndex)
        {
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
