using System;
using System.Collections.Generic;
using NUnit.Framework;


namespace AddressbookWebTests
{
    [TestFixture]
    public class GroupsCreator : AuthTestBase
    {
        [Test]
        public void CreateAGroup()
        {
            var tempGroup = new GroupInfo("name", "header", "footer");

            List<GroupInfo> oldGroups = app.GroupWorker.GetGroupList();
            app.GroupWorker.OpenAddNewGroupMenu();
            app.GroupWorker.CreateGroupWithInfo(tempGroup);
            List<GroupInfo> newGroups = app.GroupWorker.GetGroupList();
            oldGroups.Add(tempGroup);
            oldGroups.Sort();
            oldGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
        [Test]
        public void CreateAGroupWithBadName()
        {
            List<GroupInfo> oldGroups = app.GroupWorker.GetGroupList();
            app.GroupWorker.OpenAddNewGroupMenu();
            app.GroupWorker.CreateGroupWithInfo(new GroupInfo("name'name", "header", "footer"));
            List<GroupInfo> newGroups = app.GroupWorker.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
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
            app.Nav.OpenGroupsPage();
            if (!app.GroupWorker.CheckAtLeastOneGropExists())
            {
                app.GroupWorker.OpenAddNewGroupMenu();
                app.GroupWorker.CreateGroupWithInfo(new GroupInfo("name", "header", "footer"));
            }
            List<GroupInfo> oldGroups = app.GroupWorker.GetGroupList();

            app.Nav.OpenGroupsPage();
            app.GroupWorker.DeleteGroup(0);
            List<GroupInfo> newGroups = app.GroupWorker.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void ModifyGroup()
        {
            GroupInfo modifiedGroup = new GroupInfo("Modified");

            app.Nav.OpenGroupsPage();
            if (!app.GroupWorker.CheckAtLeastOneGropExists())
            {
                app.GroupWorker.OpenAddNewGroupMenu();
                app.GroupWorker.CreateGroupWithInfo(new GroupInfo("name", "header", "footer"));
            }
            List<GroupInfo> oldGroups = app.GroupWorker.GetGroupList();

            app.Nav.OpenGroupsPage();
            app.GroupWorker.ModifyGroup(-1, modifiedGroup);
            List<GroupInfo> newGroups = app.GroupWorker.GetGroupList();
            oldGroups[oldGroups.Count - 1] = modifiedGroup;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
