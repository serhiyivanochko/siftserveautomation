using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TestSite.Logic;

namespace TestSite
{
    [TestFixture]
    public class UnitTest1
    {
        SearchMethods page;
        [SetUp]
        public void SetUp() {
            page = new SearchMethods();
        }

        [TestCase("Apple", 7)]
        public void SearchingResultItemsCount(string search, int count)
        {
            int actual = page.Search(search).GetListProduct().Count;
            Assert.AreEqual(actual, count);
        }

        [TestCase("Apple")]
        public void TestCategoryDropDown(string search) {
            page.Search(search);
            Assert.IsTrue(page.TestCategoriesValue(GlobalVariables.inputListCategories));
        }

        [TestCase("Apple", "Tablets", 4)]
        public void TestCategoryResult(string search, string category, int count) {
            int actual = page.SearchByCategory(search, category);
            Assert.AreEqual(actual, count);
        }


        //[TestCase("Apple", 4, 17)]
        //public void TestCategoryResult(string search, int count, int categoryIndex)
        //{


        //    chrome.FindElementByName("search").SendKeys(search);
        //    chrome.FindElementByClassName("fa-search").Click();
        //    chrome.FindElementByName("category_id").Click();
        //    chrome.FindElementsByTagName("option")[categoryIndex].Click();
        //    chrome.FindElementById("button-search").Click();

        //    Assert.AreEqual(chrome.FindElementsByClassName("product-layout").Count, count);
        //}
        //[TestCase("Apple")]
        //public void TestDescriptionCheckBox(string search) {




        //    chrome.FindElementByName("search").SendKeys(search);
        //    chrome.FindElementByClassName("fa-search").Click();
        //    bool checked_element = chrome.FindElementById("description").Selected;
        //    chrome.FindElementById("description").Click();
        //    bool unchecked_element = chrome.FindElementById("description").Selected;
        //    Assert.AreEqual(checked_element, !unchecked_element);
        //}


        [TearDown]
        public void closeBrowser()
        {
            page.CloseBrowser();
        }

    }
}
