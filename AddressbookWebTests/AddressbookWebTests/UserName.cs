namespace SeleniumTests
{
    internal class UserName
    {
        public string Name { set; get; }
        public string Pass { set; get; }

        public UserName(string name, string pass)
        {
            this.Name = name;
            this.Pass = pass;
        }
    }
}