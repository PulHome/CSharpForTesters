using OpenQA.Selenium;
using System;


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
        }

        public void Modify(int contactId, ContactInfo modifiedContact)
        {
            if (contactId == -1)
            {
                driver.FindElement(By.XPath("//tr[@name='entry']//input[@type='checkbox'][last()]/parent::*/following-sibling::*//a[contains(@href,'edit.php')]"))
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
