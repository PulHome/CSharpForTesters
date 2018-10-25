using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookWebTests
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected string BaseUrl;
        protected ApplicationManager manager;

        public HelperBase(ApplicationManager app)
        {
            this.driver = app.Driver;
            this.BaseUrl = app.baseURL;
            this.manager = app;
        }
        public void TypeText(By by, string text)
        {
            if (text != null)
            {
                driver.FindElement(by).Click();
                driver.FindElement(by).Clear();
                driver.FindElement(by).SendKeys(text);
            }
        }
        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }
        }

    }
}
