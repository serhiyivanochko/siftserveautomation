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
        protected SelectElement selectCategory { get; private set; }
    }
}
