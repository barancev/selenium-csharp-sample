using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;

namespace php4dvdtests
{

    [TestFixture()]
    public class LoginTestsPositive
    {
        private IWebDriver wd;

        [SetUp]
        public void StartBrowser()
        {
            wd = new FirefoxDriver();
            wd.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            wd.Navigate().GoToUrl("http://localhost/php4dvd/");
        }

        [Test()]
        public void LoginTestWithValidCredentials()
        {
            Login("admin", "admin");
            Assert.IsTrue(IsLoggedIn(), "Logged in");
            Logout();
            Assert.IsTrue(IsLoggedOut(), "Logged out"); // Sic! Don't do Assert.IsFalse(IsLoggedIn());
        }

        private void Login(string username, string password)
        {
            wd.FindElement(By.Id("username")).Click();
            wd.FindElement(By.Id("username")).Clear();
            wd.FindElement(By.Id("username")).SendKeys(username);
            wd.FindElement(By.Name("password")).Click();
            wd.FindElement(By.Name("password")).Clear();
            wd.FindElement(By.Name("password")).SendKeys(password);
            wd.FindElement(By.Name("submit")).Click();
        }

        private bool IsLoggedIn()
        {
            return IsElementPresent(By.LinkText("Log out"));
        }

        private bool IsLoggedOut()
        {
            return IsElementPresent(By.Id("username"));
        }

        private void Logout()
        {
            wd.FindElement(By.LinkText("Log out")).Click();
            wd.SwitchTo().Alert().Accept();
        }

        private bool IsElementPresent(By by)
        {
            return wd.FindElements(by).Count > 0;
        }

        [TearDown]
        public void StopBrowser()
        {
            if (wd != null)
            {
                wd.Quit();
                wd = null;
            }
        }
    }
}
