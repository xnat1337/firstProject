using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
    internal class LoginPageSteps
    {
        LoginPage loginPage;       
        public string UsernameInputForLogin = "standard_user";
        public string PasswordInputForLogin = "secret_sauce";
        public string WrongUsernameInputForLogin = "wrong_username";
        public string WrongPasswordInputForLogin = "wrong_password";        
        public LoginPageSteps(IWebDriver webDriver)
        {
            loginPage = new LoginPage(webDriver);
        }

        [Given(@"I navigate to sauce demo login page")]
        public void GivenINavigateToSauceDemoLoginPage()
        {
            loginPage.Load();
        }

        [Given(@"I enter empty username")]
        public void GivenIEnterEmptyUsername()
        {
            loginPage.EnterUsername("");
        }

        [Given(@"I enter valid password")]
        public void GivenIEnterValidPassword()
        {
            loginPage.EnterPassword(PasswordInputForLogin);            
        }

        [When(@"I enter invalid credentials '([^']*)' / '([^']*)'")]
        public void WhenIEnterInvalidCredentials(string username, string password)
        {
            loginPage.EnterUsername(username);
            loginPage.EnterPassword(password);
        }


        [Given(@"I enter login credentials")]
        public void GivenIEnterLoginCredentials()
        { 
            loginPage.EnterUsername("standard_user");
            loginPage.EnterPassword("secret_sauce");
        }

        [When(@"I click submit button")]
        public void WhenIClickSubmitButton()
        {
            loginPage.ClickSubmitButton();
        }

        [Then(@"'([^']*)' message is diplayed")]
        public void ThenMessageIsDiplayed(string error)
        {
            //loginPage.GetErrorForWrongUsernameAndPassword().Should().Contain(error);
            Assert.AreEqual(error, loginPage.GetErrorForWrongUsernameAndPassword());
        }
    }
}
