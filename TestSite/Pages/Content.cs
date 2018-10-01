using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TestSite.Logic;

namespace TestSite.Pages
{
    class Content : Header
    {

        protected IWebElement searchLabel = GlobalVariables.driver.FindElement(By.CssSelector("#content h1"));
        protected IWebElement searchTextBoxInsideContent = GlobalVariables.driver.FindElement(By.Id("input-search"));
        protected IWebElement searchCategoryCheck = GlobalVariables.driver.FindElement(By.Name("sub_category"));
        protected IWebElement searchDescriptionChek = GlobalVariables.driver.FindElement(By.Name("description"));
        protected IWebElement searchButtonInsideContent = GlobalVariables.driver.FindElement(By.Id("button-search"));
        protected IWebElement listShowButton = GlobalVariables.driver.FindElement(By.Id("list-view"));
        protected IWebElement gridShowButton = GlobalVariables.driver.FindElement(By.Id("grid-view"));
        protected IWebElement productCompareLabel = GlobalVariables.driver.FindElement(By.Id("compare-total"));
        protected IWebElement productPageLabel = GlobalVariables.driver.FindElement(By.ClassName("text-right"));

        protected SelectElement selectCategory = new SelectElement(GlobalVariables.driver.FindElement(By.Name("category_id")));
        protected SelectElement selectSortBy = new SelectElement(GlobalVariables.driver.FindElement(By.Id("input-sort")));
        protected SelectElement selectShow = new SelectElement(GlobalVariables.driver.FindElement(By.Id("input-limit")));

        protected List<ProductItem> listProduct;

        public Content(IWebDriver driver)
        {
            var elements = GlobalVariables.driver.FindElements(By.ClassName("product-layout"));
            this.listProduct = new List<ProductItem>();

            foreach (var current in elements) {
                this.listProduct.Add(new ProductItem(driver, current));
            }
        }

        public List<ProductItem> GetListProduct() {
            return this.listProduct;
        }

        public string GetTextFromSearchLabel() {
            return this.searchLabel.Text;
        }

        public Content ClearsearchTextBoxInsideContent()
        {
            searchTextBoxInsideContent.Clear();
            return this;
        }
        public Content ClicksearchTextBoxInsideContent()
        {
            searchTextBoxInsideContent.Click();
            return this;
        }
        public Content SetTextInsearchTextBoxInsideContent(string text)
        {
            this.searchTextBoxInsideContent.SendKeys(text);
            return this;
        }
        public string GetTextFromsearchTextBoxInsideContent()
        {
            return this.searchTextBoxInsideContent.Text;
        }

        public Content ClickSearchCategoryCheck() {
            this.searchCategoryCheck.Click();
            return this;
        }
        public bool GetSearchCategoryValue() {
            return this.searchCategoryCheck.Selected;
        }

        public bool GetSearchDescriptionValue()
        {
            return this.searchDescriptionChek.Selected;
        }
        public Content ClickSearchDescription()
        {
            this.searchDescriptionChek.Click();
            return this;
        }

        public Content ClickSearchButtonInsideContent() {
            this.searchButtonInsideContent.Click();
            return new Content(GlobalVariables.driver);
        }

        public Content ClickListShowButton()
        {
            this.listShowButton.Click();
            return this;
        }

        public Content ClickGridShowButton()
        {
            this.gridShowButton.Click();
            return this;
        }

        public Content ClickProductCompareLabel() {
            this.productCompareLabel.Click();
            return this;
        }
        public string GetProductCompareText() {
            return this.productCompareLabel.Text;
        }

        public string GetProductPageLabelText()
        {
            return this.productPageLabel.Text;
        }

        public List<string> GetListOfCategories() {
            List<string> list = new List<string>();
            foreach (var current in this.selectCategory.Options) {
                list.Add(current.Text);
            }
            return list;
        }

        public Content SetCategoryValue(string category) {
            this.selectCategory.SelectByText(category);
            return this;
        }
        public string GetSelectedCategory() {
            return this.selectCategory.SelectedOption.Text;
        }

        public Content SetSortedByValue(string sorted)
        {
            this.selectSortBy.SelectByText(sorted);
            return this;
        }
        public string GetSelectedSortBy()
        {
            return this.selectSortBy.SelectedOption.Text;
        }

        public Content SetShowValue(string category)
        {
            this.selectShow.SelectByText(category);
            return this;
        }
        public string GetSelectedShow()
        {
            return this.selectShow.SelectedOption.Text;
        }



    }
}
