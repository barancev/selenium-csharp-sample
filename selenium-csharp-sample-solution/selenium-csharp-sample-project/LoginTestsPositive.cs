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
            app.Auth.Login(account);
            Assert.IsTrue(app.Auth.IsLoggedIn(), "Logged in");
            app.Auth.Logout();
            Assert.IsTrue(app.Auth.IsLoggedOut(), "Logged out");
        }
    }
}
