using OpenQA.Selenium;
using SeleniumCoreDemo.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SeleniumCoreDemo.Steps
{
    [Binding]
    internal class InventoryPageSteps
    {
        InventoryPage inventoryPage;

        public InventoryPageSteps(IWebDriver webDriver)
        {
            inventoryPage = new InventoryPage(webDriver);
        }

        [Then(@"I see inventory page")]
        public void ThenISeeInventoryPage()
        {
            inventoryPage.IsLoaded();
        }

    }
}
