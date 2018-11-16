using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
