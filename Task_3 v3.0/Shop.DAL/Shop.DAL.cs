using Shop.DAL.Contracts;
using Shop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Shop.DAL
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlManager xmlman = new XmlManager();
            User[] people = xmlman.DisUser();
            List <User> newpeople =people.ToList();
            newpeople.Add(new User ("Test","Test@gmail.com","123456" ));
            xmlman.SerUser(newpeople.ToArray());
            Console.ReadLine();
        }
    }
}
