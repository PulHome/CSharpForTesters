using NUnit.Framework;
using System.Collections.Generic;

namespace AddressbookWebTests
{
    [TestFixture]
    public class ContactCreator : AuthTestBase
    {
        [TestCase(null)]
        public void CreateContact(ContactInfo cInf = null)
        {
            List<ContactInfo> oldContacts = new List<ContactInfo>();
            oldContacts = app.ContactsWorker.GetContactsList();
            if (cInf == null)
            {
                cInf = new ContactInfo("TheFirstName", "TheLastName");
            }

            app.Nav.OpenNewContactPage();
            app.ContactsWorker.FillinContactData(cInf);
            List<ContactInfo> newContacts = new List<ContactInfo>();
            newContacts = app.ContactsWorker.GetContactsList();
            oldContacts.Add(cInf);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
        [Test]
        public void DeleteContact()
        {
            app.Nav.OpenContactPage();
            List<ContactInfo> oldContacts = new List<ContactInfo>();
            oldContacts = app.ContactsWorker.GetContactsList();

            if (!app.ContactsWorker.CheckAtLeastOneContactExists())
            {
                CreateContact();
            }
            app.Nav.OpenContactPage();

            app.ContactsWorker.Delete(-1);

            List<ContactInfo> newContacts = new List<ContactInfo>();
            newContacts = app.ContactsWorker.GetContactsList();
            oldContacts.RemoveAt(oldContacts.Count - 1);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void ModifyAContact()
        {
            ContactInfo modifiedContact = new ContactInfo("FirstModified2", "LastModified2");
            app.Nav.OpenContactPage();
            List<ContactInfo> oldContacts = new List<ContactInfo>();
            oldContacts = app.ContactsWorker.GetContactsList();

            if (!app.ContactsWorker.CheckAtLeastOneContactExists())
            {
                CreateContact();
            }
            app.Nav.OpenContactPage();
            app.ContactsWorker.Modify(-1, modifiedContact);
            List<ContactInfo> newContacts = new List<ContactInfo>();
            newContacts = app.ContactsWorker.GetContactsList();
            oldContacts[oldContacts.Count - 1] = modifiedContact;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
