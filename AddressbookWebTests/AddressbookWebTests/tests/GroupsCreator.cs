using System;
using NUnit.Framework;


namespace AddressbookWebTests
{
    [TestFixture]
    public class GroupsCreator : BaseTest
    {
        private const string Url = "http://localhost/addressbook/edit.php";


        [Test]
        public void CreateAGroup()
        {
            app.Nav.OpenUrl(Url);
            app.Auth.LogMeIn(new UserName("Admin", "secret"));
            app.GroupWorker.AddNewGroup();
            app.GroupWorker.CreateGroupWithInfo(new GroupInfo("name", "header", "footer"));
            app.Auth.Logout();
        }

    }
}
