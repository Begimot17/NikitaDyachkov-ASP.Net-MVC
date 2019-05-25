using Shop.DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Shop.DAL.Contracts
{
    public class XmlManager
    {
        
        
        public const string fileUser= @"C:\Users\Хозяйн\Documents\asp.net-mvc repa\Task_3 v3.0\Shop.DAL\Repositories\Users.xml";
        public void AddProduct(string Name, Product prod, string fileCart)
        {
            XDocument xdoc = XDocument.Load(fileCart);
            xdoc.Root.Add(new XElement("Cart",
            new XAttribute("NameUser", Name),
            new XElement("Name", prod.Name),
            new XElement("Discription", prod.Description),
            new XElement("Type", prod.Type),
            new XElement("Price", prod.Price)));
            xdoc.Save(fileCart);
            return ;
        }
        public bool AddProduct(Product product, string fileProduct)
        {
            XmlManager xmlman = new XmlManager();

            List<Product> ProdList = xmlman.DisProd(fileProduct).ToList();
            ProdList.Add(product);
            SerProd(ProdList.ToArray(), fileProduct);
            return true;
        }
        public bool Remove(string nameDelete, string fileProduct)
        {
            XDocument xdoc = XDocument.Load(fileProduct);
            foreach (XElement product in xdoc.Element("ArrayOfProduct").Elements("Product"))
            {
                
                XElement NameElement = product.Element("Name");

                if (NameElement.Value == nameDelete)
                {
                    product.Remove();
                }
            }
            xdoc.Save(fileProduct);
            return true;
        }
        public  List<Cart> CartsList(string NameUs, string fileCart)
        {
            List<Cart> cart = new List<Cart>();
            XDocument xdoc = XDocument.Load(fileCart);
            foreach (XElement prod in xdoc.Element("Carts").Elements("Cart"))
            {
                XAttribute NameUser = prod.Attribute("NameUser");
                XElement Name = prod.Element("Name");
                XElement Discription = prod.Element("Discription");
                XElement Type = prod.Element("Type");
                XElement Price = prod.Element("Price");
                if (NameUser.Value == NameUs)
                    cart.Add(new Cart(NameUser.Value, new Product(Name.Value, Discription.Value, Type.Value, Convert.ToInt32(Price.Value))));
            }
            return cart;
        }
        public void RemoveProduct(string Name, string namedelete, string fileCart)
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
            return;

        }
        public  void SerUser(User[] people)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(User[]));

            using (FileStream fs = new FileStream(fileUser, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, people);
            }
        }
        public  User[] DisUser()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(User[]));

            using (FileStream fs = new FileStream(fileUser, FileMode.OpenOrCreate))
            {
                User[] newpeople = (User[])formatter.Deserialize(fs);
                return newpeople;
            }
        }
        public  void SerProd(Product[] product, string fileProduct)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Product[]));

            using (FileStream fs = new FileStream(fileProduct, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, product);
            }
        }
        public  Product[] DisProd(string fileProduct)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Product[]));

            using (FileStream fs = new FileStream(fileProduct, FileMode.OpenOrCreate))
            {
                Product[] newpeople = (Product[])formatter.Deserialize(fs);
                return newpeople;
            }
        }
    }
}

