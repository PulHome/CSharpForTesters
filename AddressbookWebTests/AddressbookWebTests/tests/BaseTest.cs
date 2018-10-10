using System;
using NUnit.Framework;

namespace AddressbookWebTests
{
    public class BaseTest
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();
            String baseURL = @"http://localhost/addressbook/";

            app.Nav.OpenUrl(baseURL);
            app.Auth.LogMeIn(new UserName("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Auth.Logout();
            app.Stop();
        }
    }
}
