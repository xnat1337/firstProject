using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace seleniumcoredemo.hooks
{
    [Binding]
    internal class Hooks
    {
        public IWebDriver webDriver;
        public WebDriverWait wait;
        public Actions action;
        private readonly IObjectContainer objectContainer;
        public Hooks(IObjectContainer objectcontainer)
        {
            this.objectContainer = objectcontainer;
        }

        [BeforeScenario]
        public void SetUp()
        {
            webDriver = new ChromeDriver();
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(20));
            action = new Actions(webDriver);
            webDriver.Manage().Window.Maximize();

            objectContainer.RegisterInstanceAs(webDriver);
        }

        [AfterScenario]
        public void CleanUp()
        {
            webDriver.Quit();
        }
    }
}
