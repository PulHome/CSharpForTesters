using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace AddressbookWebTests
{
    [TestFixture]
    public class ContactCreator : AuthTestBase
    {
        [Test, TestCaseSource("GropDataFromJsonFile")]
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
        public static string groupsFile = @"C:\Users\Politsyn.KL\Source\Repos\C\CSharpForTesters\AddressbookWebTests\AddressbookWebTests\contacts.json";
        //public static string groupsFile = @"groups.csv";

        public static IEnumerable<ContactInfo> GropDataFromCsvFile()
        {
            List<ContactInfo> contacts = new List<ContactInfo>();
            string[] lines = File.ReadAllLines(groupsFile);
            foreach (var line in lines)
            {
                string[] parts = line.Split();
                contacts.Add(new ContactInfo()
                {
                    FirstName = parts[0],
                    LastName = parts[1],
                    Address = parts[2]
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactInfo> GropDataFromXmlFile()
        {
            StreamReader sr = new StreamReader(groupsFile);
            var retVal = (List<ContactInfo>)(new XmlSerializer(typeof(List<ContactInfo>)).Deserialize(sr));
            sr.Close();
            return retVal;
        }

        public static IEnumerable<ContactInfo> GropDataFromJsonFile()
        {
            StreamReader sr = new StreamReader(groupsFile);
            var retVal = JsonConvert.DeserializeObject<List<ContactInfo>>(sr.ReadToEnd());
            sr.Close();
            return retVal;
        }
    }
}
