using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace php4dvdtests
{
    public class PageManager
    {
        private IWebDriver driver;

        public PageManager(OpenQA.Selenium.IWebDriver Driver)
        {
            this.driver = Driver;
            Login = InitElements(new LoginPage(this));
            Internal = InitElements(new InternalPage(this));
            UserProfile = InitElements(new UserProfilePage(this));
        }

        private T InitElements<T>(T page) where T : AnyPage
        {
            PageFactory.InitElements(driver, page);
            return page;
        }

        public InternalPage Internal { get; set; }

        public LoginPage Login { get; set; }

        public UserProfilePage UserProfile { get; set; }
    }
}
