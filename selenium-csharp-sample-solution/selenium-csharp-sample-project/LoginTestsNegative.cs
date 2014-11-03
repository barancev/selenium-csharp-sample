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
            app.Auth.Login(account);
            Assert.IsTrue(app.Auth.IsLoggedOut(), "Logged out");
        }
    }
}
