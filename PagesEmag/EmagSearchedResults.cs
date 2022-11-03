using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Threading;
using System.Windows;
using System.Text.RegularExpressions;

namespace SeleniumCoreDemo.PagesEmag
{
    internal class EmagSearchedResultPage
    {
        IWebDriver webDriver;
        Action action;
        WebDriverWait wait;
        By emagMonitorPage240HzCheckbox = By.XPath("//a[@data-name='240 Hz']");
        By filterDropDownForPrice = By.XPath("//div[@class='sort-control-btn-dropdown hidden-xs']");
        By dropDownMenuSelected = By.XPath("//*[contains(text(),'Цена низх.')]");
        By breadCrumbsFor240Hz = By.XPath("//li[@class='active']/span[contains(text(),'240 Hz')]");
        By addToCartButtonForSecondItem = By.XPath("//button[@data-pnk='DJV19TMBM']");
        By addToCartButtonForThirdItem = By.XPath("//button[@data-pnk='D83LB6BBM']");
        By cookiesAcceptButton = By.XPath("//button[@class='btn btn-primary js-accept gtm_h76e8zjgoo btn-block']");
        By closeWindowForAddedItem = By.XPath("//i[@class='em em-close gtm_6046yfqs']");
        By hoverShoppingCart = By.XPath("//i[@class='em em-cart2 navbar-icon']");
        By shoppingCartShowsTwoItemsAdded = By.XPath("//span[@class='nav-product-total-pieces']");
        By secondItemPrice = By.XPath("//div[@data-offer-id='69975535']//p[@class='product-new-price']");
        By thirdItemPrice = By.XPath("//div[@data-offer-id='47979487']//p[@class='product-new-price']");
        By shoppingCartSecondItemPrice = By.XPath("//div[@class='nav-product-container '][1]//p[@class='product-new-price']");
        By shoppingCartThirdItemPrice = By.XPath("//div[@class='nav-product-container '][2]//p[@class='product-new-price']");
        By searchedResultsCollapseSeeMore = By.XPath("//a[@data-ph-target='#js-tree-sdp-pc-komponenti-collapse']");
        By totalResultsNumber = By.XPath("//a[@class='js-sidebar-tree-top-head sidebar-tree-head']");
        By closeWindowForLogin = By.XPath("//div[@class='gdpr-cookie-banner js-gdpr-cookie-banner pad-sep-xs pad-hrz-none login-view login-view-bg show']//i");
        By sideBarTreeResults = By.XPath("//div[@class='sidebar-tree-body']//a/small");
        By totalResultsForMultyCooker = By.XPath("//span[@class='title-phrasing title-phrasing-sm']");
        By sideBarNumbersForMultyCooker = By.XPath("//div[@data-filter-id='6412']//div[@class='filter-body js-scrollable']/a/span");

        public EmagSearchedResultPage(IWebDriver webDriver){this.webDriver = webDriver;}


        public void ScrollAndClick240Hz()
        {
            webDriver.FindElement(emagMonitorPage240HzCheckbox).Click();
        }

        public void FindAndClickPriceDropBox()
        {           
            IWebElement dropDownMenu = webDriver.FindElement(filterDropDownForPrice);
            new Actions(webDriver).ScrollToElement(dropDownMenu).Perform();
            dropDownMenu.Click();
        }

        public void SelectFilterByLowPriceFromDropDownMenu()
        {
            webDriver.FindElement(dropDownMenuSelected).Click();
        }

        public void WaitFor240HzToLoadThePage()
        {
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(breadCrumbsFor240Hz));
        }

        public void CloseCookiesPopUp()
        {
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(cookiesAcceptButton)).Click();
        }

        public void AddSecondItemToCart()
        {
            webDriver.FindElement(addToCartButtonForSecondItem).Click();
        }

        public void AddThirdItemToCart()
        {
            webDriver.FindElement(addToCartButtonForThirdItem).Click();
        }

        public void CloseWindowForAddedItem()
        {
            wait.Until(ExpectedConditions.ElementExists(closeWindowForAddedItem)).Click();
        }

        public void HoverTheShoppingCart()
        {
            IWebElement hover = webDriver.FindElement(hoverShoppingCart);
            new Actions(webDriver).MoveToElement(hover).Perform();
        }

        public string GetNumberOfAddedItemsInShoppingCart()
        {
            return webDriver.FindElement(shoppingCartShowsTwoItemsAdded).Text;
        }

        public string GetSecondNumberPrice()
        {
            Regex re = new Regex(@"[0-9][0-9]?\.[0-9][0-9][0-9]");
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            string price;
            IWebElement itemPrice = wait.Until(ExpectedConditions.ElementIsVisible(secondItemPrice));
            price = re.Match(itemPrice.Text).Value;
            return price;                    
        }

        public string GetThirdNumberPrice()
        {
            Regex re = new Regex(@"[0-9][0-9]?\.[0-9][0-9][0-9]");
            string price;
            IWebElement itemPrice = webDriver.FindElement(thirdItemPrice);
            price = re.Match(itemPrice.Text).Value;
            return price;
        }

        public string GetSecondItemPriceFromShoppingCart()
        {
            Regex re = new Regex(@"[0-9][0-9]?\.[0-9][0-9][0-9]");
            string price;
            IWebElement itemPrice = webDriver.FindElement(shoppingCartSecondItemPrice);
            price = re.Match(itemPrice.Text).Value;
            return price;
        }

        public string GetThirdItemPriceFromShoppingCart()
        {
            Regex re = new Regex(@"[0-9][0-9]?\.[0-9][0-9][0-9]");
            string price;
            IWebElement itemPrice = webDriver.FindElement(shoppingCartThirdItemPrice);
            price = re.Match(itemPrice.Text).Value;
            return price;
        }

        public void ClickCollapseSeeMore()
        {
            webDriver.FindElement(searchedResultsCollapseSeeMore).Click();
        }

        public int GetTotalResultsNumber()
        {
            int result;
            Regex re = new Regex(@"[0-9]+");
            IWebElement totalResult =  webDriver.FindElement(totalResultsNumber);
            result = Int32.Parse(re.Match(totalResult.Text).Value);
            
            return result;
        }

        public void CloseLoginContainer()
        {
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(closeWindowForLogin)).Click();
        }

        public int GetNumberForEachItem()
        {
            Regex re = new Regex(@"[0-9]+");
            int sum = 0;
            IList<IWebElement> itemList = webDriver.FindElements(sideBarTreeResults);
            foreach (var item in itemList)
            {
                string itemText = item.Text;
                string itemTextRegex = re.Match(itemText).Value;
                int itemTextInt = int.Parse(itemTextRegex);

                int itemNumber = Int32.Parse(re.Match(item.Text).Value);
                sum = sum + itemNumber;
            }
                return sum;
        }

        public int GetTotalNumberResultsForMultyCooker()
        {
            Regex re = new Regex(@"[0-9]+");
            int result;
            IWebElement multyCookerResult = webDriver.FindElement(totalResultsForMultyCooker);
            result = Int32.Parse(re.Match(multyCookerResult.Text).Value);
            return result;
        }

        public int GetNumbersFromSideBarForMultyCooker()
        {
            Regex re = new Regex(@"[0-9]+");
            int sum = 0;
            IList<IWebElement> itemsList = webDriver.FindElements(sideBarNumbersForMultyCooker);
            foreach(var item in itemsList)
            {
                int itemNumber = Int32.Parse(re.Match(item.Text).Value);
                sum = sum + itemNumber;
            }
            return sum;
        }


    }
}
