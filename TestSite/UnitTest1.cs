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

        [TestCase("Apple")]
        public void TestLabelSearch(string search) {
            string actual = page.GetSearchHeader(search);
            string expected = "Search - " + search;
            Assert.AreEqual(actual, expected);
        }



        [TearDown]
        public void closeBrowser()
        {
            page.CloseBrowser();
        }

    }
}
