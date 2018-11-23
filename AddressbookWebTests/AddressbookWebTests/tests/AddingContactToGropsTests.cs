using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Linq;
using System.Threading;

namespace AddressbookWebTests
{
    [TestFixture]
    public class AddingContactToGropsTests : AuthTestBase
    {
        [Test]
        public void AddingAContactToGroup()
        {
            //select a group and save old data
            GroupInfo group = GroupInfo.GetAllGroupsFromDb()[0];
            List<ContactInfo> oldList = group.GetContacts();
            ContactInfo cont = ContactInfo.GetAllContactsFromDb().Except(oldList).First();
            //actions
            app.ContactsWorker.AddContactToGroup(cont, group);

            List<ContactInfo> newList = group.GetContacts();
            oldList.Add(cont);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
        [Test]
        public void RemovingAContactFromGroup()
        {
            //select a group and save old data
            GroupInfo group = GroupInfo.GetAllGroupsFromDb()[0];
            List<ContactInfo> oldList = group.GetContacts();
            ContactInfo cont = oldList[0];

            app.ContactsWorker.RemoveContactFromGroup(cont, group);

            List<ContactInfo> newList = group.GetContacts();
            oldList.Remove(cont);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}