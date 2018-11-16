using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressbookWebTests
{
    public class ContactsHelper : HelperBase
    {
        public ContactsHelper(ApplicationManager app) : base(app) { }
        public void FillinContactData(ContactInfo contact)
        {
            TypeText(By.Name("firstname"), contact.FirstName);
            TypeText(By.Name("lastname"), contact.LastName);
            driver.FindElement(By.XPath("//*[@id=\"content\"]/form/input[@type=\'submit\']")).Click();
            this.contactsCache = null;
        }

        public ContactInfo GetContactInformationFromTable(int index)
        {
            manager.Nav.OpenHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));

            String lastName = cells[1].Text;
            String firstName = cells[2].Text;
            String address = cells[3].Text;
            String allPhones = cells[5].Text;
            return new ContactInfo
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                AllPhones = allPhones
            };
        }

        public ContactInfo GetContactInformationFromDetails(int index)
        {
            manager.Nav.OpenHomePage();
            InitContactDetails(index);

            string textData = driver.FindElement(By.XPath(@"//div[@id='content']")).Text;
            string[] splittedAllData = textData.Split(new[] { "\r\n\r\n" }, StringSplitOptions.None);

            string[] fullNameAndAddress = splittedAllData[0].Split(new[] { "\r\n" }, StringSplitOptions.None);
            string fullName = fullNameAndAddress[0];
            string address = (fullNameAndAddress.Length > 1) ? fullNameAndAddress[1] : "";

            string allPhones = getAllPhones(splittedAllData[1]);

            return new ContactInfo()
            {
                FullName = fullName,
                Address = address,
                AllPhones = allPhones
            };
        }

        private String getAllPhones(string phonesFromForm)
        {
            String retVal = "";
            retVal = String.Join("\n",
                phonesFromForm.Split(new[] { "\r\n" }, StringSplitOptions.None)
                                .Select(phone => phone.Substring(phone.IndexOf(':') + 1))
                );

            return retVal;
        }

        public ContactInfo GetContactInformationFromEditForm(int index = 0)
        {
            manager.Nav.OpenHomePage();
            InitContactModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            return new ContactInfo
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone
            };
        }


        // Deletes Contact by Id or last one if "-1" is provided
        public void Delete(int contactId)
        {
            if (contactId == -1)
            {
                driver.FindElement(By.XPath(@"(//tr[@name='entry']//input[@type='checkbox'])[last()]")).Click();
            }
            else
            {
                if (IsElementPresent(By.Id(contactId.ToString())))
                {
                    driver.FindElement(By.Id(contactId.ToString())).Click();
                }
            }

            driver.FindElement(By.XPath(@".//input[@onclick='DeleteSel()']")).Click();
            driver.SwitchTo().Alert().Accept();
            this.contactsCache = null;
        }

        public void Modify(int contactId, ContactInfo modifiedContact)
        {
            if (contactId == -1)
            {
                driver.FindElement(By.XPath("//tr[@name='entry'][last()]//a[contains(@href,'edit.php')]"))
                                 .Click();
            }
            else
            {
                if (IsElementPresent(By.Id(contactId.ToString())))
                {
                    driver.FindElement(By.XPath("//tr[@name='entry']//input[@type='checkbox'][last()]/parent::*/following-sibling::*//a[contains(@href,'edit.php?id='" + contactId.ToString() + ")]"))
     .Click();
                }
            }


            TypeText(By.Name("firstname"), modifiedContact.FirstName);
            TypeText(By.Name("lastname"), modifiedContact.LastName);
            driver.FindElement(By.Name("update")).Click();
            this.contactsCache = null;
        }

        private void InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .Click();
        }

        private void InitContactDetails(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .Click();
        }


        private List<ContactInfo> contactsCache = null;
        public List<ContactInfo> GetContactsList()
        {
            if (this.contactsCache == null)
            {
                contactsCache = new List<ContactInfo>();
                manager.Nav.OpenContactPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name=entry]"));
                foreach (IWebElement element in elements)
                {
                    var items = element.FindElements(By.CssSelector("td"));
                    contactsCache.Add(new ContactInfo(items[2].Text, items[1].Text));
                }
            }
            return new List<ContactInfo>(contactsCache);
        }

        public bool CheckAtLeastOneContactExists()
        {
            if (IsElementPresent(By.XPath(@"//tr//td/input[@type='checkbox'][1]")))
            {
                return true;
            }
            return false;
        }

        public void Edit(int contactId, ContactInfo data)
        {

            try
            {
                driver.FindElement(By.XPath(String.Format(@"//*[@id='maintable']/tbody/.//a[@href='edit.php?id={0}']", contactId.ToString()))).Click();
            }

            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
            FillinContactData(data);
        }

    }
}
