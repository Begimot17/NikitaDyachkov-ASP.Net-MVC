using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Task_3new
{
    class XmlManager
    {
        public static bool AddProduct(string Name,Products prod,string path)
        {
            XDocument xdoc = XDocument.Load(path);
            xdoc.Root.Add(new XElement("Cart",
            new XAttribute("NameUser", Name),
            new XElement("Name", prod.Name),
            new XElement("Discription", prod.Description),
            new XElement("Type", prod.Type),
            new XElement("Price", prod.Price)));
            xdoc.Save(path);
            return true;
        }
        public static bool AddProduct(string path, Products product)
        {
            XDocument xDoc = XDocument.Load(path);
            XNode xNewNode = new XElement("Product", new XAttribute("Name", product.Name),
                new XElement("Description", product.Description),
                new XElement("Type", product.Type),
                new XElement("Price", product.Price));
            xDoc.Root.Add(xNewNode);
            xDoc.Save(path);
            return true;
        }
        public static bool Remove(string path, string nameDelete)
        {
            XDocument xDoc = XDocument.Load(path);
            foreach (XElement xNode in xDoc.Root.Nodes())
            {
                if (xNode.Attribute("Name").Value == nameDelete)
                {
                    xNode.Remove();
                }
            }
            xDoc.Save(path);
            return true;
        }
        public static  List<Cart> CartsList(string NameUs, string path)
        {
            List<Cart> cart = new List<Cart>();
            XDocument xdoc = XDocument.Load(path);
            foreach (XElement prod in xdoc.Element("Carts").Elements("Cart"))
            {
                XAttribute NameUser = prod.Attribute("NameUser");
                XElement Name = prod.Element("Name");
                XElement Discription = prod.Element("Discription");
                XElement Type = prod.Element("Type");
                XElement Price = prod.Element("Price");
                if (NameUser.Value == NameUs)
                    cart.Add(new Cart(NameUser.Value, Name.Value, Discription.Value, Type.Value, Convert.ToDecimal(Price.Value)));
            }
            return cart;
        }
        public static bool RemoveProduct(string Name , string path)
        {
            Console.WriteLine("Enter name delete");
            string nameDelete = Console.ReadLine();
            XDocument xDoc = XDocument.Load(path);
            foreach (XElement xNode in xDoc.Root.Nodes())
            {
                if (xNode.Element("Name").Value == nameDelete && xNode.Attribute("NameUser").Value == Name)
                {
                    xNode.Remove();
                    break;
                }
            }
            xDoc.Save(path);
            return true;

        }
        public static List<Products> ProductList(string path)
        {
            List<Products> product = new List<Products>();
            XDocument xdoc = XDocument.Load(path);
            foreach (XElement prod in xdoc.Element("Products").Elements("Product"))
            {
                XAttribute Name = prod.Attribute("Name");
                XElement Description = prod.Element("Description");
                XElement Type = prod.Element("Type");
                XElement Price = prod.Element("Price");


                if (Name != null && Description != null && Type != null && Price != null)
                {
                    product.Add(new Products(Name.Value, Description.Value, Type.Value, Convert.ToInt32(Price.Value)));
                }
            }
            return product;
        }
        public static void NewUser(string file , User newUser)
        {
            XDocument xDoc = XDocument.Load(file);
            XNode xNewNode = new XElement("User", new XAttribute("Name", newUser.Name),
                new XElement("Email", newUser.Email),
                new XElement("Password", newUser.Pass));
            xDoc.Root.Add(xNewNode);
            xDoc.Save(file);
        }
        public static  List<User> ListUsers(string file)
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
    }

}
