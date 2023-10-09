using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Locators
{
    public class BBCMainPage
    {
        private readonly string _url = "https://www.bbc.com/sport";
        private readonly IWebDriver _driver;

        public BBCMainPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Navigate()
        {
            _driver.Navigate().GoToUrl(_url);
        }

        public IWebElement SearchElement(string locator)
        {
            if (string.IsNullOrEmpty(locator))
            {
                throw new ArgumentException("Locator cannot be null or empty", nameof(locator));
            }

            return _driver.FindElement(By.XPath(locator));
        }
    }
}