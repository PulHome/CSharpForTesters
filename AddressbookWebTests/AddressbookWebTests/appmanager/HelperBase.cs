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

        public HelperBase(ApplicationManager app)
        {
            this.driver = app.Driver;
        }
    }
}
