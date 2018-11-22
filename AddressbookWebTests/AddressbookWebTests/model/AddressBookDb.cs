using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookWebTests
{
    public class AddressBookDb : LinqToDB.Data.DataConnection
    {
        public AddressBookDb() : base("Addressbook") { }
        public ITable<GroupInfo> Groups
        {
            get
            {
                return GetTable<GroupInfo>();
            }
        }
        public ITable<ContactInfo> Contacts
        {
            get
            {
                return GetTable<ContactInfo>();
            }
        }
    }
}
