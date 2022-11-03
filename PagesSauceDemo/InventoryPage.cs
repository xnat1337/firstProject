using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeleniumCoreDemo.Pages
{
    internal class InventoryPage
    {
        Regex re = new Regex(@"[0-9][0-9]?\.[0-9][0-9]");      
        IWebDriver webDriver;
        WebDriverWait wait;
        public By sauceDemoInventoryItemName = By.XPath("//div[@class = 'inventory_item'][1]//div[@class = 'inventory_item_name']");
        public By sauceDemoInventoryItemOne = By.XPath("//div[@class = 'inventory_item'][1]");
        public By sauceDemoInventoryAddToCartButton = By.XPath("//div[@class = 'inventory_item'][1]//*[contains(text(), 'Add to cart')]");
        public By sauceDemoInventoryShoppingCardLink = By.XPath("//a[@class = 'shopping_cart_link']");
        public By sauceDemoItemPriceInventoryPage = By.XPath("//div[contains(text(), '29.99')]");
        public By sauceDemoInventoryMenuBox = By.XPath("//div[@class = 'bm-burger-button']");
        public By sauceDemoInventoryMenuBoxLogoutButton = By.XPath("//a[contains(text(), 'Logout')]");
        public By sauceDemoInventoryButtonForFirstItem = By.XPath("//div[@class='inventory_item'][1]//button");
        public string urlSauceDemoInventory = "https://www.saucedemo.com/inventory.html";

        public InventoryPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        public void Load()
        {
            webDriver.Navigate().GoToUrl(urlSauceDemoInventory);
        }

        public void IsLoaded()
        {
            Assert.AreEqual(webDriver.Url, urlSauceDemoInventory);
        }
        public string GetInventoryPageAddedItemName()
        {            
            IWebElement addedItemName = webDriver.FindElement(sauceDemoInventoryItemName);
            return addedItemName.Text;          
        }

        public string GetInventoryPageAddedItemPrice()
        {
            string priceToString;
            IWebElement addedItemPrice = webDriver.FindElement(sauceDemoInventoryItemOne);
            priceToString = re.Match(addedItemPrice.Text).Value;
            return priceToString;           
        }

        public void ClickAddToCartButtonForFirstItem()
        {
            webDriver.FindElement(sauceDemoInventoryAddToCartButton).Click();                
        }

        public void ClickShoppingCartLink()
        {
            webDriver.FindElement(sauceDemoInventoryShoppingCardLink).Click();
        }
        public void ClickMenuBoxButton()
        {
            webDriver.FindElement(sauceDemoInventoryMenuBox).Click();
        }

        public void ClickLogoutInMenuBox()
        {
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(sauceDemoInventoryMenuBoxLogoutButton)).Click();         
        }

        public void ClickRemoveButtonFirstItem()
        {
            webDriver.FindElement(sauceDemoInventoryButtonForFirstItem).Click();
        }

        public string GetFirstItemAddToCartTextFromButton()
        {
            return webDriver.FindElement(sauceDemoInventoryButtonForFirstItem).Text;
        }

    }
}
