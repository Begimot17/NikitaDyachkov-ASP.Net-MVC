using Shop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shop.DAL.Contracts
{
    public class XmlManager
    {
        public const string fileCart= @"C:\Users\Хозяйн\source\repos\Task_3 v3.0\Shop.DAL\Repositories\Cart.xml";
        public const string fileProduct= @"C:\Users\Хозяйн\source\repos\Task_3 v3.0\Shop.DAL\Repositories\Product.xml";
        public const string fileUser= @"C:\Users\Хозяйн\source\repos\Task_3 v3.0\Shop.DAL\Repositories\User.xml";
        //public static bool AddProduct(string Name, Product prod)
        //{
        //    XDocument xdoc = XDocument.Load(fileCart);
        //    xdoc.Root.Add(new XElement("Cart",
        //    new XAttribute("NameUser", Name),
        //    new XElement("Name", prod.Name),
        //    new XElement("Discription", prod.Description),
        //   // new XElement("Type", prod.Type),
        //    new XElement("Price", prod.Price)));
        //    xdoc.Save(fileCart);
        //    return true;
        //}
        //public static bool AddProduct(Product product)
        //{
        //    XDocument xDoc = XDocument.Load(fileProduct);
        //    XNode xNewNode = new XElement("Product", new XAttribute("Name", product.Name),
        //        new XElement("Description", product.Description),
        //       // new XElement("Type", product.Type),
        //        new XElement("Price", product.Price));
        //    xDoc.Root.Add(xNewNode);
        //    xDoc.Save(fileProduct);
        //    return true;
        //}
        public static bool Remove(string nameDelete)
        {
            XDocument xDoc = XDocument.Load(fileProduct);
            foreach (XElement xNode in xDoc.Root.Nodes())
            {
                if (xNode.Attribute("Name").Value == nameDelete)
                {
                    xNode.Remove();
                }
            }
            xDoc.Save(fileProduct);
            return true;
        }
        //public static List<Cart> CartsList(string NameUs)
        //{
        //    List<Cart> cart = new List<Cart>();
        //    XDocument xdoc = XDocument.Load(fileCart);
        //    foreach (XElement prod in xdoc.Element("Carts").Elements("Cart"))
        //    {
        //        XAttribute NameUser = prod.Attribute("NameUser");
        //        XElement Name = prod.Element("Name");
        //        XElement Discription = prod.Element("Discription");
        //        XElement Type = prod.Element("Type");
        //        XElement Price = prod.Element("Price");
        //       // if (NameUser.Value == NameUs)
        //         //   cart.Add(new Cart(NameUser.Value, new Product(Name.Value, Discription.Value, Type.Value, Convert.ToInt32(Price.Value))));
        //    }
        //    return cart;
        //}
        public static bool RemoveProduct(string Name, string namedelete)
        {
            XDocument xDoc = XDocument.Load(fileCart);
            foreach (XElement xNode in xDoc.Root.Nodes())
            {
                if (xNode.Element("Name").Value == namedelete && xNode.Attribute("NameUser").Value == Name)
                {
                    xNode.Remove();
                    break;
                }
            }
            xDoc.Save(fileCart);
            return true;

        }
        public static List<Product> ProductList()
        {
            List<Product> product = new List<Product>();
            XDocument xdoc = XDocument.Load(fileProduct);
            foreach (XElement prod in xdoc.Element("Products").Elements("Product"))
            {
                XAttribute Name = prod.Attribute("Name");
                XElement Description = prod.Element("Description");
                XElement Type = prod.Element("Type");
                XElement Price = prod.Element("Price");


                if (Name != null && Description != null && Type != null && Price != null)
                {
                 //   product.Add(new Product(Name.Value, Description.Value, Type.Value, Convert.ToInt32(Price.Value)));
                }
            }
            return product;
        }
        public static void NewUser(User newUser)
        {
            XDocument xDoc = XDocument.Load(fileUser);
            XNode xNewNode = new XElement("User", new XAttribute("Name", newUser.Name),
                new XElement("Email", newUser.Email),
                new XElement("Password", newUser.Pass));
            xDoc.Root.Add(xNewNode);
            xDoc.Save(fileUser);
        }
        public static List<User> ListUsers()
        {
            List<User> users = new List<User>();
            XDocument xdoc = XDocument.Load(fileUser);
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

