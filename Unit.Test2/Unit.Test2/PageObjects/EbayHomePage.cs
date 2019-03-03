using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Unit.Test2.Helper;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Unit.Test2.PageObjects
{
    class EbayHomePage {

        private IWebDriver _driver;
        public EbayHomePage(IWebDriver driver) {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//*[@name='_nkw']")]
        private IWebElement _searchBox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='gh-btn']")]
        private IWebElement _searchButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='mainContent']//li/div//div[2]/a")]
        private IWebElement _firstSearchResult;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Add to cart')]")]
        private IWebElement _AddToCart;

       // [FindsBy(How = How.XPath, Using = "//div[@id='mainContent']//select")]
       // private IList<IWebElement> SelectList;

        public void SearchForProduct( string searchProduct)
        {
            _searchBox.SendKeys(searchProduct);
            _searchButton.Click();

            _driver.WaitForElement(_firstSearchResult);
            _firstSearchResult.Click();

          

        }

      
    }
}
