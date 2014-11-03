using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace php4dvdtests
{
    public class InternalPage : AnyPage
    {
        public InternalPage(PageManager pageManager)
            : base(pageManager)
        {
        }

        [FindsBy(How = How.LinkText, Using = "Log out")]
        public IWebElement LogoutLink;

        public bool IsOnThisPage()
        {
            return IsElementPresent(By.LinkText("Log out"));
        }
    }
}
