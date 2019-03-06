using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Unit.Test2.Helper;

namespace Unit.Test2.PageObjects
{
    class PhpMyAccountPage
    {
        private IWebDriver _driver;
        public PhpMyAccountPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
        
        [FindsBy(How = How.XPath, Using = "//a[@class='text-center']")]
        private IList<IWebElement> _navigationElements { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "flights")]
        private IWebElement _flightsLnk;

        [FindsBy(How = How.PartialLinkText, Using = "tours")]
        private IWebElement _toursLnk;

        [FindsBy(How = How.XPath, Using = " //h3[@class='RTL']")]
        private IWebElement _profileWelcomeMsg;

       

        public void VerifyLoginSuccess()
        {
            _driver.WaitForElement(_profileWelcomeMsg);
        }

        public void NavigateToHotels()
        {
            _navigationElements.First(el => el.Text.Contains("HOTELS")).Click();
        }

        public void NavigateToFlights()
        {
            _flightsLnk.Click();
        }
        public void NavigateToTours()
        {
            _toursLnk.Click();
        }
    }
}
