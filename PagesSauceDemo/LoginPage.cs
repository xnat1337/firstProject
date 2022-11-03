using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCoreDemo.Pages
{
    internal class LoginPage
    {
        IWebDriver webDriver;
        public By sauceDemoUsernameInput = By.XPath("//div[@class = 'form_group']//input[@id = 'user-name']");
        public By sauceDemoPasswordInput = By.XPath("//div[@class = 'form_group']//input[@id = 'password']");
        public By sauceDemoSubmitButton = By.XPath("//input[@type = 'submit']");
        public By sauceDemoUsernameError = By.XPath("//h3[contains(text(), 'Epic sadface: Username is required')]");
        public By sauceDemoPasswordError = By.XPath("//h3[contains(text(), 'Epic sadface: Password is required')]");
        //public By sauceDemoWrongUsernameAndPasswordError = By.XPath("//h3[contains(text(), 'Epic sadface: Username and password do not match any user in this service')]");
        public By sauceDemoWrongUsernameAndPasswordError = By.XPath("//h3");
        public By sauceDemoFrontPageAcceptanceOfNames = By.XPath("//h4[contains(text(), 'Accepted usernames are:')]");
        public string WrongUsernameInputForLogin = "wrong_username";
        public string WrongPasswordInputForLogin = "wrong_password";
        public string urlSauceDemo = "http://saucedemo.com";

        public LoginPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void Load()
        {
            webDriver.Navigate().GoToUrl(urlSauceDemo);
        }

        public void IsLoaded()
        {
            Assert.AreEqual(webDriver.Url, urlSauceDemo);
        }

        public void EnterUsername(string username)
        {
            webDriver.FindElement(sauceDemoUsernameInput).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
             webDriver.FindElement(sauceDemoPasswordInput).SendKeys(password);
        }

        public void ClickSubmitButton()
        {
            webDriver.FindElement(sauceDemoSubmitButton).Click();          
        }

        public string GetErrorForUsernameLogin()
        {
            return webDriver.FindElement(sauceDemoUsernameError).Text;
        }

        public string GetErrorForPasswordLogin()
        {
            return webDriver.FindElement(sauceDemoPasswordError).Text;           
        }        

        public string GetErrorForWrongUsernameAndPassword()
        {
            return webDriver.FindElement(sauceDemoWrongUsernameAndPasswordError).Text.Trim();
        }

        public string GetAcceptanceNamesText()
        {
             return webDriver.FindElement(sauceDemoFrontPageAcceptanceOfNames).Text;
        }
    }
}
