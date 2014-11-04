using OpenQA.Selenium.Remote;
using System;
using NUnit.Framework;

namespace php4dvdtests
{

    [TestFixture()]
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void StartApplication()
        {
            string browserType = System.Environment.GetEnvironmentVariable("BROWSER");
            string baseUrl = System.Environment.GetEnvironmentVariable("BASE_URL");
            string hubUrl = System.Environment.GetEnvironmentVariable("HUB_URL");

            if (baseUrl == null)
            {
                baseUrl = "http://localhost/php4dvd/";
            }

            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName,
                browserType != null ? browserType : "firefox");

            app = new ApplicationManager(capabilities, baseUrl, hubUrl);
        }
    }
}
