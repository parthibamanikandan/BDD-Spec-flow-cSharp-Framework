using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using Unit.Test2.PageObjects;
using NUnit.Framework;

namespace Unit.Test2
{
    [Binding]
    public class PlaceOnlineOrderAtEbayWebsiteSteps
    {
        private IWebDriver _driver ;
        private EbayHomePage ebayHome;
        private EbayItemDetails ebayItemDetails;
        
        [Given(@"user launches ebay website")]
        public void GivenuserLaunchesEbayWebsite()
        {

            _driver = (IWebDriver)ScenarioContext.Current["driver"];
            _driver.Url =(string) ScenarioContext.Current["url"];
            _driver.Manage().Window.Maximize();
            ebayHome = new EbayHomePage(_driver);
        }

        [When(@"user searches ""(.*)"" and select first item")]
        public void WhenuserSearchesAndAddsItemsToCartWithItempreference(string p0)
        {
            ebayHome.SearchForProduct(p0);
          //  ebayHome.SelectPhonePreferenceAndAddToCart();
        }

        /* [When(@"user Add itemdesc")]
         public void WhenuserAddItemdesc(String p1)
         {
             ebayHome.SearchForProduct(p1);
             ebayHome.SelectPhonePreferenceAndAddToCart();
         }*/


        [When(@"user selects ""(.*)"" preferences and add to cart")]
        public void WhenuserSelectsPreferencesAndAddToCart(string p0)
        {
            // ScenarioContext.Current.Pending();
            ebayItemDetails = new EbayItemDetails(_driver);
            if (p0.Trim().Equals("IPhone", StringComparison.InvariantCultureIgnoreCase))
            {
                ebayItemDetails.SelectPhonePreferenceAndAddToCart();
                
            }
            else if (p0.Trim().Equals("IPhone Case", StringComparison.InvariantCultureIgnoreCase))
            {
                ebayItemDetails.SelectCasePreferenceAndAddToCart();
            }

        }
        

        [Then(@"user should have (.*) items in the cart")]
        public void ThenUserShouldHaveItemsInTheCart(int p0)
        {
            var actualCount = ebayItemDetails.GetCartCount();
            Assert.IsTrue(actualCount == p0, "Cart count is not matching, expected: {0} actual {1}", p0, actualCount);
        }

    }
}
