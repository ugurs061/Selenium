using CSharpSelFramework.Utilities;
using OpenQA.Selenium;

namespace SeleniumDemo
{
    public class WindowHandlers : Base
    {
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
