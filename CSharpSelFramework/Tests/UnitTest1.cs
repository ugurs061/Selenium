using CSharpSelFramework.PageObjects;
using CSharpSelFramework.Utilities;
using OpenQA.Selenium;

namespace CSharpSelFramework.Tests
{
    public class E2ETest : Base
    {

        [Test]
        public void EndToEndFlow()
        {
            string[] expectedProducts = { "iphone X", "Blackberry" };
            string[] actualProducts = new string[2];
            LoginPage loginPage = new LoginPage(GetDriver());
            
            ProductPage productPage=loginPage.validLogin("rahulshettyacademy","learning");
         
            productPage.waitForPageDisplay();

            IList<IWebElement> products = productPage.getCards();

            foreach (IWebElement product in products)
            {

                if (expectedProducts.Contains(product.FindElement(productPage.getCardTitle()).Text))

                {
                    product.FindElement(productPage.addToCartButton()).Click();
                }
            }

            CheckoutPage checkoutPage = productPage.checkout();

            IList<IWebElement> checkoutCards = checkoutPage.getCards();

            for (int i = 0; i < checkoutCards.Count; i++)

            {
                actualProducts[i] = checkoutCards[i].Text;

            }
            Assert.AreEqual(expectedProducts, actualProducts);
            checkoutPage.checkOut();


            driver.FindElement(By.CssSelector(".btn-success")).Click();

            driver.FindElement(By.Id("country")).SendKeys("ind");


            driver.FindElement(By.LinkText("India")).Click();


            driver.FindElement(By.CssSelector("label[for*='checkbox2']")).Click();
            driver.FindElement(By.CssSelector("[value='Purchase']")).Click();
            string confirText = driver.FindElement(By.CssSelector(".alert-success")).Text;

            StringAssert.Contains("Success", confirText);
        }
    }
}

