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
    class PhpHomePage
    {
        private IWebDriver _driver;
        public PhpHomePage(IWebDriver driver) {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.Name, Using = "username")]
        private IWebElement _username;

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement _password;

        [FindsBy(How = How.XPath, Using = "//button[text()='Login']")]
        private IWebElement _LoginBtn;


        public void login() {
            _driver.WaitForElement(_username);
            _username.SendKeys("user@phptravels.com");
            _password.SendKeys("demouser");
            _LoginBtn.Click();
        }
    }
}
