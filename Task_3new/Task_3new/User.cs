using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task_3new
{
    class User
    {
        public string Name;
        public string Email;
        public string Pass;
        string file = @"C:\Users\Хозяйн\source\repos\Task_3new\Task_3new\Xml\User.xml";
        public User()
        {
        }
        public User(string name, string email, string pass)
        {
            Name = name;
            Email = email;
            Pass = pass;
        }
        public  List<User> ListUsers()
        {
            List<User> users = new List<User>();
            XDocument xdoc = XDocument.Load(file);
            foreach (XElement user in xdoc.Element("Users").Elements("User"))
            {
                XAttribute username = user.Attribute("Name");
                XElement useremail = user.Element("Email");
                XElement userpass = user.Element("Password");

                if (username != null && useremail != null && userpass != null)
                {
                    users.Add(new User(username.Value, useremail.Value, userpass.Value));
                }
            }
            return users;
        }
        public void NewUser()
        {
            XDocument xDoc = XDocument.Load(file);
            XNode xNewNode = new XElement("User", new XAttribute("Name", Name),
                new XElement("Email", Email),
                new XElement("Password",Pass));
            xDoc.Root.Add(xNewNode);
            xDoc.Save(file);
        }
    }
}
