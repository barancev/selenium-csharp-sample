using System;
using System.IO;
using System.Collections.Generic;
using NUnit.Framework;
using Newtonsoft.Json;

namespace php4dvdtests
{

    [TestFixture()]
    public class LoginTestsNegative : TestBase
    {
        [Test, TestCaseSource("InvalidCredentials")]
        public void LoginTestWithInvalidCredentials(AccountData account)
        {
            app.Auth.Login(account);
            Assert.IsTrue(app.Auth.IsLoggedOut(), "Logged out");
        }
        public static IEnumerable<AccountData> InvalidCredentials()
        {
            return JsonConvert.DeserializeObject<List<AccountData>>(
                File.ReadAllText(@"data\invalidCredentials.json"));
        }
    }
}
