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

        public string GetTextFromSearchLabel() {
            return this.searchLabel.Text;
        }

        public void ClearSearchTextBox()
        {
            this.searchTextBox.Clear();
        }
        public void ClickSearchTextBox()
        {
            this.searchTextBox.Click();
        }
        public void SetTextInSearchTextBox(string text)
        {
            this.searchTextBox.SendKeys(text);
        }
        public string GetTextFromSearchTextBox()
        {
            return this.searchTextBox.Text;
        }

        public void ClickSearchCategoryCheck() {
            this.searchCategoryCheck.Click();
        }
        public bool GetSearchCategoryValue() {
            return this.searchCategoryCheck.Selected;
        }

        public bool GetSearchDescriptionValue()
        {
            return this.searchDescriptionChek.Selected;
        }
        public void ClickSearchDescription()
        {
            this.searchDescriptionChek.Click();
        }

        public void ClickSearchButton() {
            this.searchButton.Click();
        }

        public void ClickListShowButton()
        {
            this.listShowButton.Click();
        }

        public void ClickGridShowButton()
        {
            this.gridShowButton.Click();
        }

        public void ClickProductCompareLabel() {
            this.productCompareLabel.Click();
        }
        public string GetProductCompareText() {
            return this.productCompareLabel.Text;
        }

        public string GetProductPageLabelText()
        {
            return this.productPageLabel.Text;
        }

        public void SetCategoryValue(string category) {
            this.selectCategory.SelectByValue(category);
        }
        public string GetSelectedCategory() {
            return this.selectCategory.SelectedOption.Text;
        }

        public void SetSortedByValue(string sorted)
        {
            this.selectSortBy.SelectByValue(sorted);
        }
        public string GetSelectedSortBy()
        {
            return this.selectSortBy.SelectedOption.Text;
        }

        public void SetShowValue(string category)
        {
            this.selectShow.SelectByValue(category);
        }
        public string GetSelectedShow()
        {
            return this.selectShow.SelectedOption.Text;
        }



    }
}
