using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using WebDriverManager.DriverConfigs.Impl;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class ParabankRegisterFunctionalityStepDefinitions
    {
        private IWebDriver _driver;
        [Given(@"User opens bank website")]
        public void GivenUserOpensBankWebsite()
        {
            // confifgure the web driver manager to set up the chrome capabilities
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            // intialize the web driver 
            _driver = new FirefoxDriver();
            _driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/register.htm");
            _driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
        }
/*
        [Given(@"User is on Home page")]
        public void GivenUserIsOnHomePage()
        {
            Console.WriteLine("User is on Home page");
        }*/

        [When(@"User enters the ""([^""]*)"",""([^""]*)"",""([^""]*)"",""([^""]*)"",""([^""]*)"",""([^""]*)"",""([^""]*)"",""([^""]*)"",""([^""]*)"" ,""([^""]*)"",""([^""]*)""")]
        public void WhenUserEntersThe(string fname, string lname, string address, string city, string state, string zip, string phone, string ssn, string username, string password, string cpassword)
        {
            Console.WriteLine($"First Name: {fname}\nLast Name: {lname}\nAddress: {address}\nCity: {city}\nState: {state}\nZIP: {zip}\nPhone: {phone}\nSSN: {ssn}\nUsername: {username}\nPassword: {password}\nConfirm Password: {cpassword}");
            _driver.FindElement(By.XPath("//input[@id='customer.firstName']")).SendKeys(fname);
            _driver.FindElement(By.XPath("//input[@id='customer.lastName']")).SendKeys(lname);
            _driver.FindElement(By.XPath("//input[@id='customer.address.street']")).SendKeys(address);
            _driver.FindElement(By.XPath("//input[@id='customer.address.city']")).SendKeys(city);
            _driver.FindElement(By.XPath("//input[@id='customer.address.state']")).SendKeys(state);
            _driver.FindElement(By.XPath("//input[@id='customer.address.zipCode']")).SendKeys(zip);
            _driver.FindElement(By.XPath("//input[@id='customer.phoneNumber']")).SendKeys(phone);
            _driver.FindElement(By.XPath("//input[@id='customer.ssn']")).SendKeys(ssn);
            _driver.FindElement(By.XPath("//input[@id='customer.username']")).SendKeys(username);
            _driver.FindElement(By.XPath("//input[@id='customer.password']")).SendKeys(password);
            _driver.FindElement(By.XPath("//input[@id='repeatedPassword']")).SendKeys(cpassword);
        }
        [Given(@"User clicks new register button")]
        public void GivenUserClicksNewRegisterButton()
        {
            IWebElement register = _driver.FindElement(By.XPath("//a[normalize-space()='Register']"));

            register.Click();

            Thread.Sleep(1000);
        }

        [When(@"User clicks on register button")]
        public void WhenUserClicksOnRegisterButton()
        {
            IWebElement registerbtn = _driver.FindElement(By.XPath("//input[@value='Register']"));

            registerbtn.Click();

            Thread.Sleep(1000);
        }


        [When(@"User enters the ""([^""]*)"" ,""([^""]*)""")]
        public void WhenUserEntersThe(string user, string pass)
        {
            _driver.FindElement(By.XPath("//input[@name='username']")).SendKeys(user);
            _driver.FindElement(By.XPath("//input[@name='password']")).SendKeys(pass);
        }

        [When(@"User clicks on the login button")]
        public void WhenUserClicksOnTheLoginButton()
        {
            IWebElement login = _driver.FindElement(By.XPath("//input[@value='Log In']"));

            login.Click();

            Thread.Sleep(1000);
        }

        [Then(@"User is navigated to Home Page")]
        public void ThenUserIsNavigatedToHomePage()
        {
            Console.WriteLine("User is navigated to Dashboard Page");

            IWebElement sucess = _driver.FindElement(By.XPath("//b[normalize-space()='Welcome']"));
            Assert.That(sucess.Text, Is.EqualTo("Welcome"));


            _driver.Close();
        }



        [Then(@"User is navigated to Dashboard Page")]
        public void ThenUserIsNavigatedToDashboardPage()
        {
            Console.WriteLine("User is navigated to Dashboard Page");
            IWebElement sucess = _driver.FindElement(By.XPath("//p[contains(text(),'Your account was created successfully. You are now')]"));

            Assert.That(sucess.Text, Is.EqualTo("Your account was created successfully. You are now logged in."));


            _driver.Close();
        }
    }
}
