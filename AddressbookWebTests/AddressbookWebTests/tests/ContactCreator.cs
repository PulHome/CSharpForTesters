using NUnit.Framework;


namespace AddressbookWebTests
{
    [TestFixture]
    public class ContactCreator : AuthTestBase
    {
        [TestCase(null)]
        public void CreateContact(ContactInfo cInf = null)
        {
            if (cInf == null)
            {
                cInf = new ContactInfo("TheFirstName", "TheLastName");
            }
            app.Nav.OpenNewContactPage();
            app.ContactsWorker.FillinContactData(cInf);
        }
        [Test]
        public void DeleteContact()
        {
            app.Nav.OpenHomePage();

            if (!app.ContactsWorker.CheckAtLeastOneContactExists())
            {
                CreateContact();
            }
            app.Nav.OpenHomePage();
            app.ContactsWorker.Delete(-1);
        }

        [Test]
        public void ModifyAContact()
        {
            ContactInfo modifiedContact = new ContactInfo("FirstModified", "LastModified");
            app.Nav.OpenHomePage();

            if (!app.ContactsWorker.CheckAtLeastOneContactExists())
            {
                CreateContact();
            }
            app.Nav.OpenHomePage();
            app.ContactsWorker.Modify(-1, modifiedContact);
        }

        [Test]
        public void EditContact()
        {
            app.Nav.OpenHomePage();
            app.ContactsWorker.Edit(3, new ContactInfo("TheFirstNameNEW", "TheLastNameNEW"));
        }
    }
}
