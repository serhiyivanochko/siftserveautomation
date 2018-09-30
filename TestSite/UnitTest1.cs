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
            int expected = page.Search(search);
            Assert.AreEqual(page.Search(search), count);
        }

        [TestCase("Apple")]
        public void TestCategoryDropDown(string search) {
            page.Search(search);
            Assert.IsTrue(page.TestCategoriesValue(GlobalVariables.inputListCategories));
        }

        //[TestCase("Apple")]
        //public void TestCategoryDropDown(string search)
        //{



        //    chrome.FindElementByName("search").SendKeys(search);
        //    chrome.FindElementByClassName("fa-search").Click();
        //    chrome.FindElementByName("category_id").Click();

        //    List<string> list = new List<string>();
        //    foreach (var current in chrome.FindElementByName("category_id").FindElements(By.TagName("option"))) {
        //        list.Add(current.Text);
        //    }
        //    for(int i=0;i< list .Count;i++)
        //    {
        //        var elements = chrome.FindElementByName("category_id").FindElements(By.TagName("option"));
        //        elements[i].Click();

        //        chrome.FindElementById("button-search").Click();

        //        IWebElement selectedOption = null;
        //        foreach (var current in chrome.FindElementByName("category_id").FindElements(By.TagName("option")))
        //        {
        //            if (current.Selected)
        //            {
        //                selectedOption = current;
        //                break;
        //            }
        //        }

        //        Assert.AreEqual(list[i], selectedOption.Text);
        //    }

        //}

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
