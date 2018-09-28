using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSite.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestSite.Logic
{

    class SearchMethods
    {
        static ChromeDriver driver;

        public SearchMethods() {
            driver = new ChromeDriver();
        }

        public static void SearchingMethod(string testSearch, string category, bool chekSubcategory = false, bool checkSearchInDesc = false)
        {
            Content content = new Content(driver);

            content.SetTextInSearchTextBox(testSearch);
            content.SetCategoryValue(category);

            if (chekSubcategory != content.GetSearchCategoryValue()) {
                content.ClickSearchCategoryCheck();
            }

            if (checkSearchInDesc != content.GetSearchDescriptionValue())
            {
                content.ClickSearchDescription();
            }

            content.ClickSearchButton();
        }
    }
}
