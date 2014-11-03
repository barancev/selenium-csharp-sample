using System;
using OpenQA.Selenium;

namespace php4dvdtests
{
    public class LoginHelper
    {
        private ApplicationManager manager;
        private IWebDriver wd;

        public LoginHelper(ApplicationManager manager)
        {
            this.manager = manager;
            this.wd = manager.Driver;
        }

        public void Login(AccountData account)
        {
            wd.FindElement(By.Id("username")).Click();
            wd.FindElement(By.Id("username")).Clear();
            wd.FindElement(By.Id("username")).SendKeys(account.Username);
            wd.FindElement(By.Name("password")).Click();
            wd.FindElement(By.Name("password")).Clear();
            wd.FindElement(By.Name("password")).SendKeys(account.Password);
            wd.FindElement(By.Name("submit")).Click();
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.LinkText("Log out"));
        }

        public bool IsLoggedOut()
        {
            return IsElementPresent(By.Id("username"));
        }

        public void Logout()
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
