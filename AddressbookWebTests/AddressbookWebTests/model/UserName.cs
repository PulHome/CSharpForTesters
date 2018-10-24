namespace AddressbookWebTests
{
    public class AccountInfo
    {
        public string Name { set; get; }
        public string Pass { set; get; }

        public AccountInfo(string name, string pass)
        {
            this.Name = name;
            this.Pass = pass;
        }
    }
}