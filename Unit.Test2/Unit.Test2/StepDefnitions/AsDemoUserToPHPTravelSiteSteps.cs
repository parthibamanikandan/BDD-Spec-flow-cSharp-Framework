using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using Unit.Test2.PageObjects;
using NUnit.Framework;
using System.Configuration;

namespace Unit.Test2.StepDefnitions
{
    [Binding]
    public class AsDemoUserToPHPTravelSiteSteps
    {
        private IWebDriver _driver;
        private PhpHomePage phpHomePage;
        private PhpMyAccountPage phpMyAccountPage;
        private PhpHotelPage phpHotelPage;

        [Given(@"user launches PHP Travel website")]
        public void GivenUserLaunchesPHPTravelWebsite()
        {
            _driver = (IWebDriver)ScenarioContext.Current["driver"];
            _driver.Url = ConfigurationManager.AppSettings["PhpTravelUrl"];
            _driver.Manage().Window.Maximize();
            phpHomePage = new PhpHomePage(_driver);
            phpMyAccountPage = new PhpMyAccountPage(_driver);
            phpHotelPage = new PhpHotelPage(_driver);

        }

        [When(@"user enters username and password")]
        public void WhenUserEntersUsernameAndPassword()
        {
            phpHomePage.login();
        }
        [Then(@"user login successfully")]
        public void ThenUserLoginSuccessfully()
        {
            phpMyAccountPage.VerifyLoginSuccess();
        }
        
        [Then(@"user searches a hotel in ""(.*)"" for future date")]
        public void ThenUserSearchesAHotelInForFutureDate(string p0)
        {
            phpMyAccountPage.NavigateToHotels();
            phpHotelPage.SearchAHotel();
        }
        
        [Then(@"user selects first search result")]
        public void ThenUserSelectsFirstSearchResult()
        {
            phpHotelPage.SelectAHotel();
        }

       [When(@"user click on book")]
        public void WhenUserClickOnBook()
        {
            phpHotelPage.BookAHotel();
        }

        [Then(@"user receives an invoice")]
        public void ThenUserReceivesAnInvoice()
        {
            Assert.IsTrue(phpHotelPage.SuccessMsgForBooking());
        }
    }
}
