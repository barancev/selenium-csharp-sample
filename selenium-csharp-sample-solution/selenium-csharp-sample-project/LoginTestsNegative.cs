using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;

namespace php4dvdtests
{

    [TestFixture()]
    public class LoginTestsNegative : TestBase
    {
        [Test()]
        public void LoginTestWithInvalidCredentials()
        {
            AccountData account = new AccountData()
            {
                Username = "admin",
                Password = "nimda"
            };
            Login(account);
            Assert.IsTrue(IsLoggedOut(), "Logged out"); // Sic! Don't do Assert.IsFalse(IsLoggedIn());
        }
    }
}
