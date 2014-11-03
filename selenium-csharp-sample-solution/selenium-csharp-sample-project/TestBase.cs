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
            app = new ApplicationManager(DesiredCapabilities.Firefox(), "http://localhost/php4dvd/", null);
        }
    }
}
