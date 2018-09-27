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
    abstract class AHeader
    {
        protected IWebElement searchTextBox { get; private set; }
        protected IWebElement searchButton { get; private set; }

        public AHeader(IWebDriver driver) {
            this.searchTextBox = driver.FindElement(By.XPath(".//div[@id='search']/input"));
            this.searchButton = driver.FindElement(By.XPath(".//div[@id='search']/span"));
        }

        //TextBox
        public void ClearSearchTextBox() {
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
