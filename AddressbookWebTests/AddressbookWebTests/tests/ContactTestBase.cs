using System.Collections.Generic;
using NUnit.Framework;

namespace AddressbookWebTests
{
    public class ContactTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareContactsUiDb()
        {
            if (ENABLED_DETAILED_CHECKS)
            {
                List<ContactInfo> fromUi = app.ContactsWorker.GetContactsList();
                List<ContactInfo> fromDb = ContactInfo.GetAllContactsFromDb();
                fromUi.Sort();
                fromDb.Sort();
                Assert.AreEqual(fromUi, fromDb);
            }
        }
    }
}
