using System.Collections.Generic;
using NUnit.Framework;

namespace AddressbookWebTests
{
    public class GroupTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareGroupsUiDb()
        {
            if (ENABLED_DETAILED_CHECKS)
            {
                List<GroupInfo> fromUi = app.GroupWorker.GetGroupList();
                List<GroupInfo> fromDb = GroupInfo.GetAllGroupsFromDb();
                fromUi.Sort();
                fromDb.Sort();
                Assert.AreEqual(fromUi, fromDb);
            }
        }
    }
}
