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
        
        public NavigationHelper(IWebDriver driver) : base(driver) { }

        public void OpenNewContactPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
        public void OpenGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void OpenHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }
        public void OpenUrl(String baseUrl)
        {
            driver.Navigate().GoToUrl(baseUrl);
        }

    }
}
