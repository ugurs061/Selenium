using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpSelFramework.PageObjects
{
    public class ProductPage
    {
        IWebDriver _driver;
        By cardTitle = By.CssSelector(".card-title a");
        By addToCart = By.CssSelector(".card-footer button");

        public ProductPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> cards;

        [FindsBy(How = How.PartialLinkText, Using = "Checkout")]
        private IWebElement checkoutButton;


        public void waitForPageDisplay()

        {

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
        }

        public IList<IWebElement> getCards()
        {

            return cards;
        }

        public By getCardTitle()
        {

            return cardTitle;
        }

        public CheckoutPage checkout()
        {

            checkoutButton.Click();
            return new CheckoutPage(_driver);
        }

        public By addToCartButton()
        {

            return addToCart;
        }



    }
}
