using NUnit.Framework;


namespace AddressbookWebTests
{
    [TestFixture]
    public class ContactCreator : BaseTest
    {

        [Test]
        public void CreateContact()
        {
            app.Nav.OpenNewContactPage();
            app.ContactsWorker.FillinContactData(new ContactInfo("TheFirstName", "TheLastName"));
        }
        [Test]
        public void DeleteContact()
        {
            app.Nav.OpenHomePage();
            app.ContactsWorker.Delete(2);
        }
        [Test]
        public void EditContact()
        {
            app.Nav.OpenHomePage();
            app.ContactsWorker.Edit(3, new ContactInfo("TheFirstNameNEW", "TheLastNameNEW"));
        }
    }
}
