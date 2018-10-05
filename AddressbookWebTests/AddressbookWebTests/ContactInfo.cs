namespace SeleniumTests
{
    internal class ContactInfo
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }

        public ContactInfo(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}