using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookWebTests
{
    [Table(Name = "group_list")]
    public class GroupInfo : IEquatable<GroupInfo>, IComparable<GroupInfo>
    {
        [Column(Name = "group_name"), NotNull]
        public String GroupName { set; get; }

        [Column(Name = "group_header")]
        public String HeaderText { set; get; }

        [Column(Name = "group_footer")]
        public String FooterText { set; get; }

        [Column(Name = "group_id"), PrimaryKey, Identity]
        public String Id { set; get; }

        public GroupInfo(string name, string header = "SomeHeaderText", string footer = "SomeFooterText")
        {
            GroupName = name;
            HeaderText = header;
            FooterText = footer;
        }
        public GroupInfo() { }

        public bool Equals(GroupInfo other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(other, null)) return true;
            return GroupName == other.GroupName;
        }
        public override int GetHashCode()
        {
            return GroupName.GetHashCode();
        }
        public override string ToString()
        {
            return $"Name = {GroupName}\nHeader = {HeaderText}\nFooter = {FooterText}";
        }

        public int CompareTo(GroupInfo other)
        {
            if (Object.ReferenceEquals(other, null)) return 1;
            return GroupName.CompareTo(other.GroupName);
        }
        public static List<GroupInfo> GetAllGroupsFromDb()
        {
            List<GroupInfo> groupsFromDb = new List<GroupInfo>();
            using (AddressBookDb db = new AddressBookDb())
            {
                groupsFromDb = db.Groups.Select(group => group).ToList();
            }
            return groupsFromDb;
        }
    }
}