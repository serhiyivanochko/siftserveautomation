using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace TestSite.Pages
{
    class Content
    {
        protected IWebElement searchLabel { get; private set; }
        protected IWebElement searchTextBox { get; private set; }
        protected IWebElement searchCategoryCheck { get; private set; }
        protected IWebElement searchDescriptionChek { get; private set; }
        protected IWebElement searchButton { get; private set; }
        protected IWebElement listShowButton { get; private set; }
        protected IWebElement gridShowButton { get; private set; }
        protected IWebElement productCompareLabel { get; private set; }
        protected IWebElement productPageLabel { get; private set; }

        protected SelectElement selectCategory { get; private set; }
        protected SelectElement selectSortBy { get; private set; }
        protected SelectElement selectShow { get; private set; }

        public Content(IWebDriver driver)
        {

            this.searchLabel = driver.FindElement(By.CssSelector(".content+h1"));
            this.searchTextBox = driver.FindElement(By.Id("input-search"));
            this.searchCategoryCheck = driver.FindElement(By.Name("sub_category"));
            this.searchDescriptionChek = driver.FindElement(By.Name("description"));
            this.searchButton = driver.FindElement(By.Id("button-search"));
            this.listShowButton = driver.FindElement(By.Id("list-view"));
            this.gridShowButton = driver.FindElement(By.Id("grid-view"));
            this.productCompareLabel = driver.FindElement(By.Id("compare-total"));
            this.productPageLabel = driver.FindElement(By.ClassName("text-right"));

            this.selectCategory = new SelectElement(driver.FindElement(By.Name("category_id")));
            this.selectSortBy = new SelectElement(driver.FindElement(By.Id("input-sort")));
            this.selectShow = new SelectElement(driver.FindElement(By.Id("input-limit")));

        }

    }
}
