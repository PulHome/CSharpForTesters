using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookWebTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager app) : base(app) { }

        public void LogMeIn(AccountInfo user)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(user))
                {
                    return;
                }
                Logout();
            }
            TypeText(By.Name("user"), user.Name);
            TypeText(By.Name("pass"), user.Pass);
            driver.FindElement(By.Id("LoginForm")).Submit();
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public bool IsLoggedIn(AccountInfo account)
        {
            return IsLoggedIn() && driver.FindElement(By.Name("logout"))
                .FindElement(By.TagName("b")).Text == $"({account.Name})";
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }
    }
}
