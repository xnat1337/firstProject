using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;


namespace SeleniumCoreDemo.PagesEmag
{
    internal class EmagFrontPage
    {
        IWebDriver webDriver;
        WebDriverWait wait;
        By emagBackToFrontPageButton = By.XPath("//div[@class='header-back']/a");
        By emagSearchBox = By.XPath("//input[@type='search']");
        By emagSearchBoxSubmitButton = By.XPath("//i[@class='em em-search']");
        By emagLcdAndLedSearchBox = By.XPath("//ul[@class='nav nav-searchbox searchbox-suggestions-list']/li[2]");
        By emagCategoriesComputersAndPeripherials = By.XPath("//li[@data-modified='1652709880']");
        By emagCategoriesComputersAndPeripherialsGPU = By.XPath("//a[@data-id='3575']");
        By emagCategoriesSmallGadgets = By.XPath("//span[@class='megamenu-list-department__department-name' and text()='Малки електроуреди']");
        By emagCategoriesSmallGadgetsMultycooker = By.XPath("//a[@data-id='3649']");
        string searchBoxText = "монитор";


        public EmagFrontPage(IWebDriver webDriver) { this.webDriver = webDriver; }

        public void ClickButtonToHomePage()
        {
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(emagBackToFrontPageButton)).Click();
        }

        public void EnterTextInSearchBox()
        {
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementExists(emagSearchBox)).SendKeys(searchBoxText);
        }

        public void ClickSearchBoxSubmitButton()
        {
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(emagLcdAndLedSearchBox)).Click();
        }

        public void ClickCategoryComputersAndPeripherial()
        {
            webDriver.FindElement(emagCategoriesComputersAndPeripherials).Click();
        }
        
        public void ClickCategoryComputersAndPeripherialGPU()
        {
            webDriver.FindElement(emagCategoriesComputersAndPeripherialsGPU).Click();
        }

        public void ClickCategorySmallGadgets()
        {
            webDriver.FindElement(emagCategoriesSmallGadgets).Click();
        }

        public void ClickCategorySmallGadgetsMultyCooker()
        {
            webDriver.FindElement(emagCategoriesSmallGadgetsMultycooker).Click();
        }
    }
}
