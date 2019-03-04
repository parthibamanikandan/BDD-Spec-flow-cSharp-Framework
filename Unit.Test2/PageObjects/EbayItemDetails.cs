using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Unit.Test2.Helper;
using OpenQA.Selenium.Support.UI;
using System;

namespace Unit.Test2.PageObjects
{
    class EbayItemDetails
    {
        private IWebDriver _driver;
        public EbayItemDetails(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Add to cart')]")]
        private IWebElement _AddToCart;

        [FindsBy(How = How.Id, Using = "msku-sel-1")]
        private IWebElement _Color;

        [FindsBy(How = How.Id, Using = "msku-sel-2")]
        private IWebElement _Storage;

        [FindsBy(How = How.Name, Using = "iPhone Protection Pack")]
        private IWebElement _ProtectionPack;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'No thanks')]")]
        private IWebElement _NoThanksBtn;

        [FindsBy(How = How.Name, Using = "Compatible Model")]
        private IWebElement _CompatibleModel;

        [FindsBy(How = How.Name, Using = "Colour")]
        private IWebElement _CoverColor;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Go to cart')]")]
        private IWebElement _GoToCart;

        [FindsBy(How = How.Id, Using = "gh-cart-n")]
        private IWebElement _CartCount;

        public void SelectPreference()
        {
            SelectElement select = new SelectElement(_driver.FindElement(By.Name("Color")));
            select.SelectByValue("1");
            SelectElement storage = new SelectElement(_driver.FindElement(By.Name("Storage")));
            storage.SelectByValue("5");

        }
        public void SelectPhonePreferenceAndAddToCart()
        {
            _driver.WaitForElement(_AddToCart);

            // SelectList.SelectElementbyNameValue("Storage Capacity:16GB");

            SelectElement select = new SelectElement(_Color);
            select.SelectByText("Gold");

            SelectElement storage = new SelectElement(_Storage);
            storage.SelectByValue("5");

            try
            {
                SelectElement protection = new SelectElement(_ProtectionPack);
                protection.SelectByValue("7");
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Protection package not visible");
            }
            _AddToCart.Click();

            _driver.WaitForElement(_NoThanksBtn);
            _NoThanksBtn.Click();
            System.Threading.Thread.Sleep(3000);
        }

        public void SelectCasePreferenceAndAddToCart()
        {

            _driver.WaitForElement(_AddToCart);

            SelectElement select1 = new SelectElement(_CompatibleModel);
            select1.SelectByValue("1");

            SelectElement storage1 = new SelectElement(_CoverColor);
            storage1.SelectByValue("14");

            _AddToCart.Click();

            _driver.WaitForElement(_GoToCart);
            _GoToCart.Click();

            System.Threading.Thread.Sleep(5000);
        }
        public int  GetCartCount() {
          return  int.Parse(_CartCount.Text);

        }

    }

  
}
