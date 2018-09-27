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
    class ProductItem
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

        static protected List<ProductItem> listProduct;

        public ProductItem()
        {

        }
        public ProductItem(IWebDriver driver)
        {
            var elements = driver.FindElements(By.ClassName("product-layout"));

            foreach (var current in elements)
            {
                ProductItem product = new ProductItem();

                product.productBox = current;
                product.productImage = current.FindElement(By.ClassName("image"));
                product.productName = current.FindElement(By.CssSelector(".caption+h4+a"));
                product.productDescription = current.FindElements(By.CssSelector(".caption p"))[0];
                product.productPrice = current.FindElement(By.CssSelector(".caption .price"));
                product.productExTax = current.FindElement(By.CssSelector(".caption .price .price-tax"));
                var listIcons = current.FindElements(By.CssSelector(".button-group"));
                product.productIconCart = listIcons[0];
                product.productIconFavourite = listIcons[1];
                product.productIconCompare = listIcons[2];

                listProduct.Add(product);
            }
        }

        //ProductImage
        public void ClickProductImage()
        {
            this.productImage.Click();
        }
        
        //ProductName
        public void ClickProductName()
        {
            this.productName.Click();
        }

        //GetTextFromLabel
        public string GetTextFromProductName()
        {
            return this.productName.Text;
        }
        public string GetTextFromProductDescription()
        {
            return this.productDescription.Text;
        }
        public string GetTextFromProductPrice()
        {
            return this.productPrice.Text;
        }
        public string GetTextFromProductExTax()
        {
            return this.productExTax.Text;
        }

        //Buttons
        public void ClickCartButton()
        {
            this.productIconCart.Click();
        }
        public void ClickCartfavourite()
        {
            this.productIconFavourite.Click();
        }
        public void ClickCompareButton()
        {
            this.productIconCompare.Click();
        }
    }
}
