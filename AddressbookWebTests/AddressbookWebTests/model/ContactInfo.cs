using System;

namespace AddressbookWebTests
{
    public class ContactInfo : IEquatable<ContactInfo>, IComparable<ContactInfo>
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }

        public ContactInfo(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public bool Equals(ContactInfo other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(other, null)) return true;
            return LastName == other.LastName && FirstName == other.FirstName;
        }
        public override int GetHashCode()
        {
            return LastName.GetHashCode() | FirstName.GetHashCode();
        }
        public override string ToString()
        {
            return $"LastFist = {LastName + " " + FirstName} ";
        }

        public int CompareTo(ContactInfo other)
        {
            if (Object.ReferenceEquals(other, null)) return 1;
            return (LastName.CompareTo(other.LastName) == 0) ? FirstName.CompareTo(other.FirstName) : LastName.CompareTo(other.LastName);
        }
    }
}