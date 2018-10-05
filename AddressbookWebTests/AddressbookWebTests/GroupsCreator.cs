using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AddressbookWebTests
{
    [TestFixture]
    public class GroupsCreator : BaseTest
    {
        private const string Url = "http://localhost/addressbook/edit.php";


        [Test]
        public void CreateAGroup()
        {
            driver.Navigate().GoToUrl(Url);
            LogMeIn(new UserName("Admin", "secret"));
            AddNewGroup();
            CreateGroupWithInfo(new GroupInfo("name", "header", "footer"));
            Logout();
        }

    }
}
