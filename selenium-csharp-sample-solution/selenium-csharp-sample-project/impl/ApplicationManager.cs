using System;
using OpenQA.Selenium;

namespace php4dvdtests
{
    public class ApplicationManager
    {
        public ApplicationManager(ICapabilities capabilities, string baseUrl, string hubUrl)
        {
            Driver = WebDriverFactory.GetDriver(hubUrl, capabilities);
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            if (!Driver.Url.StartsWith(baseUrl))
            {
                Driver.Navigate().GoToUrl(baseUrl);
            }

            BaseURL = baseUrl;

            Pages = new PageManager(Driver);

            Auth = new LoginHelper(this);
            Navigator = new NavigationHelper(this);
        }

        public IWebDriver Driver { get; set; }

        public string BaseURL { get; set; }

        public LoginHelper Auth { get; set; }

        public NavigationHelper Navigator { get; set; }

        public PageManager Pages { get; set; }
    }
}
