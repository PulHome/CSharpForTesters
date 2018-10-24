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
            app = ApplicationManager.GetInstance();
        }
    }
}
