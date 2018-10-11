using NUnit.Framework;


namespace AddressbookWebTests
{
    [TestFixture]
    public class ContactCreator : BaseTest
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
            CreateContact();
            app.Nav.OpenHomePage();
            app.ContactsWorker.Delete(-1);
        }
        [Test]
        public void EditContact()
        {
            app.Nav.OpenHomePage();
            app.ContactsWorker.Edit(3, new ContactInfo("TheFirstNameNEW", "TheLastNameNEW"));
        }
    }
}
