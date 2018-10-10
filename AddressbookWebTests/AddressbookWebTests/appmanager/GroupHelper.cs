using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookWebTests
{
    public class GroupHelper : HelperBase
    {

        public GroupHelper(IWebDriver driver) : base(driver) { }

        public void CreateGroupWithInfo(GroupInfo myGroup)
        {
            CreateGroup(myGroup.GroupName);
            CreateHeader(myGroup.HeaderText);
            CreateFooter(myGroup.FooterText);
            driver.FindElement(By.Name("submit")).Click();
        }

        public void CreateFooter(String footerText)
        {
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(footerText);
        }

        public void CreateHeader(String headerText)
        {
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(headerText);
        }

        public void CreateGroup(String groupName)
        {
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(groupName);
        }
        public void AddNewGroup()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            driver.FindElement(By.Id("content")).Click();
            driver.FindElement(By.Name("new")).Click();
        }
    }
}
