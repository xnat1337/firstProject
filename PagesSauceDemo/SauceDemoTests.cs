using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumCoreDemo.Pages;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeleniumCoreDemo
{
    public class SauceDemoTests
    {
        public IWebDriver webDriver;
        public WebDriverWait wait;
        public Actions action;
        public string urlSauceDemo = "http://saucedemo.com";
        public string urlSauceDemoInventory = "https://www.saucedemo.com/inventory.html";
        public By sauceDemoUsernameInput = By.XPath("//div[@class = 'form_group']//input[@id = 'user-name']");
        public By sauceDemoPasswordInput = By.XPath("//div[@class = 'form_group']//input[@id = 'password']");
        public By sauceDemoSubmitButton = By.XPath("//input[@type = 'submit']");
        public By sauceDemoUsernameError = By.XPath("//h3[contains(text(), 'Epic sadface: Username is required')]");
        public By sauceDemoPasswordError = By.XPath("//h3[contains(text(), 'Epic sadface: Password is required')]");
        public By sauceDemoWrongUsernameAndPasswordError = By.XPath("//h3[contains(text(), 'Epic sadface: Username and password do not match any user in this service')]");
        public By sauceDemoInventoryMenuBox = By.XPath("//div[@class = 'bm-burger-button']");
        public By sauceDemoInventoryMenuBoxLogoutButton = By.XPath("//a[contains(text(), 'Logout')]");
        public By sauceDemoFrontPageAcceptanceOfNames = By.XPath("//h4[contains(text(), 'Accepted usernames are:')]");
        public By sauceDemoInventoryAddToCartButton = By.XPath("//div[@class = 'inventory_item'][1]//*[contains(text(), 'Add to cart')]");
        public By sauceDemoInventoryShoppingCardLink = By.XPath("//a[@class = 'shopping_cart_link']");
        public By sauceDemoItemPriceInventoryPage = By.XPath("//div[contains(text(), '29.99')]");
        public By sauceDemoItemPriceCartPage = By.XPath("//div[contains(text(), '29.99')]");
        public By sauceDemoInventoryItemName = By.XPath("//div[@class = 'inventory_item'][1]//div[@class = 'inventory_item_name']");
        public By sauceDemoInventoryItemOne = By.XPath("//div[@class = 'inventory_item'][1]");
        public By sauceDemoCartCheckItemName = By.XPath("//div[@class = 'inventory_item_name']");
        public By sauceDemoCartItemPriceCheck = By.XPath("//div[@class = 'item_pricebar']");
        public By SauceDemoCartQuantity = By.XPath("//div[@class = 'cart_quantity']");
        public By sauceDemoCartCheckout = By.XPath("//button[contains(text(), 'Checkout')]");
        public By sauceDemoCartCheckoutFirstName = By.XPath("//input[@data-test = 'firstName']");
        public By sauceDemoCartCheckoutLastName = By.XPath("//input[@data-test = 'lastName']");
        public By sauceDemoCartCheckoutPostalCode = By.XPath("//input[@data-test = 'postalCode']");
        public By sauceDemoCartCheckoutContinueButton = By.XPath("//input[@data-test = 'continue']");
        public By sauceDemoCartRemovedItemEmptyField = By.XPath("//div[@class='removed_cart_item']");
        public By sauceDemoCheckoutOverviewFinishButton = By.XPath("//button[@name = 'finish']");
        public By sauceDemoCheckoutComplete = By.XPath("//h2[contains(text(), 'THANK YOU FOR YOUR ORDER')]");
        public By sauceDemoCheckoutItemName = By.XPath("//div[@class = 'inventory_item_name']");
        public By sauceDemoCheckoutItemQuantity = By.XPath("//div[@class = 'cart_quantity']");
        public By sauceDemoCheckoutItemPrice = By.XPath("//div[@class = 'inventory_item_price']");
        public By sauceDemoInventoryButtonForFirstItem = By.XPath("//div[@class='inventory_item'][1]//button");
        public string UsernameInputForLogin = "standard_user";
        public string PasswordInputForLogin = "secret_sauce";
        public string WrongUsernameInputForLogin = "wrong_username";
        public string WrongPasswordInputForLogin = "wrong_password";
        public string sauceDemoWrongUsernameInputForLogin = "asd";
        public string sauceDemoWrongPasswordInputForLogin = "123asd";
        public string CartCheckoutFirstNameInput = "Pavel";
        public string CartCheckoutLastNameInput = "Ivanov";
        public string CartCheckoutPostalCodeInput = "7001";

        [SetUp]
        public void Setup()
        {          
            webDriver = new ChromeDriver();
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(20));
            action = new Actions(webDriver);
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl(urlSauceDemo);
        }


        [TearDown]
        public void CleanUp()
        {
            webDriver.Quit();
        }
       
        [Test]
        public void VerifySauceDemoItemPriceIsRightThroughWholePurchaseProcess_Refactored()
        {
            LoginPage loginPage = new LoginPage(webDriver);
            loginPage.EnterUsername(UsernameInputForLogin);
            loginPage.EnterPassword(PasswordInputForLogin);
            loginPage.ClickSubmitButton();

            InventoryPage inventoryPage = new InventoryPage(webDriver);
            string addedItemName = inventoryPage.GetInventoryPageAddedItemName();
            string addedItemPrice = inventoryPage.GetInventoryPageAddedItemPrice();
            inventoryPage.ClickAddToCartButtonForFirstItem();
            inventoryPage.ClickShoppingCartLink();

            CartPage cartPage = new CartPage(webDriver);
            string cartItemName = cartPage.GetCartItemName();
            string cartItemPrice = cartPage.GetCartItemPrice();
            string cartItemQuantity = cartPage.GetCartQuantity();

            Assert.AreEqual(addedItemPrice, cartItemPrice);
            Assert.AreEqual(cartItemQuantity, "1");
            Assert.AreEqual(addedItemName, cartItemName);

            cartPage.ClickCheckoutButton();

            CheckoutPage checkoutPage = new CheckoutPage(webDriver);
            checkoutPage.EnterFirstName(CartCheckoutFirstNameInput);
            checkoutPage.EnterLastName(CartCheckoutLastNameInput);
            checkoutPage.EnterPostalCode(CartCheckoutPostalCodeInput);
            checkoutPage.ClickContinueButton();

            CheckoutOverviewPage checkoutOverviewPage = new CheckoutOverviewPage(webDriver);
            string itemName = checkoutOverviewPage.GetOverviewItemName();
            string itemPrice = checkoutOverviewPage.GetOverviewItemPrice();
            string itemQuantity = checkoutOverviewPage.GetOverviewItemQuantity();

            Assert.AreEqual(addedItemPrice, itemPrice);
            Assert.AreEqual(itemQuantity, "1");
            Assert.AreEqual(addedItemName, itemName);

            checkoutOverviewPage.ClickFinishButton();

            CheckoutCompletePage checkoutCompletePage = new CheckoutCompletePage(webDriver);
            string completeMessage = checkoutCompletePage.GetCheckoutCompleteMessage();
            Assert.That(completeMessage == "THANK YOU FOR YOUR ORDER");
        }

        [Test]

        public void VerifySauceDemoLoginWithCorrectUserPasswordWorks()
        {
            LoginPage loginPage = new LoginPage(webDriver);
            loginPage.EnterUsername(UsernameInputForLogin);
            loginPage.EnterPassword(PasswordInputForLogin);
            loginPage.ClickSubmitButton();
            Assert.AreEqual(webDriver.Url, urlSauceDemoInventory);
        }

        [Test]

        public void VerifySauceDemoRequireUsernameInputForLogin()
        {
            LoginPage loginPage = new LoginPage(webDriver);
            loginPage.EnterUsername("");
            loginPage.EnterPassword(PasswordInputForLogin);
            loginPage.ClickSubmitButton();
            string usernameError = loginPage.GetErrorForUsernameLogin();
            Assert.That(usernameError == "Epic sadface: Username is required");
        }

        [Test]

        public void VerifySauceDemoRequirePasswordInputForLogin()
        {
            LoginPage loginPage = new LoginPage(webDriver);
            loginPage.EnterUsername(UsernameInputForLogin);
            loginPage.EnterPassword("");
            loginPage.ClickSubmitButton();
            var errorPasswordRequired = loginPage.GetErrorForPasswordLogin();
            Assert.AreEqual(errorPasswordRequired, "Epic sadface: Password is required");
        }

        [Test]
        public void VerifySauceDemoWrongUsernameAndPasswordShowCorrectError()
        {
            LoginPage loginPage = new LoginPage(webDriver);
            loginPage.EnterUsername(WrongUsernameInputForLogin);
            loginPage.EnterPassword(WrongPasswordInputForLogin);
            loginPage.ClickSubmitButton();
            string errorWrongUsernameAndPassword = loginPage.GetErrorForWrongUsernameAndPassword();
            Assert.AreEqual(errorWrongUsernameAndPassword, "Epic sadface: Username and password do not match any user in this service");
        }   

        [Test]

        public void VerifySauceDemoLogoutWork()
        {
            LoginPage loginPage = new LoginPage(webDriver);
            InventoryPage inventoryPage = new InventoryPage(webDriver);
            loginPage.EnterUsername(UsernameInputForLogin);
            loginPage.EnterPassword(PasswordInputForLogin);
            loginPage.ClickSubmitButton();
            inventoryPage.ClickMenuBoxButton();
            inventoryPage.ClickLogoutInMenuBox();
            string acceptanceNames = loginPage.GetAcceptanceNamesText();
            Assert.AreEqual(acceptanceNames, "Accepted usernames are:");
        }

        [Test]

        public void VerifyFirstItemAtInventoryPageCanBeRemovedFromButton()
        {
            LoginPage loginPage = new LoginPage(webDriver);
            loginPage.EnterUsername(UsernameInputForLogin);
            loginPage.EnterPassword(PasswordInputForLogin);
            loginPage.ClickSubmitButton();

            InventoryPage inventoryPage = new InventoryPage(webDriver);
            inventoryPage.ClickAddToCartButtonForFirstItem();
            inventoryPage.ClickRemoveButtonFirstItem();
            string getFirstItemAddToCartText = inventoryPage.GetFirstItemAddToCartTextFromButton();
            Assert.AreEqual(getFirstItemAddToCartText, "ADD TO CART");
        }

        [Test]

        public void VerifyFirstItemAtCartPageCanBeRemovedFromButton()
        {
            LoginPage loginPage = new LoginPage(webDriver);
            loginPage.EnterUsername(UsernameInputForLogin);
            loginPage.EnterPassword(PasswordInputForLogin);
            loginPage.ClickSubmitButton();

            InventoryPage inventoryPage = new InventoryPage(webDriver);
            inventoryPage.ClickAddToCartButtonForFirstItem();
            inventoryPage.ClickShoppingCartLink();

            CartPage cartPage = new CartPage(webDriver);     
            cartPage.ClickRemoveButtonForFirstItem();
            bool removedItemEmptyField = cartPage.IsRemovedItemEnabled();         
            Assert.IsTrue(removedItemEmptyField);
        }
    }
}
