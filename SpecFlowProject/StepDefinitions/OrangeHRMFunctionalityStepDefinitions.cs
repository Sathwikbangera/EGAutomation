using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using WebDriverManager.DriverConfigs.Impl;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class OrangeHRMFunctionalityStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;

        public OrangeHRMFunctionalityStepDefinitions(ScenarioContext scenarioContext)
        {

            _scenarioContext = scenarioContext;
            _driver = _scenarioContext["WebDriver"] as IWebDriver;

        }


        
      [Given(@"User is on the Orange HRM Login Page")]
        


        public void GivenUserIsOnTheOrangeHrmLoginPage()
        {

            // confifgure the web driver manager to set up the chrome capabilities
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            // intialize the web driver 
            _driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            _driver.Manage().Window.Maximize();
           
            Thread.Sleep(2000);
        }
        [When(@"User enters the ""([^""]*)"" and ""([^""]*)"" in input field\.")]
        public void WhenUserEntersTheAndInInputField_(string usrname, string passwd)
        {
            IWebElement username = _driver.FindElement(By.XPath("//input[@name = 'username']"));

            username.SendKeys(usrname);


            IWebElement password = _driver.FindElement(By.XPath("//input[@name = 'password']"));

            password.SendKeys(passwd);

        }

        [When(@"User clicks on Login button")]
        public void WhenUserClicksOnLoginButton()
        {
            IWebElement loginbutton = _driver.FindElement(By.XPath("//button[@type = 'submit']"));

            loginbutton.Click();

            Thread.Sleep(1000);
        }

        [Then(@"User is navigated to Orange hrm home page")]
        public void ThenUserIsNavigatedToOrangeHrmHomePage()
        {
            IWebElement Admin = _driver.FindElement(By.XPath("(//a[@class = 'oxd-main-menu-item'])[1]"));

            Admin.Click();

            _driver.Close();
        }
        [Then(@"User is displayed with error message")]
        public void ThenUserIsDisplayedWithErrorMessage()
        {
            
            IWebElement error = _driver.FindElement(By.XPath("//p[@class='oxd-text oxd-text--p oxd-alert-content-text']"));
            Console.WriteLine(error);
            Assert.That(error.Text, Is.EqualTo("Invalid credentials"));
            _driver.Close();
        }



    }
}
