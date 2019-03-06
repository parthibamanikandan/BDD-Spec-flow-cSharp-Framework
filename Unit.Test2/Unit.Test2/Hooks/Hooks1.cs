using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Unit.Test2.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private IWebDriver _driver;

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = new ChromeDriver();
           // _driver.Url = "https://www.ebay.com.au/";
            _driver.Manage().Window.Maximize();
            ScenarioContext.Current["driver"] = _driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
