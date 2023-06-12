using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumDemo
{
    public class Locators
    {
        // Xpath, Css , id, classname, name, tagname.

        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver(); // for Chorome
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
            driver.FindElement(By.CssSelector(" input[value='Sign In']")).Click();

            //tagName [@attribute = 'value')
           // driver.FindElement(By.XPath("//input [@value= 'Sign In']")).Click();


        }
    }
}
