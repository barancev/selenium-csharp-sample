using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;

namespace php4dvdtests
{

    [TestFixture()]
    public class Php4DvdTests
    {
        private IWebDriver wd;

        [SetUp]
        public void StartBrowser()
        {
            wd = new FirefoxDriver();
            wd.Navigate().GoToUrl("http://localhost/php4dvd/");
        }

        [Test()]
        public void LoginTest()
        {
            Login();
            Logout();
        }

        private void Logout()
        {
            wd.FindElement(By.LinkText("Log out")).Click();
            wd.SwitchTo().Alert().Accept();
        }

        private void Login()
        {
            wd.FindElement(By.Id("username")).Click();
            wd.FindElement(By.Id("username")).Clear();
            wd.FindElement(By.Id("username")).SendKeys("admin");
            wd.FindElement(By.Name("password")).Click();
            wd.FindElement(By.Name("password")).Clear();
            wd.FindElement(By.Name("password")).SendKeys("admin");
            wd.FindElement(By.Name("submit")).Click();
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
