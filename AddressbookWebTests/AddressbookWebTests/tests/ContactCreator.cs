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
            String baseURL = @"http://localhost/addressbook/";
            app.Nav.OpenUrl(baseURL);
            app.Auth.LogMeIn(new UserName("admin", "secret"));
            app.Nav.OpenNewContactPage();
            app.ContactsWorker.FillinContactData(new ContactInfo("TheFirstName", "TheLastName"));
            app.Auth.Logout();
        }

    }
}
