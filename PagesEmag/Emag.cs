using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumCoreDemo.PagesEmag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace SeleniumCoreDemo.Tests
{
    internal class Emag
    {
        public IWebDriver webDriver;
        public WebDriverWait wait;
        public Actions action;
        int price;

        string urlEmag = "https://www.emag.bg/homepage?ref=emag_CMP-279376_crazy-summer-days-28-06-01-07-2022";
        public By emagBackToFrontPageButton = By.XPath("//div[@class='header-back']");

        [SetUp]
        public void SetUp()
        {
            webDriver = new ChromeDriver();
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(20));
            action = new Actions(webDriver);
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl(urlEmag);
        }


        [TearDown]
        public void CleanUp() 
        { 
           // webDriver.Quit(); 
        }


        [Test]
        
        public void VerifyShoppingCartShowsMultipleItems()
        {
            EmagFrontPage frontPage = new EmagFrontPage(webDriver);
            EmagSearchedResultPage resultPage = new EmagSearchedResultPage(webDriver);
            frontPage.EnterTextInSearchBox();
            frontPage.ClickSearchBoxSubmitButton();

            resultPage.ScrollAndClick240Hz();
            resultPage.WaitFor240HzToLoadThePage();
            resultPage.FindAndClickPriceDropBox();
            resultPage.SelectFilterByLowPriceFromDropDownMenu();
            resultPage.CloseCookiesPopUp();
            Thread.Sleep(2000);
            resultPage.AddSecondItemToCart();
            resultPage.CloseWindowForAddedItem();
            resultPage.AddThirdItemToCart();
            resultPage.CloseWindowForAddedItem();
            resultPage.HoverTheShoppingCart();
            Thread.Sleep(2000);
            string secondItemFromResult = resultPage.GetSecondNumberPrice();
            string thirdItemFromResult = resultPage.GetThirdNumberPrice();
            float secondItemPrice = float.Parse(secondItemFromResult);
            float thirdItemPrice = float.Parse(thirdItemFromResult);
            float totalPrice = secondItemPrice + thirdItemPrice;

            string shoppingCartSecondItemPrice = resultPage.GetSecondItemPriceFromShoppingCart();
            string shoppingCartThirdItemPrice = resultPage.GetThirdItemPriceFromShoppingCart();
            float shoppingCartSecondItemPriceToFloat = float.Parse(shoppingCartSecondItemPrice);
            float shoppingCartThirdItemPriceToFloat = float.Parse(shoppingCartThirdItemPrice);
            float shoppingCartTotalPrice = shoppingCartSecondItemPriceToFloat + shoppingCartThirdItemPriceToFloat;

            Assert.AreEqual(secondItemPrice, shoppingCartSecondItemPriceToFloat);
            Assert.AreEqual(thirdItemPrice, shoppingCartThirdItemPriceToFloat);
            Assert.AreEqual(totalPrice, shoppingCartTotalPrice);
        }

        [Test]

        public void VerifyTheTotalResultsSumIsCorrect()
        {
            EmagFrontPage frontPage = new EmagFrontPage(webDriver);
            EmagSearchedResultPage searchedResultsPage = new EmagSearchedResultPage(webDriver);
            frontPage.ClickCategoryComputersAndPeripherial();
            frontPage.ClickCategoryComputersAndPeripherialGPU();

            searchedResultsPage.ClickCollapseSeeMore();
            Thread.Sleep(1000);
            searchedResultsPage.CloseCookiesPopUp();
            searchedResultsPage.CloseLoginContainer();
            int totalResultsNumber = searchedResultsPage.GetTotalResultsNumber();
            int totalSumNumber = searchedResultsPage.GetNumberForEachItem();
            Assert.AreEqual(totalResultsNumber, totalSumNumber);           
        }

        [Test]

        public void VerifyMultyCookerSumResultIsCorrect()
        {
            EmagFrontPage frontPage = new EmagFrontPage(webDriver);
            EmagSearchedResultPage searchedResultsPage = new EmagSearchedResultPage(webDriver);

            frontPage.ClickCategorySmallGadgets();
            frontPage.ClickCategorySmallGadgetsMultyCooker();

            int totalResultNumber = searchedResultsPage.GetTotalNumberResultsForMultyCooker();
            int sideBarTotalNumber = searchedResultsPage.GetNumbersFromSideBarForMultyCooker();
            Assert.AreEqual(totalResultNumber, sideBarTotalNumber);
        }
    }
}
