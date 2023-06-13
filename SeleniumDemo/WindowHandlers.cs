﻿using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumDemo
{
    public class WindowHandlers
    {
        IWebDriver driver;

        [SetUp]

        public void StartBrowser()

        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";



        }
        [Test]
        public void WindowHandle()

        {
            String email = "mentor@rahulshettyacademy.com";
            String parentWindowId = driver.CurrentWindowHandle;
            driver.FindElement(By.ClassName("blinkingText")).Click();

            Assert.AreEqual(2, driver.WindowHandles.Count);//1

            String childWindowName = driver.WindowHandles[1];

            driver.SwitchTo().Window(childWindowName);

            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector(".red")).Text);
            String text = driver.FindElement(By.CssSelector(".red")).Text;

            // Please email us at mentor @rahulshettyacademy.com with below template to receive response

            String[] splittedText = text.Split("at");

            String[] trimmedString = splittedText[1].Trim().Split(" ");

            Assert.AreEqual(email, trimmedString[0]);

            driver.SwitchTo().Window(parentWindowId);

            driver.FindElement(By.Id("username")).SendKeys(trimmedString[0]);

        }
    }
}
