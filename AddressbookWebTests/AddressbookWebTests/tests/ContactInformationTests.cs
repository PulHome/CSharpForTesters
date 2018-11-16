using NUnit.Framework;
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
    }
}