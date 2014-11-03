using System;
using OpenQA.Selenium;

namespace php4dvdtests
{
    public class NavigationHelper
    {
        private ApplicationManager manager;

        public NavigationHelper(ApplicationManager manager)
        {
            this.manager = manager;
        }
    }
}
