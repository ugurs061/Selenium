using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumDemo
{
    public class FunctionalTest
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
        public void DropDownExample() 
        {
           IWebElement dropdown = driver.FindElement(By.CssSelector("select.form-control"));
           SelectElement selectElement = new SelectElement(dropdown);
            selectElement.SelectByText("Teacher");
            selectElement.SelectByValue("consult");
            selectElement.SelectByIndex(1);
        }
        [Test]
        public void RadioButtonExample()
        {
            IList<IWebElement> radioButton = driver.FindElements(By.CssSelector("input[type='radio']"));

            foreach (IWebElement rb in radioButton)
            {
                if (rb.GetAttribute("value").Equals("User"))
                {
                    rb.Click();
                }
            }

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn")));


            driver.FindElement(By.Id("okayBtn")).Click();
            Boolean result = driver.FindElement(By.Id("usertype")).Selected;

            Assert.That(result, Is.True);
        }

    }
}
