﻿using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpSelFramework.PageObjects
{
    public class LoginPage
    {
        //driver.FindElement(By.Id("username"))
        //By.Id("username")

        //driver.FindElement(By.Name("password")).SendKeys("learning");
        //driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
        //driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();
        private IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {

            this._driver = driver;
            PageFactory.InitElements(driver, this);

        }

        //Pageobject factory

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement password;

        [FindsBy(How = How.XPath, Using = "//div[@class='form-group'][5]/label/span/input")]
        private IWebElement checkBox;

        [FindsBy(How = How.CssSelector, Using = "input[value='Sign In']")]
        private IWebElement signInButton;

        public ProductPage validLogin(string user, string pass)

        {
            username.SendKeys(user);
            password.SendKeys(pass);
            checkBox.Click();
            signInButton.Click();
            return new ProductPage(_driver);
        }

        public IWebElement getUserName()

        {
            return username;
        }
    }
}
