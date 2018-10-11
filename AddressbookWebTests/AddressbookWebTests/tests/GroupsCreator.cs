using System;
using NUnit.Framework;


namespace AddressbookWebTests
{
    [TestFixture]
    public class GroupsCreator : BaseTest
    {
        [Test]
        public void CreateAGroup()
        {
            app.GroupWorker.OpenAddNewGroupMenu();
            app.GroupWorker.CreateGroupWithInfo(new GroupInfo("name", "header", "footer"));
            
        }
        [Test]
        public void CreateAnEmptyGroup()
        {
            app.GroupWorker.OpenAddNewGroupMenu();
            app.GroupWorker.CreateGroupWithInfo(new GroupInfo("", "", ""));
        }

        [Test]
        public void DeleteGroup()
        {
            app.GroupWorker.OpenAddNewGroupMenu();
            app.GroupWorker.CreateGroupWithInfo(new GroupInfo("name", "header", "footer"));
            app.Nav.OpenGroupsPage();
            app.GroupWorker.DeleteGroup(-1);
        }
    }
}
