using System;
using System.Collections.Generic;
using NUnit.Framework;


namespace AddressbookWebTests
{
    [TestFixture]
    public class GroupsCreator : AuthTestBase
    {
        [Test, TestCaseSource("RandomGropDataGenerator")]
        public void CreateAGroup(GroupInfo newGroup)
        {
            List<GroupInfo> oldGroups = app.GroupWorker.GetGroupList();
            app.GroupWorker.OpenAddNewGroupMenu();
            app.GroupWorker.CreateGroupWithInfo(newGroup);
            //fast check if the number of items is the same 
            Assert.AreEqual(oldGroups.Count + 1, app.GroupWorker.GetGroupCount());

            List<GroupInfo> newGroups = app.GroupWorker.GetGroupList();
            oldGroups.Add(newGroup);
            oldGroups.Sort();
            oldGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
        [Test, Ignore("Known bug")]
        public void CreateAGroupWithBadName()
        {
            List<GroupInfo> oldGroups = app.GroupWorker.GetGroupList();
            app.GroupWorker.OpenAddNewGroupMenu();
            app.GroupWorker.CreateGroupWithInfo(new GroupInfo("name'name", "header", "footer"));
            Assert.AreEqual(oldGroups.Count + 1, app.GroupWorker.GetGroupCount());

            List<GroupInfo> newGroups = app.GroupWorker.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }

        [Test]
        public void CreateAnEmptyGroup()
        {
            List<GroupInfo> oldGroups = app.GroupWorker.GetGroupList();
            app.GroupWorker.OpenAddNewGroupMenu();
            app.GroupWorker.CreateGroupWithInfo(new GroupInfo("", "", ""));
            //fast check if the number of items is the same 
            Assert.AreEqual(oldGroups.Count + 1, app.GroupWorker.GetGroupCount());

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
            String oldId = oldGroups[0].Id;
            app.Nav.OpenGroupsPage();
            app.GroupWorker.DeleteGroup(0);

            //fast check if the number of items is the same 
            Assert.AreEqual(oldGroups.Count - 1, app.GroupWorker.GetGroupCount());


            List<GroupInfo> newGroups = app.GroupWorker.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (var group in newGroups)
            {
                Assert.AreNotEqual(group.Id, oldId);
            }
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
            GroupInfo oldGroup = oldGroups[oldGroups.Count - 1];
            app.Nav.OpenGroupsPage();
            app.GroupWorker.ModifyGroup(-1, modifiedGroup);

            //fast check if the number of items is the same 
            Assert.AreEqual(oldGroups.Count, app.GroupWorker.GetGroupCount());

            List<GroupInfo> newGroups = app.GroupWorker.GetGroupList();
            oldGroups[oldGroups.Count - 1] = modifiedGroup;

            Assert.AreEqual(oldGroups, newGroups);
            foreach (var group in newGroups)
            {
                if (group.Id == oldGroups[oldGroups.Count - 1].Id)
                {
                    Assert.AreEqual(group.GroupName, modifiedGroup.GroupName);
                }
            }
        }
        public static IEnumerable<GroupInfo> RandomGropDataGenerator()
        {
            List<GroupInfo> groups = new List<GroupInfo>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupInfo(GenerateRandomString(30))
                {
                    HeaderText = GenerateRandomString(50),
                    FooterText = GenerateRandomString(50)
                });
            }
            return groups;
        }

        
    }
}
