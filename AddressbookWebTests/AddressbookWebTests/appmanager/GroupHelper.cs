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

        public GroupHelper(ApplicationManager app) : base(app) { }

        public void CreateGroupWithInfo(GroupInfo myGroup)
        {
            CreateGroup(myGroup.GroupName);
            CreateHeader(myGroup.HeaderText);
            CreateFooter(myGroup.FooterText);
            driver.FindElement(By.Name("submit")).Click();
            driver.FindElement(By.LinkText("group page")).Click();
        }

        public List<GroupInfo> GetGroupList()
        {
            manager.Nav.OpenGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            return elements.Select(x => new GroupInfo(x.Text)).ToList();
        }

        public void CreateFooter(String footerText)
        {
            TypeText(By.Name("group_footer"), footerText);
        }

        public bool CheckAtLeastOneGropExists()
        {
            if (IsElementPresent(By.XPath(@"//form/input[@name='new'][1]/following-sibling::span[@class='group']")))
            {
                return true;
            }
            return false;
        }

        internal void DeleteGroup(int id)
        {

            if (id == -1)
            {
                driver.FindElement(By.XPath(@"(//span//input[@type='checkbox'])[last()]")).Click();
            }
            else
            {
                driver.FindElement(By.XPath(@"(//span//input[@type='checkbox'])[" + (id + 1) + "]")).Click();
            }
            driver.FindElement(By.Name("delete")).Click();
        }

        public void CreateHeader(String headerText)
        {
            TypeText(By.Name("group_header"), headerText);
        }

        public void CreateGroup(String groupName)
        {
            TypeText(By.Name("group_name"), groupName);
        }

        public void OpenAddNewGroupMenu()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            driver.FindElement(By.Id("content")).Click();
            driver.FindElement(By.Name("new")).Click();
        }
        public void Create(GroupInfo info)
        {
            OpenAddNewGroupMenu();
            CreateGroupWithInfo(info);
        }

        public void ModifyGroup(int id, GroupInfo newGroup)
        {
            if (id == -1)
            {
                driver.FindElement(By.XPath(@"(//span//input[@type='checkbox'])[last()]")).Click();
            }
            else
            {
                driver.FindElement(By.XPath(@"(//span//input[@type='checkbox'])[" + (id + 1) + "]")).Click();
            }
            driver.FindElement(By.Name("edit")).Click();
            TypeText(By.Name("group_name"), newGroup.GroupName);
            driver.FindElement(By.Name("update")).Click();
        }
    }
}
