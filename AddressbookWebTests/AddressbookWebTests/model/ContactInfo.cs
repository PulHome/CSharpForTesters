using System;
using System.Text.RegularExpressions;

namespace AddressbookWebTests
{
    public class ContactInfo : IEquatable<ContactInfo>, IComparable<ContactInfo>
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }

        public string AllEmails { get; set; }

        private string allPhones;
        public string AllPhones
        {
            get
            {
                if (allPhones != null && allPhones != "")
                {
                    return allPhones;
                }
                else
                    return CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone);
            }
            set
            {
                allPhones = CleanUp(value);
            }
        }

        private string fullName;
        public string FullName
        {
            get
            {
                if (fullName != null)
                {
                    return fullName;
                }
                else
                    return FirstName + " " + LastName;
            }
            set
            {
                fullName = value;
            }
        }

        public String GetFullString()
        {
            return FullName + Address + AllPhones + AllEmails;
        }

        private string CleanUp(string phone)
        {
            if (phone == null)
            {
                return "";
            }
            Regex regex = new Regex(@"[-\s()]");
            return regex.Replace(phone, "");
        }

        public ContactInfo(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public ContactInfo()
        {
            AllPhones = "";

        }
        public bool Equals(ContactInfo other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(other, null)) return true;

            if (FullName == "" && other.FullName == "")
            {
                return LastName == other.LastName && FirstName == other.FirstName;
            }
            else
            {
                if (FullName == "")
                {
                    FullName = FirstName + LastName;
                }
                if (other.FullName == "")
                {
                    other.FullName = other.FirstName + other.LastName;
                }
                return other.FullName == FullName;
            }
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