using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using Unit.Test2.Helper;

namespace Unit.Test2.PageObjects
{
    class PhpHotelPage
    {

        private IWebDriver _driver;
        public PhpHotelPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.Name, Using = "hotel_s2_text")]
        private IWebElement _searchHotelOrCityTxtBox;

        [FindsBy(How = How.PartialLinkText, Using = "Search by Hotel")]
        private IWebElement _searchbox;

        [FindsBy(How = How.Name, Using = "checkin")]
        private IWebElement _checkin;

        [FindsBy(How = How.Name, Using = "checkout")]
        private IWebElement _checkout;

        [FindsBy(How = How.XPath, Using = "//button[text()=' Search']")]
        private IWebElement _searchBtn;

        [FindsBy(How = How.XPath, Using = "//span[@class='select2-match']")]
        private IWebElement _hotelInNewYork;
      
        [FindsBy(How = How.XPath, Using = "//*[@id='ROOMS']//tbody/tr[1]/td/div[2]/div[2]/div/div[3]/div/label/div")]
        private IWebElement _roomCheckbox;

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'book')]")]
        private IWebElement _bookNowBtn;

        [FindsBy(How = How.Name, Using = "logged")]
        private IWebElement _confirmbookBtn;

        [FindsBy(How = How.XPath, Using = "//button[(text()='Pay on Arrival')]")]
        private IWebElement _PayOnArrivalBtn;

        [FindsBy(How = How.CssSelector, Using = "b.wow.flash.animted.animated.animated")]
        private IWebElement _bookingStatus;
        

        public void SearchAHotel()
        {
            _driver.WaitForElement(_searchHotelOrCityTxtBox);
            _searchbox.Click();
            _searchHotelOrCityTxtBox.SendKeys("Hotel-97583");
             _driver.WaitForElement(_hotelInNewYork);
            _hotelInNewYork.Click();
            _checkin.SendKeys("18/07/2019");
            _checkout.SendKeys("19/07/2019");
            _searchBtn.Click();
        }

        public void SelectAHotel()
        {
            _driver.WaitForElement(_roomCheckbox);
            var actions = new Actions(_driver);
            actions.MoveToElement(_roomCheckbox).Perform();
            _roomCheckbox.Click();
        }
        public void BookAHotel()
        {
            _driver.WaitForElement(_bookNowBtn);
            if (_bookNowBtn.Enabled)
            {
                _bookNowBtn.Click();
            }
            else {
                Console.WriteLine("Book Now button not enabled to click");
            }

            _driver.WaitForElement(_confirmbookBtn);
            _confirmbookBtn.Click();
            _driver.WaitForElement(_PayOnArrivalBtn);
            _PayOnArrivalBtn.Click();
            _driver.SwitchTo().Alert().Accept();
        }
        public bool SuccessMsgForBooking() {
            _driver.WaitForElement(_bookingStatus);
            return (_bookingStatus.Displayed);
        } 
    }
}
