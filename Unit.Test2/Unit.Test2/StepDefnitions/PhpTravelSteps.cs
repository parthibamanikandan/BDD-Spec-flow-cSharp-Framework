using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Unit.Test2.StepDefnitions
{
    [Binding]
    public class PhpTravelSteps
    {
        private IWebDriver _driver;

        [Given(@"user launches PHP Travel website")]
        public void GivenUserLaunchesPHPTravelWebsite()
        {

            _driver = (IWebDriver)ScenarioContext.Current["driver"];
            _driver.Url = "https://www.phptravels.net/account/";
            _driver.Manage().Window.Maximize();
            _driver.FindElement(By.LinkText("HOTELS")).Click();
            // ebayHome = new EbayHomePage(_driver);
            _driver.FindElement(By.LinkText("HOTELS")).Click();
        }
    }
}
