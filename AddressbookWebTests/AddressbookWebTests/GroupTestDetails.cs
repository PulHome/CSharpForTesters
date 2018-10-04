using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookWebTests
{
    class GroupTestDetails
    {

        public String GroupName { set; get; }
        public String HeaderText { set; get; }
        public String FooterText { set; get; }

        public GroupTestDetails(string name = "The Big 5", string header = "SomeHeaderText", string footer = "SomeFooterText")
        {
            GroupName = name;
            HeaderText = header;
            FooterText = footer;
        }
    }
}