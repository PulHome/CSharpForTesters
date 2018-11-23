using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AddressbookWebTests
{
    [Table(Name = "addressbook")]
    public class ContactInfo : IEquatable<ContactInfo>, IComparable<ContactInfo>
    {
        [Column(Name = "firstname")]
        public string FirstName { set; get; }

        [Column(Name = "lastname")]
        public string LastName { set; get; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "home")]
        public string HomePhone { get; set; }

        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }

        [Column(Name = "work")]
        public string WorkPhone { get; set; }

        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }


        [Column(Name = "deprecated")]
        public DateTime Deprecated { get; set; }


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

        public static List<ContactInfo> GetAllContactsFromDb()
        {
            List<ContactInfo> contactsFromDb = new List<ContactInfo>();
            using (AddressBookDb db = new AddressBookDb())
            {
                //select all
                contactsFromDb = (from contact in db.Contacts
                                  //where contact.Deprecated == DateTime.MinValue // not working due to Date types mismatch :(
                                  select contact
                                  ).ToList();
                //then filter
                contactsFromDb = contactsFromDb.Where(c => c.Deprecated == DateTime.MinValue).ToList();
                return contactsFromDb;
            }
        }

    }
}