using System;
using NUnit.Framework;


namespace AddressbookWebTests
{
    [TestFixture]
    public class LoginTests : BaseTest
    {
        [Test]
        public void LoginWithValidCreds()
        {
            AccountInfo account = new AccountInfo("admin", "secret");
            app.Auth.Logout();
            app.Auth.LogMeIn(account);
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }
        [Test]
        public void LoginWithInvalidCreds()
        {
            AccountInfo account = new AccountInfo("admin", "123456");
            app.Auth.Logout();
            app.Auth.LogMeIn(account);
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}