﻿using NUnit.Framework;
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
        }
        [TestCase]
        public void TestContactDetails()
        {
            ContactInfo fromTable = app.ContactsWorker.GetContactInformationFromTable(0);
            ContactInfo fromDetails = app.ContactsWorker.GetContactInformationFromDetails(0);
            //verification
            Assert.AreEqual(fromDetails, fromTable);
            Assert.AreEqual(fromDetails.Address, fromTable.Address);
            Assert.AreEqual(fromDetails.AllPhones, fromTable.AllPhones);
        }
    }
}