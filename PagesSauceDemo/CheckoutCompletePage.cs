using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCoreDemo.Pages
{
    internal class CheckoutCompletePage
    {
        IWebDriver webDriver;
        public By sauceDemoCheckoutComplete = By.XPath("//h2[contains(text(), 'THANK YOU FOR YOUR ORDER')]");

        public CheckoutCompletePage(IWebDriver webDriver) {this.webDriver = webDriver;}

        public string GetCheckoutCompleteMessage()
        {
            return webDriver.FindElement(sauceDemoCheckoutComplete).Text;
        }
    }
}
