using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using Locators;

namespace LocatorsTests
{
    [TestClass]
    public class BBCMainPageTest
    {
        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }

        private BBCMainPage _mainPage;

        [TestInitialize]
        public void TestInitialize()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(3));
            _mainPage = new BBCMainPage(Driver);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Driver.Quit();
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        public void SearchElement_ShouldThrowArgumentException(string locator)
        {
            //Act
            _mainPage.Navigate();
            Action action = () => _mainPage.SearchElement(locator);

            //Assert
            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        [DataRow("//*[@id='header-content']/nav/div[1]/div/div[2]/ul[2]/li[4]/child::*")]
        public void SearchElement_ShouldFindChild(string locator)
        {
            //Act
            _mainPage.Navigate();
            var anchorTag = _mainPage.SearchElement(locator);

            //Assert
            Assert.IsTrue(anchorTag.GetAttribute("class").Contains("e1gviwgp18"));
        }

        [TestMethod]
        [DataRow("//*[@id='header-content']/nav/div[1]/div/div[2]/ul[2]/li[4]/following-sibling::*")]
        [DataRow("//*[@id='header-content']/nav/div[1]/div/div[2]/ul[2]/li[4]/preceding-sibling::*")]
        public void SearchElement_ShouldFindSiblingListItem(string locator)
        {
            //Act
            _mainPage.Navigate();
            var listItem = _mainPage.SearchElement(locator);

            //Assert
            Assert.IsTrue(listItem.GetAttribute("class").Contains("e1gviwgp23"));
        }

        [TestMethod]
        [DataRow("//*[@id='header-content']/nav/div[1]/div/div[2]/ul[2]/li[4]/child::*/child::span")]
        public void SearchElement_ShouldFindGrandChildSpan(string locator)
        {
            //Act
            _mainPage.Navigate();
            var listItem = _mainPage.SearchElement(locator);

            //Assert
            Assert.IsTrue(listItem.GetAttribute("class").Contains("e1gviwgp19"));
        }

        [TestMethod]
        [DataRow("//*[@id='header-content']/nav/div[1]/div/div[2]/ul[2]/li[4]/parent::*")]
        public void SearchElement_ShouldFindParent(string locator)
        {
            //Act
            _mainPage.Navigate();
            var unorderedList = _mainPage.SearchElement(locator);

            //Assert
            Assert.IsTrue(unorderedList.GetAttribute("class").Contains("e16i5fd20"));
        }
    }
}