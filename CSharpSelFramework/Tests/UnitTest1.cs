using CSharpSelFramework.PageObjects;
using CSharpSelFramework.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSharpSelFramework.Tests
{
    [Parallelizable(ParallelScope.Self)]
    public class E2ETest : Base
    {

        [Test, TestCaseSource("AddTestDataConfig"), Category("Regression")]
        //[TestCase("rahulshettyacademy", "learning")]
        //[TestCase("ugur", "learning")]

        // run all data sets of Test method in parallel  - Done
        // run all test methods in one class parallel   - Done
        // run all test files in project parallel   - Done

        //dotnet test pathto.csproj ( ALl tests)
        //dotnet test pathto.csproj --filter TestCategory=Smoke

        // dotnet test CSharpSelFramework.csproj --filter TestCategory=Smoke -- TestRunParameters.Parameter\(name=\"browserName\",value=\"Chrome\"\)
        [Parallelizable(ParallelScope.All)]
        public void EndToEndFlow(String username, String password, string[] expectedProducts)
        {
            //string[] expectedProducts = { "iphone X", "Blackberry" };
            string[] actualProducts = new string[2];
            LoginPage loginPage = new LoginPage(GetDriver());

            ProductPage productPage = loginPage.validLogin(username, password);

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


            driver.Value.FindElement(By.CssSelector(".btn-success")).Click();

            driver.Value.FindElement(By.Id("country")).SendKeys("ind");


            driver.Value.FindElement(By.LinkText("India")).Click();


            driver.Value.FindElement(By.CssSelector("label[for*='checkbox2']")).Click();
            driver.Value.FindElement(By.CssSelector("[value='Purchase']")).Click();
            string confirText = driver.Value.FindElement(By.CssSelector(".alert-success")).Text;

            StringAssert.Contains("Success", confirText);
        }

        [Test, Category("Smoke")]
        public void LocatorsIdentification()

        {

            driver.Value.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.Value.FindElement(By.Id("username")).Clear();
            driver.Value.FindElement(By.Id("username")).SendKeys("rahulshetty");
            driver.Value.FindElement(By.Name("password")).SendKeys("123456");
            //css selector & xpath
            //  tagname[attribute ='value']
            //    #id  #terms  - class name -> css .classname
            //    driver.FindElement(By.CssSelector("input[value='Sign In']")).Click();

            //    //tagName[@attribute = 'value']

            // CSS - .text-info span:nth-child(1) input
            //xpath - //label[@class='text-info']/span/input

            driver.Value.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();

            driver.Value.FindElement(By.XPath("//input[@value='Sign In']")).Click();

            WebDriverWait wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
           .TextToBePresentInElementValue(driver.Value.FindElement(By.Id("signInBtn")), "Sign In"));

            String errorMessage = driver.Value.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(errorMessage);
        }

        public static IEnumerable<TestCaseData> AddTestDataConfig()
        {
            yield return new TestCaseData(getDataParser().extractData("username"), getDataParser().extractData("password"), getDataParser().extractDataArray("products"));
            yield return new TestCaseData(getDataParser().extractData("username"), getDataParser().extractData("password"), getDataParser().extractDataArray("products"));
            yield return new TestCaseData(getDataParser().extractData("username_wrong"), getDataParser().extractData("password_wrong"), getDataParser().extractDataArray("products"));
        }
    }
}

