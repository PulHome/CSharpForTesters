using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AddressbookWebTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [TestCase]
        public void TestContactInformaiton()
        {
            ContactInfo fromTable = app.ContactsWorker.GetContactInformationFromTable(0);
            ContactInfo fromForm = app.ContactsWorker.GetContactInformationFromEditForm(0);
            //verification
            Assert.AreEqual(fromForm, fromTable);
            Assert.AreEqual(fromForm.Address, fromTable.Address);
            Assert.AreEqual(fromForm.AllPhones, fromTable.AllPhones);
            Assert.AreEqual(fromForm.AllEmails, fromTable.AllEmails);
        }
        [TestCase]
        public void TestContactDetails()
        {
            ContactInfo fromTable = app.ContactsWorker.GetContactInformationFromTable(0);
            ContactInfo fromDetails = app.ContactsWorker.GetContactInformationFromDetails(0);
            //verification
            Assert.AreEqual(fromDetails, fromTable);
            Assert.AreEqual(fromDetails.Address, fromTable.Address);
            //Assert.AreEqual(fromDetails.AllPhones, fromTable.AllPhones);

            String contactDetailsAsString = app.ContactsWorker.GetContactInformationFromDetailsAsString(0);
            Assert.AreEqual(fromTable.GetFullString(), contactDetailsAsString);
        }
    }
}