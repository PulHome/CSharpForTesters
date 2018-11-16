using NUnit.Framework;
using System.Collections.Generic;

namespace AddressbookWebTests
{
    [TestFixture]
    public class ContactCreator : AuthTestBase
    {
        [Test, TestCaseSource("RandomContactDataGenerator")]
        public void CreateContact(ContactInfo contact)
        {
            List<ContactInfo> oldContacts = new List<ContactInfo>();
            oldContacts = app.ContactsWorker.GetContactsList();
            if (contact == null)
            {
                contact = new ContactInfo("TheFirstName", "TheLastName");
            }

            app.Nav.OpenNewContactPage();
            app.ContactsWorker.FillinContactData(contact);
            List<ContactInfo> newContacts = new List<ContactInfo>();
            newContacts = app.ContactsWorker.GetContactsList();
            oldContacts.Add(contact);
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
                CreateContact(null);
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
                CreateContact(null);
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

        public static IEnumerable<ContactInfo> RandomContactDataGenerator()
        {
            List<ContactInfo> contacts = new List<ContactInfo>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactInfo()
                {
                    FirstName = GenerateRandomString(50),
                    LastName = GenerateRandomString(50),
                    Address = GenerateRandomString(50)
                });
            }
            return contacts;
        }
    }
}
