using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookWebTests
{
    public class GroupInfo : IEquatable<GroupInfo>, IComparable<GroupInfo>
    {

        public String GroupName { set; get; }
        public String HeaderText { set; get; }
        public String FooterText { set; get; }
        public String Id { set; get; }

        public GroupInfo(string name = "The Big 5", string header = "SomeHeaderText", string footer = "SomeFooterText")
        {
            GroupName = name;
            HeaderText = header;
            FooterText = footer;
        }
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
            return $"Name = {GroupName}";
        }

        public int CompareTo(GroupInfo other)
        {
            if (Object.ReferenceEquals(other, null)) return 1;
            return GroupName.CompareTo(other.GroupName);
        }
    }
}