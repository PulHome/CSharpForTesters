using System;
using System.Text;
using NUnit.Framework;

namespace AddressbookWebTests
{
    
    public class TestBase
    {
        public static Random rnd = new Random();

        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            app = ApplicationManager.GetInstance();
        }
        public static string GenerateRandomString(int max)
        {
            
            int length = rnd.Next(max);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                sb.Append(Convert.ToChar(rnd.Next((int)'a', (int)'z'))); //English letters
            }
            return sb.ToString();
        }

    }
}
