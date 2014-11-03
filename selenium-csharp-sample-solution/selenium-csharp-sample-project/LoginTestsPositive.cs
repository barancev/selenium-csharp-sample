using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;

namespace php4dvdtests
{

    [TestFixture()]
    public class LoginTestsPositive : TestBase
    {
        [Test()]
        public void LoginTestWithValidCredentials()
        {
            AccountData account = new AccountData()
            {
                Username = "admin",
                Password = "admin"
            };
            Login(account);
            Assert.IsTrue(IsLoggedIn(), "Logged in");
            Logout();
            Assert.IsTrue(IsLoggedOut(), "Logged out"); // Sic! Don't do Assert.IsFalse(IsLoggedIn());
        }
    }
}
