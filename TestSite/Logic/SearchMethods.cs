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


        public SearchMethods()
        {
            GlobalVariables.driver = new ChromeDriver();
            GlobalVariables.driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/");
        }

        public string GetSearchHeader(string search) {
            Content content = Search(search);
            return content.GetTextFromSearchLabel();
        }
        public Content Search(string textSearch)
        {
            Header item = new Header(GlobalVariables.driver);
            item.ClickSearchTextBox();
            item.ClearSearchTextBox();
            item.SetTextInSearchTextBox(textSearch);
            Content page = item.ClickSearchButton();

            return page;
        }

        public bool TestCategoriesValue(List<string> list)
        {
            Content content = new Content(GlobalVariables.driver);
            List<string> actual = content.GetListOfCategories();
            int count = 0;
            for (int i = 0; i < actual.Count; i++) {
                if (actual[i].Replace(" ", "") == list[i].Replace(" ", "")) {
                    count++;
                }
            }
            
            return count == actual.Count ? true : false; ;
        }

        public int SearchByCategory(string textSearch, string category) {

            Content content = Search(textSearch);
            content.SetCategoryValue(category);

            content = content.ClickSearchButtonInsideContent();

            return content.GetListProduct().Count;
        }

        public void SearchingMethod(string testSearch, string category, bool chekSubcategory = false, bool checkSearchInDesc = false)
        {
            Content content = new Content(GlobalVariables.driver);

            content.SetTextInSearchTextBox(testSearch);
            content.SetCategoryValue(category);

            if (chekSubcategory != content.GetSearchCategoryValue())
            {
                content.ClickSearchCategoryCheck();
            }

            if (checkSearchInDesc != content.GetSearchDescriptionValue())
            {
                content.ClickSearchDescription();
            }

            content.ClickSearchButton();
        }

        public void CloseBrowser()
        {
            GlobalVariables.driver.Close();
        }
    }
}
