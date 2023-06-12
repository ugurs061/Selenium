using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Support.UI;

namespace SeleniumDemo
{
    public class Locators
    {
        // Xpath, Css , id, classname, name, tagname, linktext.

        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver(); // for Chorome
            //Implicit wait 5seconds can be decalred globally
            //5 seconds
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); // public wait
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        [Test]
        public void LocatorsIdentification()
        {
            driver.FindElement(By.Id("username")).SendKeys("Ugurtest");
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("Ugur");
            driver.FindElement(By.Name("password")).SendKeys("123456");
            // css selector & xpath
            // tagname[attribute = 'value']

            driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();

            driver.FindElement(By.CssSelector(" input[value='Sign In']")).Click();

            //tagName [@attribute = 'value')
            //driver.FindElement(By.XPath("//input [@value= 'Sign In']")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
            .TextToBePresentInElementValue(driver.FindElement(By.Id("signInBtn")), "Sign In"));// belirli bir ogeyi bekletmeye yarar

            String errorMessage = driver.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(errorMessage);

            IWebElement link = driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
            String hrefAttr = link.GetAttribute("href");
            String expectedUrl = "https://rahulshettyacademy.com/documents-request";
            Assert.AreEqual(expectedUrl, hrefAttr);

            // validate url of the link text

        }
    }
}
