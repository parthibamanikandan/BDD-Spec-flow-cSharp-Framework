using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Unit.Test2.Helper;
using OpenQA.Selenium.Support.UI;

namespace Unit.Test2.PageObjects
{
    class PhpTravelPages
    {
        private IWebDriver _driver;
        public PhpTravelPages(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//*[@name='username']")]
        private IWebElement _username;

        [FindsBy(How = How.XPath, Using = ".//*[@name='password']")]
        private IWebElement _password;

        [FindsBy(How = How.ClassName, Using = "btn btn-action btn-lg btn-block loginbtn")]
        private IWebElement _login;

        public void Login() {
            _username.SendKeys("user@phptravels.com");
            _password.SendKeys("demouser");
            _login.Click();
        }

        [FindsBy(How = How.PartialLinkText, Using = "https://www.phptravels.net/m-hotels")]
        private IWebElement _hotelBtn;

        [FindsBy(How = How.CssSelector, Using = "https://www.phptravels.net/m-flights")]
        private IWebElement _flightBtn;

        [FindsBy(How = How.CssSelector, Using = "https://www.phptravels.net/m-tours")]
        private IWebElement _toursBtn;

        public void NavigateTo(string locator) {
           var a= _driver.GetType();

        }
    }
}
