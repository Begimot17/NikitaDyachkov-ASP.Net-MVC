using Shop.DAL.Contracts;
using Shop.DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Shop.DAL
{
    class Program
    {
        static void Main(string[] args)
        {
            User[] people = XmlManager.DisUser();
            List <User> newpeople =people.ToList();
            newpeople.Add(new User ("Test","Test@gmail.com","123456" ));
            XmlManager.SerUser(newpeople.ToArray());
            Console.ReadLine();
        }
    }
}
