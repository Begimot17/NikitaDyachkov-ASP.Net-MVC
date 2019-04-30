using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task_3.Class
{
    class UserReg
    {
        public string name;
        public string email;
        public string pass;
        public UserReg()
        {
        }
        public UserReg(string name, string email, string pass)
        {
            this.name = name;
            this.email = email;
            this.pass = pass;
        }
        public static void ToList(string file, out List<UserReg> users)
        {
            users = new List<UserReg>();
            XDocument xdoc = XDocument.Load(file);
            foreach (XElement user in xdoc.Element("Employees").Elements("Employee"))
            {
                XAttribute username = user.Attribute("Name");
                XElement useremail = user.Element("Email");
                XElement userpass = user.Element("PassWord");

                if (username != null && useremail != null && userpass != null)
                {
                    users.Add(new UserReg(username.Value, useremail.Value, userpass.Value));
                }
            }
        }
        public static List<UserReg> UserList()
        {
            List<UserReg> users = new List<UserReg>();
            string file = @"C:\Users\Хозяйн\Documents\Институт\Lecture 3\xDoc.xml";
            ToList(file, out users);
            return users;
        }
    }
}
