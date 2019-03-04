using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit.Test2.Helper
{
   static class Helper
    {

        public static void WaitForElement(this IWebDriver driver, IWebElement element)
        {
            var Wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            Wait.Until(c => element.Enabled && element.Displayed);
        }

     

        /*  public static void SelectElementbyNameValue(this IList<IWebElement> elments,string item)
          {
           var keyvalueArr=   item.Split(':');
          var element=    elments.First(el => { return el.GetAttribute("name").Trim().Equals(keyvalueArr[0]); });
           var selectElement=   new SelectElement(element);
              selectElement.SelectByText(keyvalueArr[1]);

          }
          */
    }
}
