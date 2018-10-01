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
    class Header
    {
        

        protected IWebElement searchTextBox = GlobalVariables.driver.FindElement(By.XPath(".//div[@id='search']/input"));
        protected IWebElement searchButton = GlobalVariables.driver.FindElement(By.XPath(".//div[@id='search']/span"));

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
        public Content ClickSearchButton()
        {
            this.searchButton.Click();
            return new Content(GlobalVariables.driver);
        }
        
    }
}
