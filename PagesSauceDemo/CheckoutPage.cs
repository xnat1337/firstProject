using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCoreDemo.Pages
{
    internal class CheckoutPage
    {
        IWebDriver webDriver;
        public By sauceDemoCartCheckout = By.XPath("//button[contains(text(), 'Checkout')]");
        public By sauceDemoCartCheckoutFirstName = By.XPath("//input[@data-test = 'firstName']");
        public By sauceDemoCartCheckoutLastName = By.XPath("//input[@data-test = 'lastName']");
        public By sauceDemoCartCheckoutPostalCode = By.XPath("//input[@data-test = 'postalCode']");
        public By sauceDemoCartCheckoutContinueButton = By.XPath("//input[@data-test = 'continue']");
        public By sauceDemoCheckoutOverviewFinishButton = By.XPath("//button[@name = 'finish']");
        public By sauceDemoCheckoutComplete = By.XPath("//h2[contains(text(), 'THANK YOU FOR YOUR ORDER')]");
        public By sauceDemoCheckoutItemName = By.XPath("//div[@class = 'inventory_item_name']");
        public By sauceDemoCheckoutItemQuantity = By.XPath("//div[@class = 'cart_quantity']");
        public By sauceDemoCheckoutItemPrice = By.XPath("//div[@class = 'inventory_item_price']");
        public string sauceDemoCartCheckoutFirstNameInput = "Pavel";
        public string sauceDemoCartCheckoutLastNameInput = "Ivanov";
        public string sauceDemoCartCheckoutPostalCodeInput = "7001";

        public CheckoutPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void EnterFirstName(string firstName)
        {
            IWebElement firstNameInput = webDriver.FindElement(sauceDemoCartCheckoutFirstName);
            firstNameInput.SendKeys(firstName);
        }

        public void EnterLastName(string lastName)
        {
            IWebElement lastNameInput = webDriver.FindElement(sauceDemoCartCheckoutLastName);
            lastNameInput.SendKeys(lastName);

        }

        public void EnterPostalCode(string postalCode)
        {
            IWebElement postalCodeInput = webDriver.FindElement(sauceDemoCartCheckoutPostalCode);
            postalCodeInput.SendKeys(postalCode);
        }

        public void ClickContinueButton()
        {
            webDriver.FindElement(sauceDemoCartCheckoutContinueButton).Click();
        }
    }
}
