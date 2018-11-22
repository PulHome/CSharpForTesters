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
            this.groupCache = null;
            driver.FindElement(By.LinkText("group page")).Click();
        }
        private List<GroupInfo> groupCache = null;

        public List<GroupInfo> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupInfo>();
                manager.Nav.OpenGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));

                groupCache = elements.Select(
                    x => new GroupInfo(x.Text) { Id = x.FindElement(By.TagName("input")).GetAttribute("value") }
                    ).ToList();
            }
            return new List<GroupInfo>(groupCache);
        }

        public int GetGroupCount()
        {
            manager.Nav.OpenGroupsPage();
            return driver.FindElements(By.CssSelector("span.group")).Count;
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

        public void DeleteGroup(int id)
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
            this.groupCache = null;
        }

        public void DeleteGroup(GroupInfo toBeRemoved)
        {
            String id = toBeRemoved.Id;
            driver.FindElement(By.XPath(@"//span//input[@type='checkbox' and @value='" + id + "']")).Click();
            driver.FindElement(By.Name("delete")).Click();
            this.groupCache = null;
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

        public void ModifyGroup(int id, GroupInfo toBeModified, string modifiedHeader)
        {
            driver.FindElement(By.XPath(@"//span//input[@type='checkbox' and @value='" + toBeModified.Id + "']")).Click();
            driver.FindElement(By.Name("edit")).Click();
            TypeText(By.Name("group_name"), modifiedHeader);
            driver.FindElement(By.Name("update")).Click();
            this.groupCache = null;
        }
    }
}
