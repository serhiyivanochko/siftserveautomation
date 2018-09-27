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
    class AProductItem
    {
        protected IWebElement productBox { get; private set; }
        protected IWebElement productImage { get; private set; }
        protected IWebElement productName { get; private set; }
        protected IWebElement productDescription { get; private set; }
        protected IWebElement productPrice { get; private set; }
        protected IWebElement productExTax { get; private set; }
        protected IWebElement productIconCart { get; private set; }
        protected IWebElement productIconFavourite { get; private set; }
        protected IWebElement productIconCompare { get; private set; }

        static protected List<AProductItem> listProduct;

        public AProductItem(IWebDriver driver)
        {


            var elements = driver.FindElements(By.ClassName("product-layout"));
            foreach (var current in elements)
            {
                this.productBox = current;
                this.productImage = current.FindElement(By.ClassName("image"));
                this.productName = current.FindElement(By.CssSelector(".caption+h4+a"));
                this.productDescription = current.FindElements(By.CssSelector(".caption p"))[0];
                this.productPrice = current.FindElement(By.CssSelector(".caption .price"));

            }


            

        }

        //TextBox
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

        //Button
        public void ClickSearchButton()
        {
            this.searchButton.Click();
        }
    }
}
