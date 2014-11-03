using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace php4dvdtests
{
    public class LoginPage : AnyPage
    {
        public LoginPage(PageManager pageManager)
            : base(pageManager)
        {
        }

        [FindsBy(How = How.Name, Using = "username")]
        public IWebElement UsernameField;

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement PasswordField;

        [FindsBy(How = How.Name, Using = "submit")]
        public IWebElement SubmitButton;

        public bool IsOnThisPage()
        {
            return IsElementPresent(By.Id("username"));
        }
    }
}
