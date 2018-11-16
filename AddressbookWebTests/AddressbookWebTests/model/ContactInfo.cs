﻿using System;
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

        private string allPhones;
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                    return CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone);
            }
            set
            {
                allPhones = value;
            }
        }
        
        private string CleanUp(string phone)
        {
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