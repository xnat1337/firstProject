using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeleniumCoreDemo.Pages
{
    internal class CheckoutOverviewPage
    {
        IWebDriver webDriver;
        Regex re = new Regex(@"[0-9][0-9]?\.[0-9][0-9]");
        public By sauceDemoCheckoutItemName = By.XPath("//div[@class = 'inventory_item_name']");
        public By sauceDemoCheckoutItemQuantity = By.XPath("//div[@class = 'cart_quantity']");
        public By sauceDemoCheckoutItemPrice = By.XPath("//div[@class = 'inventory_item_price']");
        public By sauceDemoCheckoutOverviewFinishButton = By.XPath("//button[@name = 'finish']");

        public CheckoutOverviewPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public string GetOverviewItemName()
        {
            IWebElement itemName = webDriver.FindElement(sauceDemoCheckoutItemName);
            return itemName.Text;
        }

        public string GetOverviewItemPrice()
        {
            string priceText;
            IWebElement itemPrice = webDriver.FindElement(sauceDemoCheckoutItemPrice);
            priceText = re.Match(itemPrice.Text).Value;
            return priceText;
        }

        public string GetOverviewItemQuantity()
        {
            return webDriver.FindElement(sauceDemoCheckoutItemQuantity).Text;
        }

        public void ClickFinishButton()
        {
            webDriver.FindElement(sauceDemoCheckoutOverviewFinishButton).Click();
        }
    }
}
