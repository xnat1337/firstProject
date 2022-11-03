using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeleniumCoreDemo.Pages
{
    internal class CartPage
    {
        Regex re = new Regex(@"[0-9][0-9]?\.[0-9][0-9]");
        IWebDriver webDriver;
        public By sauceDemoCartCheckItemName = By.XPath("//div[@class = 'inventory_item_name']");
        public By sauceDemoCartItemPriceCheck = By.XPath("//div[@class = 'item_pricebar']");
        public By SauceDemoCartQuantity = By.XPath("//div[@class = 'cart_quantity']");
        public By sauceDemoCartCheckout = By.XPath("//button[contains(text(), 'Checkout')]");
        public By sauceDemoCartFirstItemRemoveButton = By.XPath("//div[@class='cart_list'][1]//button");
        public By sauceDemoCartNumberOfItemsInShoppingCartButton = By.XPath("//span[@class='shopping_cart_badge']");
        public By sauceDemoCartRemovedItemEmptyField = By.XPath("//div[@class='removed_cart_item']");


        public CartPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public string GetCartItemName()
        {
            string checkCartItemNameText;
            IWebElement checkCartItemName = webDriver.FindElement(sauceDemoCartCheckItemName);
            checkCartItemNameText = checkCartItemName.Text;
            return checkCartItemNameText;           
        }

        public string GetCartItemPrice()
        {
            string priceText;
            IWebElement price = webDriver.FindElement(sauceDemoCartItemPriceCheck);
            priceText = re.Match(price.Text).Value;
            return priceText;
        }

        public string GetCartQuantity()
        {
            string quantityText;
            IWebElement cartQuantity = webDriver.FindElement(SauceDemoCartQuantity);
            quantityText = cartQuantity.Text;
            return quantityText;
        }

        public void ClickCheckoutButton()
        {
            webDriver.FindElement(sauceDemoCartCheckout).Click();
        }

        public void ClickRemoveButtonForFirstItem()
        {
            webDriver.FindElement(sauceDemoCartFirstItemRemoveButton).Click();
        }

        public bool IsRemovedItemEnabled() 
        {
            return webDriver.FindElement(sauceDemoCartRemovedItemEmptyField).Enabled;
        }

    }

}
