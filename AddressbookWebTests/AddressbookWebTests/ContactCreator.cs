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
    public class ContactCreator : BaseTest
    {

        [Test]
        public void CreateAContact()
        {
            baseURL = @"http://localhost/addressbook/";
            driver.Navigate().GoToUrl(baseURL);
            LogMeIn(new UserName("admin", "secret"));
            OpenNewContactPage();
            FillinContactData(new ContactInfo("TheFirstName", "TheLastName"));
            Logout();
        }

    }
}
