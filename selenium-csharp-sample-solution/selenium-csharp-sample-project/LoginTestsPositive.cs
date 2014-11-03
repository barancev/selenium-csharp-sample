using System;
using System.IO;
using System.Collections.Generic;
using NUnit.Framework;
using Newtonsoft.Json;

namespace php4dvdtests
{

    [TestFixture()]
    public class LoginTestsPositive : TestBase
    {
        [Test, TestCaseSource("ValidCredentials")]
        public void LoginTestWithValidCredentials(AccountData account)
        {
            app.Auth.Login(account);
            Assert.IsTrue(app.Auth.IsLoggedIn(), "Logged in");
            app.Auth.Logout();
            Assert.IsTrue(app.Auth.IsLoggedOut(), "Logged out");
        }

        public static IEnumerable<AccountData> ValidCredentials()
        {
            return JsonConvert.DeserializeObject<List<AccountData>>(
                File.ReadAllText(@"data\validCredentials.json"));
        }
    }
}
