using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;

namespace php4dvdtests
{

    [TestFixture()]
    public class TestBase
    {
        protected IWebDriver wd;

        [SetUp]
        public void StartBrowser()
        {
            wd = WebDriverFactory.GetDriver(DesiredCapabilities.Firefox());
            wd.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            wd.Navigate().GoToUrl("http://localhost/php4dvd/");
        }

        protected void Login(AccountData account)
        {
            wd.FindElement(By.Id("username")).Click();
            wd.FindElement(By.Id("username")).Clear();
            wd.FindElement(By.Id("username")).SendKeys(account.Username);
            wd.FindElement(By.Name("password")).Click();
            wd.FindElement(By.Name("password")).Clear();
            wd.FindElement(By.Name("password")).SendKeys(account.Password);
            wd.FindElement(By.Name("submit")).Click();
        }

        protected bool IsLoggedIn()
        {
            return IsElementPresent(By.LinkText("Log out"));
        }

        protected bool IsLoggedOut()
        {
            return IsElementPresent(By.Id("username"));
        }

        protected void Logout()
        {
            wd.FindElement(By.LinkText("Log out")).Click();
            wd.SwitchTo().Alert().Accept();
        }

        protected bool IsElementPresent(By by)
        {
            return wd.FindElements(by).Count > 0;
        }
    }
}
