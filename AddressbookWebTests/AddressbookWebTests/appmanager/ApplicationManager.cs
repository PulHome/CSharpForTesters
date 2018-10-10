﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;


namespace AddressbookWebTests
{
    public class ApplicationManager
    {
        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;
        protected ContactsHelper contactsHelper;

        protected IWebDriver driver;
        protected StringBuilder verificationErrors;
        protected string baseURL;

        public void Stop()
        {
            driver.Quit();
        }

        public ApplicationManager(String baseURL= "http://localhost/addressbook/")
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/addressbook/";
            verificationErrors = new StringBuilder();
            loginHelper = new LoginHelper(driver);
            navigationHelper = new NavigationHelper(driver);
            groupHelper = new GroupHelper(driver);
            contactsHelper = new ContactsHelper(driver);
        }
        public NavigationHelper Nav { get { return navigationHelper; } }
        public LoginHelper Auth { get { return loginHelper; } }
        public GroupHelper GroupWorker { get { return groupHelper; } }
        public ContactsHelper ContactsWorker { get { return contactsHelper; } }

    }
}
