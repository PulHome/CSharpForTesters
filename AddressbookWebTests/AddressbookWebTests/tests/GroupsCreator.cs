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
            app.GroupWorker.AddNewGroup();
            app.GroupWorker.CreateGroupWithInfo(new GroupInfo("name", "header", "footer"));
            
        }
        [Test]
        public void CreateAnEmptyGroup()
        {
            app.GroupWorker.AddNewGroup();
            app.GroupWorker.CreateGroupWithInfo(new GroupInfo("", "", ""));
        }



    }
}
