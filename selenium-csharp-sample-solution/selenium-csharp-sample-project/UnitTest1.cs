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
        [Test()]
        public void LoginTest()
        {
            IWebDriver wd = new FirefoxDriver();
            try
            {
                wd.Navigate().GoToUrl("http://192.168.0.100/php4dvd/");
                wd.FindElement(By.Id("username")).Click();
                wd.FindElement(By.Id("username")).Clear();
                wd.FindElement(By.Id("username")).SendKeys("admin");
                wd.FindElement(By.Name("password")).Click();
                wd.FindElement(By.Name("password")).Clear();
                wd.FindElement(By.Name("password")).SendKeys("admin");
                wd.FindElement(By.Name("submit")).Click();
                wd.FindElement(By.LinkText("Log out")).Click();
                wd.SwitchTo().Alert().Accept();
            }
            finally
            {
                wd.Quit();
            }
        }
    }
}
