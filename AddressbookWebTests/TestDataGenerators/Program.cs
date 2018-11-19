using AddressbookWebTests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestDataGenerators
{
    class Program
    {
        static int Main(string[] args)
        {

            String whatToGenerate = args[0];
            int count = 0;
            int.TryParse(args[1], out count);
            String fileName = args[2];

            List<GroupInfo> groups = new List<GroupInfo>();
            List<ContactInfo> contacts = new List<ContactInfo>();

            if (whatToGenerate.Equals("group") || whatToGenerate.Equals("groups"))
            {
                groups = GenerateGroups(count);
                if (fileName.EndsWith(".csv"))
                {
                    WrtiteGroupsToCsvFile(fileName, groups);
                }
                else if (fileName.EndsWith(".xml"))
                {
                    WriteGroupsToXmlFile(fileName, groups);
                }
                else if (fileName.EndsWith(".json"))
                {
                    WriteGroupsToJsonFile(fileName, groups);
                }
                else
                {
                    Console.WriteLine("Unknown file format");
                    return 2;
                }
            }
            else if (whatToGenerate.Equals("contact") || whatToGenerate.Equals("contacts"))
            {
                contacts = GenerateContacts(count);
                if (fileName.EndsWith(".csv"))
                {
                    WriteContactsToCsvFile(fileName, contacts);
                }
                else if (fileName.EndsWith(".xml"))
                {
                    WriteContactsToXmlFile(fileName, contacts);
                }
                else if (fileName.EndsWith(".json"))
                {
                    WriteContactsToJsonFile(fileName, contacts);
                }
                else
                {
                    Console.WriteLine("Unknown file format");
                    return 2;
                }
            }
            else
            {
                Console.WriteLine("Format error!");
                return 1;
            }


            return 0;

        }

        private static List<GroupInfo> GenerateGroups(int count)
        {
            List<GroupInfo> groups = new List<GroupInfo>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupInfo()
                {
                    HeaderText = TestBase.GenerateRandomString(10),
                    FooterText = TestBase.GenerateRandomString(10),
                    GroupName = TestBase.GenerateRandomString(10)
                });
            }
            return groups;
        }
        private static List<ContactInfo> GenerateContacts(int count)
        {
            List<ContactInfo> contacts = new List<ContactInfo>();
            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactInfo()
                {
                    FirstName = TestBase.GenerateRandomString(10),
                    LastName = TestBase.GenerateRandomString(10),
                    Address = TestBase.GenerateRandomString(10)
                });
            }
            return contacts;
        }


        private static void WrtiteGroupsToCsvFile(string fileName, List<GroupInfo> groups)
        {
            StreamWriter sw = new StreamWriter(fileName);
            for (int i = 0; i < groups.Count; i++)
            {
                sw.WriteLine(String.Format("{0} {1} {2}",
                    groups[i].GroupName, groups[i].HeaderText, groups[i].FooterText));
            }
            sw.Close();

        }
        private static void WriteGroupsToXmlFile(string fileName, List<GroupInfo> groups)
        {
            StreamWriter sw = new StreamWriter(fileName);
            new XmlSerializer(typeof(List<GroupInfo>)).Serialize(sw, groups);
            sw.Close();
        }
        private static void WriteGroupsToJsonFile(string fileName, List<GroupInfo> groups)
        {
            StreamWriter sw = new StreamWriter(fileName);
            sw.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
            sw.Close();
        }
        private static void WriteContactsToCsvFile(string fileName, List<ContactInfo> contacts)
        {
            StreamWriter sw = new StreamWriter(fileName);
            for (int i = 0; i < contacts.Count; i++)
            {
                sw.WriteLine(String.Format("{0} {1} {2}",
                    contacts[i].FirstName, contacts[i].LastName, contacts[i].Address));
            }
            sw.Close();

        }
        private static void WriteContactsToXmlFile(string fileName, List<ContactInfo> contacts)
        {
            StreamWriter sw = new StreamWriter(fileName);
            new XmlSerializer(typeof(List<ContactInfo>)).Serialize(sw, contacts);
            sw.Close();
        }
        private static void WriteContactsToJsonFile(string fileName, List<ContactInfo> contacts)
        {
            StreamWriter sw = new StreamWriter(fileName);
            sw.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
            sw.Close();
        }
    }
}
