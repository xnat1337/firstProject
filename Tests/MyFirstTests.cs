using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumCoreDemo.Pages;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;

namespace SeleniumCoreDemo
{
    public class MyFirstTests
    {
        public IWebDriver webDriver;
        public WebDriverWait wait;
        public Actions action;

        public string urlEeaap = "http://eaapp.somee.com/";
        public string urlEeaapKarthik = "https://www.udemy.com/user/karthik-kk/";
        public string urlEeaapAccountRegister = "http://eaapp.somee.com/Account/Register";
        public string urlYoutube = "http://youtube.com";
        public string urlYoutubeChannelExecuteAutomation = "https://www.youtube.com/executeautomation";
        public string urlDemoqa = "http://demoqa.com";
        public string urlOlx = "http://olx.bg";
        public string urlDemoqaLoader = "http://demo.automationtesting.in/Loader.html";
        public string urlSauceDemo = "http://saucedemo.com";
        public string urlSauceDemoInventory = "https://www.saucedemo.com/inventory.html";
        public By eeaaploginButton = By.LinkText("Login");
        public By eeaapInputUsername = By.Name("UserName");
        public By eeaapInputPassword = By.Name("Password");
        public By eeaapButtonLogin = By.XPath("//input[@value='Log in']");
        public By eeaapEmployeeDetailsLink = By.LinkText("Employee Details");
        public By eeaapByudemyButton = By.LinkText("Udemy");
        public By youtubeYoutubeButton = By.LinkText("YouTube");
        public By youtubeYoutubeCookiePass = By.XPath("//span[text()='Reject all']");
        public By eeaapEmployeeList = By.LinkText("Employee List");
        public By eeaapNumRowsList = By.TagName("tr");
        public By eeaapAboutButton = By.LinkText("About");
        public By eeaapText = By.XPath("//*[text() = 'ExecuteAutomation Employee Application v1.0 is a simple web application for showing very few functionality of Employee details.']");
        public By eeaapRegisterButton = By.XPath("//*[@id='registerLink']");
        public By eeaapInputUserName = By.XPath("//*[@id='UserName']");
        public By eeaapinputPassword = By.XPath("//*[@id='Password']");
        public By eeaapInputConfirmPassword = By.XPath("//*[@id='ConfirmPassword']");
        public By eeaapInputEmail = By.XPath("//*[@id='Email']");
        public By eeaapButtonRegister = By.Id("registerLink");
        public By eeaapHeaderRegister = By.XPath("//h2[contains(text(), 'Register.')]");
        public By eeaapHeaderCreateNewAcc = By.XPath("//h4[contains(text(), 'Create a new account.')]");
        public By eeaapLinkRegisterAsNewUser = By.XPath("//a[contains(text(), 'Register as a new user')]");
        public By eeaapShowCreateANewAccount = By.XPath("//h4[contains(text(), 'Create a new account.')]");
        public By eeaapLinkEmployeeList = By.XPath("//a[contains(text(), 'Employee List')]");
        public By eeaapSearchName = By.XPath("//input[@name = 'searchTerm']");
        public By eeaapButtonSearch = By.XPath("//input[@value = 'Search']");
        public By eeaapTableRow = By.TagName("tr");
        public By eeaapLinkLogin = By.Id("loginLink");
        public By eeaapInputButtonLogin = By.XPath("//input[@value = 'Log in']");
        public By eeaapLinkLogOff = By.XPath("//a[contains(text(), 'Log off')]");
        public By eeaapLinkManageUsers = By.XPath("//a[contains(text(), 'Manage Users')]");
        public By eeaapListOfUsers = By.TagName("tr");
        public By eeaapLinkHelloMyName = By.XPath("//a[contains(text(), 'Hello admin!')]");
        public By demoqaButtonElements = By.XPath("//h5[contains(text(), 'Elements')]");
        public By demoqaButtonTextBox = By.XPath("//span[contains(text(), 'Text Box')]");
        public By demoqaInputFullName = By.Id("userName");
        public By demoqaInputEmail = By.Id("userEmail");
        public By demoqaInputCurrentAdress = By.Id("currentAddress");
        public By demoqaSubmitResultPermanentAddress = By.XPath("//div[@class = 'border col-md-12 col-sm-12']//p[@id = 'permanentAddress']");
        public By demoqaInputPermanentAdress = By.Id("permanentAddress");
        public By demoqaButtonSubmit = By.Id("submit");
        public By demoqaButtonInteractions = By.XPath("//h5[contains(text(), 'Interactions')]");
        public By demoqaButtonDraggable = By.XPath("//span[contains(text(), 'Droppable')]");
        public By demoqaBoxDragMe = By.Id("draggable");
        public By demoqaSubmitResultName = By.Id("name");
        public By demoqaSubmitResultEmail = By.Id("email");
        public By demoqaBoxDropHere = By.XPath("//*[@id = 'droppable']/p[contains(text(), 'Drop here')]");
        public By demoqaBoxDroppedList = By.XPath("//p[contains(text(), 'Dropped')]");
        public By demoqaLoaderButtonRun = By.XPath("//*[@id='loader']");
        public By demoqaLoaderLoadingWindow = By.XPath("//h1[contains(text(), 'Please wait...')]");
        public By demoqaLoaderModalWindow = By.XPath("//div[@class = 'modal-body']");
        public By olxCookiesAccept = By.Id("onetrust-accept-btn-handler");
        public By olxButtonUkraine = By.XPath("//div[@class = 'sitepopularbox__wrapper']//span[contains(text(), 'Помощ за Украйна | Допомога Україні')]");
        public By olxChoosenCategory = By.XPath("//div[@class = 'css-1a9sj2a']");
        public By olxSearchBoxMainPage = By.Name("q");
        public By olxTotalResultsFoundRtx = By.XPath("//div[@data-testid = 'total-count']");
        public By olxSearchBoxSearchResultsPage = By.Id("search");
        public By youtubeYoutubeCookie = By.XPath("//tp-yt-paper-button[@id = 'button']//*[contains(text(), 'Reject all')]");
        public By youtubeYoutubeSearchBox = By.XPath("//div[@id = 'search-input']//*[@id = 'search']");
        public By youtubeSubscribersChannel = By.Id("subscribers");


        //Hooks in NUnit
        [SetUp]
        public void Setup()
        {
            webDriver = new ChromeDriver();
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(20));
            action = new Actions(webDriver);
            webDriver.Manage().Window.Maximize();

        }

        [TearDown]
        public void CleanUp()
        {
            //webDriver.Quit();
        }

        [Test]
        public void PersonTest()
        {
            Person person1 = new Person(10, "Niki");
        }

        [Test]

        public void Car()
        {
            Car car1 = new Car(500, 10, "Blue", 10, 2000);
            car1.Steer("left");
            car1.CarStop();
            car1.SetColor("Red");
            car1.SetTravelDistance("40");
            car1.SetCarAge(5);
            int currentCarAge = car1.GetCarAge();
            string currentCarColor = car1.GetCarColor();
            var currentTravelDistance = car1.GetTraveLdistance();
            int currentWeight = car1.GetWeight();

            Console.WriteLine("Color is " + currentCarColor);
            Console.WriteLine("Car Travel Distance is " + currentTravelDistance);
            Console.WriteLine("Weight is " + currentWeight);
            Console.WriteLine("Car age is " + currentCarAge);


            Assert.AreEqual("Red", currentCarColor);
            Assert.AreEqual(40, currentTravelDistance);
        }

        [Test]

        public void GamingMouse()
        {
            Mouse gamingMouse1 = new Mouse("", 0, 0, "Black");
            gamingMouse1.SetWeight(67);
            gamingMouse1.SetSize(124);
            gamingMouse1.SetColor("MatteWhite");
            gamingMouse1.DisplayShape();
            gamingMouse1.ButtonClick("Left-click");
            int currentWeight = gamingMouse1.GetWeight();
            int currentSize = gamingMouse1.GetSize();
            string currentColor = gamingMouse1.GetColor();
            Console.WriteLine("Mouse weight is: " + currentWeight);
            Console.WriteLine("Mouse size is: " + currentSize);
            Console.WriteLine("Mouse color is: " + currentColor);
        }

        [Test]

        public void Keyboard()
        {
            Keyboard gamingKeyboard1 = new Keyboard();
            gamingKeyboard1.SetCost(99);
            gamingKeyboard1.SetBrand("Keychron");
            gamingKeyboard1.SetKeycapType("ABS");
            gamingKeyboard1.SetSwitches("Mechanical");
            gamingKeyboard1.SetSize("65%");
            gamingKeyboard1.SetColor("Black");
            gamingKeyboard1.SetWeight(250);
            gamingKeyboard1.ButtonClick("W");
            int currentWeight = gamingKeyboard1.GetWeight();
            int currentCost = gamingKeyboard1.GetCost();
            string currentColor = gamingKeyboard1.GetColor();
            string currentBrand = gamingKeyboard1.GetBrand();
            string currentKeycapType = gamingKeyboard1.GetKecapType();
            string currentSwitches = gamingKeyboard1.GetSwitches();
            string currentSize = gamingKeyboard1.GetSize();
            Console.WriteLine("The cost is: " + currentCost + " BGN");
            Console.WriteLine("The brand is: " + currentBrand);
            Console.WriteLine("The keycap type is: " + currentKeycapType);
            Console.WriteLine("The switches are: " + currentSwitches);
            Console.WriteLine("The size is: " + currentSize);
            Console.WriteLine("The color is: " + currentColor);
            Console.WriteLine("The weight is: " + currentWeight + " grams.");
        }

        //Reference types, Value types
        [Test]
        public void VerifyCalculatorWorksAsExpected()
        {
            Calculator simpleCalculator = new Calculator();
            simpleCalculator.Sum(9, 1);

            int result = simpleCalculator.Sum2(15, 5);
            Console.WriteLine(result);

            simpleCalculator.Sum3();

            string result2 = simpleCalculator.Sum4();
            Console.WriteLine(result2);

            string result3 = simpleCalculator.Sum5(20, 10);
            Console.WriteLine(result3);

            simpleCalculator.Sum6(5, 35, 999);

            string calculatorAbout = simpleCalculator.GetAboutInformation();
            Console.WriteLine(calculatorAbout);
        }

        [Test]
        public void VerifyEmployeeDetailsLinkIsDisplayed()
        {


            //Navigate to Site
            webDriver.Navigate().GoToUrl(urlEeaap);

            //find login link
            IWebElement loginLink = webDriver.FindElement(eeaaploginButton);

            //click login link
            loginLink.Click();

            //find username input
            IWebElement inputUsername = webDriver.FindElement(eeaapInputUsername);

            //Send text to username input
            inputUsername.SendKeys("admin");

            //find password input
            IWebElement inputPassword = webDriver.FindElement(eeaapInputPassword);

            //Send text to password input
            inputPassword.SendKeys("password");

            //find log in button
            IWebElement buttonLogin = webDriver.FindElement(eeaapButtonLogin);

            //click login button
            buttonLogin.Click();

            //find employee details link
            IWebElement employeeDetailsLink = webDriver.FindElement(eeaapEmployeeDetailsLink);

            //Assert that emplyee details link is displayed
            Assert.That(employeeDetailsLink.Displayed, Is.True);

            //Close browser

        }

        [Test]
        public void VerifyUdemyLinkRedirectsToCorrectPage()
        {
            webDriver.Navigate().GoToUrl(urlEeaap);
            IWebElement udemyButton = webDriver.FindElement(eeaapByudemyButton);
            udemyButton.Click();
            Assert.That(webDriver.Url == urlEeaapKarthik);

        }


        [Test]

        public void VerifyYoutubeButtonLink()
        {
            webDriver.Navigate().GoToUrl(urlEeaap);

            IWebElement youtubeButton = webDriver.FindElement(youtubeYoutubeButton);

            youtubeButton.Click();

            IWebElement youtubeCookiePass = webDriver.FindElement(youtubeYoutubeCookiePass);

            youtubeCookiePass.Click();

            Assert.That(webDriver.Url == urlYoutubeChannelExecuteAutomation);


        }


        [Test]

        public void VerifyEmployeeListSearch()
        {

            webDriver.Navigate().GoToUrl(urlEeaap);

            IWebElement employeeList = webDriver.FindElement(eeaapEmployeeList);

            employeeList.Click();

            IList<IWebElement> numRows = webDriver.FindElements(eeaapNumRowsList);

            Assert.GreaterOrEqual(numRows.Count, 4);


        }

        [Test]

        public void VerifyAboutPageShowCorrectInformation()
        {

            webDriver.Navigate().GoToUrl(urlEeaap);

            IWebElement aboutButton = webDriver.FindElement(eeaapAboutButton);

            aboutButton.Click();

            IWebElement text = webDriver.FindElement(eeaapText);

            Assert.That(text.Displayed);

        }

        [Test]

        public void VerifyRegisterPageShowCorrectInput()//verify register page shows correct inputs(username, password, confirm password, email)
        {


            webDriver.Navigate().GoToUrl(urlEeaap);

            IWebElement registerButton = webDriver.FindElement(eeaapRegisterButton);

            registerButton.Click();

            IWebElement inputUserName = webDriver.FindElement(eeaapInputUserName);

            IWebElement inputPassword = webDriver.FindElement(eeaapinputPassword);

            IWebElement inputConfirmPassword = webDriver.FindElement(eeaapInputConfirmPassword);

            IWebElement inputEmail = webDriver.FindElement(eeaapInputEmail);

            Assert.That(inputUserName.Displayed);
            Assert.That(inputPassword.Displayed);
            Assert.That(inputConfirmPassword.Displayed);
            Assert.That(inputEmail.Displayed);

        }

        [Test]

        public void VerifyRegisterPageContainCorrectHeader() //verify register page contains correct header - "Create a new account."
        {

            webDriver.Navigate().GoToUrl(urlEeaap);

            IWebElement buttonRegister = webDriver.FindElement(eeaapButtonRegister);

            buttonRegister.Click();

            IWebElement headerRegister = webDriver.FindElement(eeaapHeaderRegister);

            IWebElement headerCreateNewAcc = webDriver.FindElement(eeaapHeaderCreateNewAcc);

            Assert.IsTrue(headerRegister.Displayed);

            Assert.That(headerCreateNewAcc.Displayed, Is.True);

        }

        [Test]

        public void VerifyRegisterAsNewUserRedirectToRegisterPage() //verify "register as new user" link in login page redirects to register page
        {

            webDriver.Navigate().GoToUrl(urlEeaap);

            IWebElement buttonLogin = webDriver.FindElement(eeaaploginButton);

            buttonLogin.Click();

            IWebElement linkRegisterAsNewUser = webDriver.FindElement(eeaapLinkRegisterAsNewUser);

            linkRegisterAsNewUser.Click();

            IWebElement showCreateANewAccount = webDriver.FindElement(eeaapShowCreateANewAccount);

            Assert.That(showCreateANewAccount.Displayed, Is.True);

            Assert.That(webDriver.Url == urlEeaapAccountRegister);

        }

        [Test]

        public void VerifySeatchingEmployeeListByNameWorks() //verify searching in employee list by name works
        {

            webDriver.Navigate().GoToUrl(urlEeaap);

            IWebElement linkEmployeeList = webDriver.FindElement(eeaapLinkEmployeeList);

            linkEmployeeList.Click();

            IWebElement searchName = webDriver.FindElement(eeaapSearchName);

            searchName.SendKeys("Karthik");

            IWebElement buttonSearch = webDriver.FindElement(eeaapButtonSearch);

            buttonSearch.Click();

            IList<IWebElement> tableRow = webDriver.FindElements(eeaapTableRow);

            Assert.GreaterOrEqual(tableRow.Count, 2);

        }

        [Test]

        public void VerifyLogin()
        {

            webDriver.Navigate().GoToUrl(urlEeaap);

            IWebElement linkLogin = webDriver.FindElement(eeaapLinkLogin);

            linkLogin.Click();

            IWebElement inputUserName = webDriver.FindElement(eeaapInputUserName);

            inputUserName.SendKeys("admin");

            IWebElement inputPassword = webDriver.FindElement(eeaapInputPassword);

            inputPassword.SendKeys("password");

            IWebElement inputButtonLogin = webDriver.FindElement(eeaapInputButtonLogin);

            inputButtonLogin.Click();

            IWebElement linkLogOff = webDriver.FindElement(eeaapLinkLogOff);

            Assert.That(linkLogOff.Displayed, Is.True);

        }

        [Test]

        public void VerifyManageUsersPageShowsAtLeastFiveResults() //verify manage users page shows at least 5 results
        {

            webDriver.Navigate().GoToUrl(urlEeaap);

            IWebElement linkLogin = webDriver.FindElement(eeaapLinkLogin);

            linkLogin.Click();

            IWebElement inputUserName = webDriver.FindElement(eeaapInputUsername);

            inputUserName.SendKeys("admin");

            IWebElement inputPassword = webDriver.FindElement(eeaapInputPassword);

            inputPassword.SendKeys("password");

            IWebElement inputButtonLogin = webDriver.FindElement(eeaapInputButtonLogin);

            inputButtonLogin.Click();

            IWebElement linkManageUsers = webDriver.FindElement(eeaapLinkManageUsers);

            linkManageUsers.Click();

            IList<IWebElement> listOfUsers = webDriver.FindElements(eeaapListOfUsers);

            Assert.GreaterOrEqual(listOfUsers.Count, 2);

        }

        [Test]

        public void VerifyProfilePageLinkSaysHelloMyName()//verify my profile page link says hello myname
        {

            webDriver.Navigate().GoToUrl(urlEeaap);

            IWebElement linkLogin = webDriver.FindElement(eeaapLinkLogin);

            linkLogin.Click();

            IWebElement inputUserName = webDriver.FindElement(eeaapInputUsername);

            inputUserName.SendKeys("admin");

            IWebElement inputPassword = webDriver.FindElement(eeaapinputPassword);

            inputPassword.SendKeys("password");

            IWebElement inputButtonLogin = webDriver.FindElement(eeaapInputButtonLogin);

            inputButtonLogin.Click();

            IWebElement linkHelloMyName = webDriver.FindElement(eeaapLinkHelloMyName);

            Assert.That(linkHelloMyName.Displayed, Is.True);

        }

        [Test]

        public void VerifyElementsTextBoxTextShows() //demoQA Test1 
        {
            string fullName = "ZdraveyPavka";
            string email = "pavka@gmail.com";
            string currentAdress = "blok21";
            string permanentAdress = "petiEtaj";

            webDriver.Navigate().GoToUrl(urlDemoqa);

            IWebElement buttonElements = webDriver.FindElement(demoqaButtonElements);

            buttonElements.Click();

            IWebElement buttonTextBox = webDriver.FindElement(demoqaButtonTextBox);

            buttonTextBox.Click();

            IWebElement inputFullName = webDriver.FindElement(demoqaInputFullName);

            inputFullName.SendKeys(fullName);

            IWebElement inputEmail = webDriver.FindElement(demoqaInputEmail);

            inputEmail.SendKeys(email);

            IWebElement inputCurrentAdress = webDriver.FindElement(demoqaInputCurrentAdress);

            inputCurrentAdress.SendKeys(currentAdress);

            IWebElement inputPermanentAdress = webDriver.FindElement(demoqaInputPermanentAdress);

            inputPermanentAdress.SendKeys(permanentAdress);

            IWebElement buttonSubmit = webDriver.FindElement(demoqaButtonSubmit);

            buttonSubmit.Click();

            //IWebElement submitResultName = webDriver.FindElement(By.XPath(//p[contains(text(), 'ZdraveyPavka')]));

            //IWebElement submitResultEmail = webDriver.FindElement(By.XPath($"//p[contains(@id,{email})]"));

            //IWebElement submitResultCurrentAdress = webDriver.FindElement(By.XPath($"//p[contains(@id,{currentAdress})]"));

            //IWebElement submitResultPermanentAdress = webDriver.FindElement(By.XPath($"//p[contains(@id,{permanentAdress})]"));

            IWebElement submitResultName = webDriver.FindElement(demoqaSubmitResultName);

            IWebElement submitResultEmail = webDriver.FindElement(demoqaSubmitResultEmail);

            IWebElement submitResultCurrentAddress = webDriver.FindElement(demoqaInputCurrentAdress);

            IWebElement submitResultPermanentAddress = webDriver.FindElement(demoqaSubmitResultPermanentAddress);


            //Assert.That(submitResultName.Displayed, Is.True);
            //Assert.That(submitResultEmail.Displayed, Is.True);
            //Assert.That(submitResultCurrentAdress.Displayed, Is.True);
            //Assert.That(submitResultPermanentAdress.Text == permanentAdress);
            Assert.AreEqual(submitResultName.Text, "Name:" + fullName);
            Assert.AreEqual(submitResultEmail.Text, "Email:" + email);
            Assert.AreEqual(submitResultCurrentAddress.Text, "Current Address :" + currentAdress);
            Assert.AreEqual(submitResultPermanentAddress.Text, "Permananet Address :" + permanentAdress);

        }


        [Test]

        public void VerifyInteractionsDroppableDragAndDropWorks()
        {

            webDriver.Navigate().GoToUrl(urlDemoqa);

            IWebElement buttonInteractions = webDriver.FindElement(demoqaButtonInteractions);

            buttonInteractions.Click();

            IWebElement buttonDroppable = wait.Until(ExpectedConditions.ElementToBeClickable(demoqaButtonDraggable));

            action.ScrollByAmount(0, 1000).Perform();

            buttonDroppable.Click();

            IWebElement boxDragMe = wait.Until(ExpectedConditions.ElementToBeClickable(demoqaBoxDragMe));

            IWebElement boxDropHere = webDriver.FindElement(demoqaBoxDropHere);

            Thread.Sleep(1000);

            action.DragAndDrop(boxDragMe, boxDropHere).Perform();

            IList<IWebElement> boxDropped = webDriver.FindElements(demoqaBoxDroppedList);

            Assert.AreEqual(boxDropped.Count, 1);


        }

        [Test]

        public void VerifyModalTitleWindowShows()
        {

            webDriver.Navigate().GoToUrl(urlDemoqaLoader);

            IWebElement buttonRun = webDriver.FindElement(demoqaLoaderButtonRun);

            buttonRun.Click();

            IWebElement loadingWindow = webDriver.FindElement(demoqaLoaderLoadingWindow);

            IWebElement modalWindow = webDriver.FindElement(demoqaLoaderModalWindow);

            Assert.That(loadingWindow.Displayed);

        }

        //TEST 3
        //1.отвори http://demo.automationtesting.in/Loader.html
        //2.натисни run
        //3.изчакай докато зареди 
        //4.верифицирай че Modal title прозореца се показва

        [Test]

        public void VerifyModalTitleWindowShows1()
        {



            webDriver.Navigate().GoToUrl(urlDemoqaLoader);

            IWebElement buttonRun = webDriver.FindElement(demoqaLoaderButtonRun);

            buttonRun.Click();

            //wait.Until(x => x.FindElement(By.XPath("//div[@class = 'modal-body']")));

            IWebElement modalWindow = wait.Until(ExpectedConditions.ElementIsVisible(demoqaLoaderModalWindow));

            Assert.IsTrue(modalWindow.Displayed);
        }

        [Test]

        public void VerifyOlxCategoryShowsCorrect()
        {

            webDriver.Navigate().GoToUrl(urlOlx);

            IWebElement cookiesAccept = webDriver.FindElement(olxCookiesAccept);

            cookiesAccept.Click();

            IWebElement buttonUkraine = wait.Until(ExpectedConditions.ElementExists(olxButtonUkraine));

            Thread.Sleep(1000);

            buttonUkraine.Click();

            IWebElement choosenCategory = webDriver.FindElement(olxChoosenCategory);

            Assert.AreEqual(choosenCategory.Text, "Помощ за Украйна | Допомога Україні");

        }

        [Test]

        public void VerifyResultShowMoreRtx3070()
        {

            webDriver.Navigate().GoToUrl(urlOlx);

            IWebElement cookieAccept = webDriver.FindElement(olxCookiesAccept);

            cookieAccept.Click();

            IWebElement searchBoxMainPage = webDriver.FindElement(olxSearchBoxMainPage);

            searchBoxMainPage.SendKeys("RTX 3070");

            searchBoxMainPage.SendKeys(Keys.Enter);

            IWebElement totalResultsFoundRtx3070 = webDriver.FindElement(olxTotalResultsFoundRtx);

            Regex re = new Regex(@"[0-9]+");

            var matchesRtx3070 = re.Match(totalResultsFoundRtx3070.Text);

            //totalResultsRtx3070 = new string(totalResultsRtx3070(Char.IsDigit).ToArray(2));

            //int totalResultsRtx3070 = Int32.Parse(totalResultsFoundRtx3070.Text.Trim().Split(" ")[2]);

            IWebElement searchBoxSearchResultsPage = wait.Until(ExpectedConditions.ElementExists(olxSearchBoxSearchResultsPage));

            //Thread.Sleep(2000);

            searchBoxSearchResultsPage.Clear();

            searchBoxSearchResultsPage.SendKeys("6800XT");

            searchBoxSearchResultsPage.SendKeys(Keys.Enter);

            //Thread.Sleep(2000);

            IWebElement totalResultsFound6800Xt = wait.Until(ExpectedConditions.ElementIsVisible(olxTotalResultsFoundRtx));

            Thread.Sleep(1000);

            var matches6800Xt = re.Match(totalResultsFound6800Xt.Text);

            Assert.Greater(Convert.ToInt32(matchesRtx3070.Value), Convert.ToInt32(matches6800Xt.Value));



        }

        [Test]

        public void VerifyYoutubeChannelHasMoreSubs()
        {
            //WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));

            webDriver.Navigate().GoToUrl(urlYoutube);

            IWebElement youtubeCookie = webDriver.FindElement(youtubeYoutubeCookie);

            youtubeCookie.Click();

            IWebElement youtubeSearchBox = webDriver.FindElement(youtubeYoutubeSearchBox);

            youtubeSearchBox.Click();
            youtubeSearchBox.SendKeys("цанов напред и нагоре");

            youtubeSearchBox.SendKeys(Keys.Enter);

            IWebElement subscribersChannel1 = wait.Until(ExpectedConditions.ElementExists(youtubeSubscribersChannel));

            Regex regex = new Regex(@"[0-9]+");

            var totalSubsChannel1 = regex.Match(subscribersChannel1.Text);

            youtubeSearchBox.Clear();

            youtubeSearchBox.SendKeys("любомир жечев");

            youtubeSearchBox.SendKeys(Keys.Enter);

            Thread.Sleep(2000);
            IWebElement subscribersChannel2 = wait.Until(ExpectedConditions.ElementIsVisible(youtubeSubscribersChannel));

            var totalSubsChannel2 = regex.Match(subscribersChannel2.Text);

            Assert.Greater(Convert.ToInt32(totalSubsChannel1.Value), Convert.ToInt32(totalSubsChannel2.Value));
        }

        //[Test]

        //public void VerifySauceDemoLoginWithCorrectUserPasswordWorks() 
        //{
        //    webDriver.Navigate().GoToUrl(urlSauceDemo);
        //    IWebElement usernameInput = webDriver.FindElement(sauceDemoUsernameInput);
        //    usernameInput.SendKeys(sauceDemoUsernameInputForLogin);
        //    IWebElement passwordInput = webDriver.FindElement(sauceDemoPasswordInput);
        //    passwordInput.SendKeys(sauceDemoPasswordInputForLogin);
        //    IWebElement submitButton = webDriver.FindElement(sauceDemoSubmitButton);
        //    submitButton.Click();
        //    Assert.That(webDriver.Url == urlSauceDemoInventory);
        //}

        //[Test]

        //public void VerifySauceDemoRequireUsernameInputForLogin()
        //{
        //    webDriver.Navigate().GoToUrl(urlSauceDemo);
        //    IWebElement passwordInput = webDriver.FindElement(sauceDemoPasswordInput);
        //    passwordInput.SendKeys(sauceDemoPasswordInputForLogin);
        //    IWebElement submitButton = webDriver.FindElement(sauceDemoSubmitButton);
        //    submitButton.Click();
        //    IWebElement sauceUsernameLoginError = webDriver.FindElement(sauceDemoUsernameError);
        //    Assert.That(sauceUsernameLoginError.Displayed);
        //}
        //[Test]

        //public void VerifySauceDemoRequirePasswordInputForLogin() 
        //{
        //    webDriver.Navigate().GoToUrl(urlSauceDemo);
        //    IWebElement usernameInput = webDriver.FindElement(sauceDemoUsernameInput);
        //    usernameInput.SendKeys(sauceDemoUsernameInputForLogin);
        //    IWebElement submitButton = webDriver.FindElement(sauceDemoSubmitButton);
        //    submitButton.Click();
        //    IWebElement saucePasswordLoginError = webDriver.FindElement(sauceDemoPasswordError);
        //    Assert.That(saucePasswordLoginError.Displayed);
        //}

        //[Test]
        //public void VerifySauceDemoWrongUsernameAndPasswordShowCorrectError() 
        //{
        //    webDriver.Navigate().GoToUrl(urlSauceDemo);
        //    IWebElement usernameInput = webDriver.FindElement(sauceDemoUsernameInput);
        //    usernameInput.SendKeys(sauceDemoWrongUsernameInputForLogin);
        //    IWebElement passwordInput = webDriver.FindElement(sauceDemoPasswordInput);
        //    passwordInput.SendKeys(sauceDemoWrongPasswordInputForLogin);
        //    IWebElement submitButton = webDriver.FindElement(sauceDemoSubmitButton);
        //    submitButton.Click();
        //    IWebElement errorBox = webDriver.FindElement(sauceDemoWrongUsernameAndPasswordError);
        //    Assert.That(errorBox.Displayed);
        //}
        //[Test]

        //public void VerifySauceDemoLogoutWork() 
        //{
        //    webDriver.Navigate().GoToUrl(urlSauceDemo);
        //    IWebElement usernameInput = webDriver.FindElement(sauceDemoUsernameInput);
        //    usernameInput.SendKeys(sauceDemoUsernameInputForLogin);
        //    IWebElement passwordInput = webDriver.FindElement(sauceDemoPasswordInput);
        //    passwordInput.SendKeys(sauceDemoPasswordInputForLogin);
        //    IWebElement submitButton = webDriver.FindElement(sauceDemoSubmitButton);
        //    submitButton.Click();
        //    IWebElement menuBoxButton = webDriver.FindElement(sauceDemoInventoryMenuBox);
        //    menuBoxButton.Click();
        //    IWebElement logoutButtonLinkAtMenuBox = wait.Until(ExpectedConditions.ElementToBeClickable(sauceDemoInventoryMenuBoxLogoutButton));
        //    logoutButtonLinkAtMenuBox.Click();
        //    IWebElement textAcceptanceNames = webDriver.FindElement(sauceDemoFrontPageAcceptanceOfNames);
        //    Assert.That(textAcceptanceNames.Displayed);
        //}

    }



}