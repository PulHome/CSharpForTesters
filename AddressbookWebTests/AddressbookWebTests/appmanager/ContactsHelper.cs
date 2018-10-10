using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookWebTests
{
    public class ContactsHelper : HelperBase
    {
        public ContactsHelper(ApplicationManager app) : base(app) { }
        public void FillinContactData(ContactInfo contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            driver.FindElement(By.XPath("//*[@id=\"content\"]/form/input[@type=\'submit\']")).Click();
        }

        public void Delete(int contactId)
        {
            // ID Выдаются по-порядку. Надо писать более сложный тест, который создает контакт, сохраняет ID и его потом удаляет по ID, 
            // который карантированно присутствует. :( Это имелось ввиду? В лекциях специалдьно не было?
            try
            {
                driver.FindElement(By.Id(contactId.ToString())).Click();
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }

            driver.FindElement(By.XPath(@".//input[@onclick='DeleteSel()']")).Click();
            driver.SwitchTo().Alert().Accept();
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
