using System;
using OpenQA.Selenium;

namespace php4dvdtests
{
    public class AnyPage
    {
        private PageManager pageManager;

        public AnyPage(PageManager pageManager)
        {
            this.pageManager = pageManager;
        }
        protected bool IsElementPresent(By by)
        {
            return pageManager.driver.FindElements(by).Count > 0;
        }
    }
}
