using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;
using System.Threading;

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
        public string baseURL { get; private set; }

        private static ThreadLocal<ApplicationManager> instance = new ThreadLocal<ApplicationManager>();


        ~ApplicationManager()
        {
            try { driver.Quit(); }
            catch { }
        }
        public static ApplicationManager GetInstance(String baseURL = "http://localhost/addressbook/")
        {
            if (!instance.IsValueCreated)
            {
                ApplicationManager app = new ApplicationManager();
                app.baseURL = baseURL;
                app.Nav.OpenUrl(baseURL);
                //app.Auth.LogMeIn(new UserName("admin", "secret"));

                instance.Value = app;
            }
            return instance.Value;
        }

        private ApplicationManager(String baseURL = "http://localhost/addressbook/")
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/addressbook/";
            verificationErrors = new StringBuilder();
            loginHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this);
            groupHelper = new GroupHelper(this);
            contactsHelper = new ContactsHelper(this);
        }
        public NavigationHelper Nav { get { return navigationHelper; } }
        public LoginHelper Auth { get { return loginHelper; } }
        public GroupHelper GroupWorker { get { return groupHelper; } }
        public ContactsHelper ContactsWorker { get { return contactsHelper; } }

        public IWebDriver Driver { get { return this.driver; } }
    }
}
