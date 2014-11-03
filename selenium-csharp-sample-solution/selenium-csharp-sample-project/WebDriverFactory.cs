using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.PhantomJS;

namespace php4dvdtests
{
    public class WebDriverFactory
    {
        private static WebDriverFactory instance;

        public static IWebDriver GetDriver(string hub, ICapabilities capabilities)
        {
            return FactoryInstance.__GetDriver(hub, capabilities);
        }

        public static IWebDriver GetDriver(ICapabilities capabilities)
        {
            return FactoryInstance.__GetDriver(capabilities);
        }

        public static void DismissDriver(IWebDriver driver)
        {
            FactoryInstance.__DismissDriver(driver);
        }

        public static void DismissAll()
        {
            FactoryInstance.__DismissAll();
        }

        public static WebDriverFactory FactoryInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WebDriverFactory();
                }
                return instance;
            }
        }

        // --------------------------------------------------

        private static ThreadLocal<IWebDriver> threadLocalDriver = new ThreadLocal<IWebDriver>();
        private Dictionary<IWebDriver, string> driverToKeyMap = new Dictionary<IWebDriver, string>();

        private IWebDriver __GetDriver(string hub, ICapabilities capabilities)
        {
            string newKey = CreateKey(capabilities, hub);

            if (!threadLocalDriver.IsValueCreated)
            {
                CreateNewDriver(capabilities, hub);
            }
            else
            {
                IWebDriver currentDriver = threadLocalDriver.Value;
                string currentKey = null;
                if (!driverToKeyMap.TryGetValue(currentDriver, out currentKey))
                {
                    // The driver was dismissed
                    CreateNewDriver(capabilities, hub);
                }
                else
                {
                    if (newKey != currentKey)
                    {
                        // A different flavour of WebDriver is required
                        __DismissDriver(currentDriver);
                        CreateNewDriver(capabilities, hub);
                    }
                    else
                    {
                        // Check the browser is alive
                        try
                        {
                            string currentUrl = currentDriver.Url;
                        }
                        catch (WebDriverException)
                        {
                            CreateNewDriver(capabilities, hub);
                        }
                    }
                }
            }
            return threadLocalDriver.Value;
        }

        private IWebDriver __GetDriver(ICapabilities capabilities)
        {
            return __GetDriver(null, capabilities);
        }

        private void __DismissDriver(IWebDriver driver)
        {
            if (!driverToKeyMap.ContainsKey(driver))
            {
                throw new Exception("The driver is not owned by the factory: " + driver);
            }
            if (driver != threadLocalDriver.Value)
            {
                throw new Exception("The driver does not belong to the current thread: " + driver);
            }
            driver.Quit();
            driverToKeyMap.Remove(driver);
            threadLocalDriver.Dispose();
        }

        private void __DismissAll()
        {
            foreach (IWebDriver driver in new List<IWebDriver>(driverToKeyMap.Keys))
            {
                driver.Quit();
                driverToKeyMap.Remove(driver);
            }
        }

        protected static string CreateKey(ICapabilities capabilities, string hub)
        {
            return capabilities.ToString() + ":" + hub;
        }

        private void CreateNewDriver(ICapabilities capabilities, string hub)
        {
            string newKey = CreateKey(capabilities, hub);
            IWebDriver driver = (hub == null)
                ? CreateLocalDriver(capabilities)
                : CreateRemoteDriver(hub, capabilities);
            driverToKeyMap.Add(driver, newKey);
            threadLocalDriver.Value = driver;
        }

        private static IWebDriver CreateRemoteDriver(string hub, ICapabilities capabilities)
        {
            return new RemoteWebDriver(new Uri(hub), capabilities);
        }

        private static IWebDriver CreateLocalDriver(ICapabilities capabilities)
        {
            // Implementation is incomplete: the capabilities are not converted to the options
            string browserType = capabilities.BrowserName;
            if (browserType == DesiredCapabilities.Firefox().BrowserName)
            {
                return new FirefoxDriver();
            }
            if (browserType == DesiredCapabilities.InternetExplorer().BrowserName)
            {
                return new InternetExplorerDriver();
            }
            if (browserType == DesiredCapabilities.Chrome().BrowserName)
            {
                return new ChromeDriver();
            }
            if (browserType == DesiredCapabilities.Safari().BrowserName)
            {
                return new SafariDriver();
            }
            if (browserType == DesiredCapabilities.PhantomJS().BrowserName)
            {
                return new PhantomJSDriver();
            }

            throw new Exception("Unrecognized browser type: " + browserType);
        }
    }
}
