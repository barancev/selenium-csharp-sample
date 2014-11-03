using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace php4dvdtests
{
    public class ApplicationManager
    {
        public ApplicationManager(ICapabilities capabilities, string baseUrl, string hubUrl)
        {
            Driver = WebDriverFactory.GetDriver(hubUrl, capabilities);
            BaseURL = baseUrl;

            Auth = new LoginHelper(this);
            Navigator = new NavigationHelper(this);
        }

        public IWebDriver Driver { get; set; }

        public string BaseURL { get; set; }

        public LoginHelper Auth { get; set; }

        public NavigationHelper Navigator { get; set; }
    }
}
