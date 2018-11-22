using NUnit.Framework;

namespace AddressbookWebTests
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            app = ApplicationManager.GetInstance();
            app.Auth.LogMeIn(new AccountInfo("admin", "secret"));
        }
    }
}
