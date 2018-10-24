using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookWebTests
{
    public class NavigationHelper : HelperBase
    {

        public NavigationHelper(ApplicationManager app) : base(app) { }

        public void OpenNewContactPage()
        {
            if (driver.Url.Contains("edit.php")
                && IsElementPresent(By.TagName("h1"))
                && driver.FindElement(By.TagName("h1")).Text.Contains("add address"))
            {
                return;
            }

            driver.FindElement(By.LinkText("add new")).Click();
        }
        public void OpenGroupsPage()
        {
            if (driver.Url.Contains("/addressbook/group.php") && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();

        }
        public void OpenAddGroupPage()
        {
            if (driver.Url.Contains("/addressbook/group.php") 
                && IsElementPresent(By.XPath(@"//form/input[@type='submit'][@value='Enter information']")))
            {
                return;
            }
            OpenGroupsPage();
            driver.FindElement(By.Name("new")).Click();
        }

        public void OpenHomePage()
        {
            if (driver.Url == this.BaseUrl && IsElementPresent(By.LinkText("Last name")))
            {
                return;
            }
            driver.FindElement(By.LinkText("home")).Click();

        }
        public void OpenUrl(String baseUrl)
        {
            driver.Navigate().GoToUrl(baseUrl);
        }

    }
}
