using Shop.DAL.Models;
using Shop.DAL.Models.Product_children;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Shop.DAL.Contracts
{
    public class XmlManager
    {
        string xmlprod = @"C:\Users\Хозяйн\Documents\asp.net-mvc repa\Task_3 v3.0\Shop.DAL\Repositories\Products.xml";
        string xmlcart = @"C:\Users\Хозяйн\Documents\asp.net-mvc repa\Task_3 v3.0\Shop.DAL\Repositories\Carts.xml";
        public void setCart(string nameuser, Product prod)
        {
            XDocument xdoc = XDocument.Load(xmlcart);
            XElement root = xdoc.Element("Carts");
            root.Add(new XElement("Cart",
            new XAttribute("NameUser", nameuser),
            new XElement("Name", prod.Name),
            new XElement("Manufactur", prod.Manufactur),
            new XElement("Description", prod.Description),
            new XElement("Currency", prod.Currency),
            new XElement("Price", prod.Price)
            ));
            xdoc.Save(xmlcart);
            
        }
        public Cart getCarts (string name)
        {
            XDocument xdoc = XDocument.Load(xmlcart);
            Cart cart = new Cart();
            cart.ProdList = new List<Product>();
            
            foreach (XElement prodElement in xdoc.Element("Carts").Elements())
            {
                Product product = new Product();
                XAttribute nameAttribute = prodElement.Attribute("NameUser");
                XElement nameElement = prodElement.Element("Name");
                XElement manElement = prodElement.Element("Manufactur");
                XElement descElement = prodElement.Element("Description");
                XElement priceElement = prodElement.Element("Price");
                XElement currElement = prodElement.Element("Currency");
                if (nameAttribute.Value==name)
                {
                    cart.NameUser = nameAttribute.Value;
                    cart.ProdList.Add(new Product(nameElement.Value, manElement.Value,
                          descElement.Value, currElement.Value,
                          Convert.ToInt32(priceElement.Value)));
                }
            }
            return cart;
        }
        
        public void RemoveProduct(string Name, string namedelete)
        {
            XDocument xDoc = XDocument.Load(xmlcart);
            foreach (XElement xNode in xDoc.Root.Nodes())
            {
                if (xNode.Element("Name").Value == namedelete && xNode.Attribute("NameUser").Value == Name)
                {
                    xNode.Remove();
                    break;
                }
            }
            xDoc.Save(xmlcart);
            return;

        }
        public void SerUser(User[] people, string fileUser)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(User[]));

            using (FileStream fs = new FileStream(fileUser, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, people);
            }
        }
        public User[] DisUser(string fileUser)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(User[]));

            using (FileStream fs = new FileStream(fileUser, FileMode.OpenOrCreate))
            {
                User[] newpeople = (User[])formatter.Deserialize(fs);
                return newpeople;
            }
        }
        public void SetProducts<T>(T obj) where T : Product
        {
            Car car = new Car();
            Phone phone = new Phone();
            Sneakers sneak = new Sneakers();

            XDocument xdoc = XDocument.Load(xmlprod);
            if (obj.GetType() == car.GetType())
            {
                setCar(xdoc, (Car)(object)obj);
            }
            else if (obj.GetType() == phone.GetType())
            {
                setPhone(xdoc, (Phone)(object)obj);
            }
            else if (obj.GetType() == sneak.GetType())
            {
                setSneak(xdoc, (Sneakers)(object)obj);
            }
            xdoc.Save(xmlprod);

        }
        public ProductsList GetProducts(ProductsList productsList)
        {
            
            XDocument xdoc = XDocument.Load(xmlprod);
            
            foreach (XElement prodElement in xdoc.Element("Products").Elements())
            {
                
                if (prodElement.Name == "Car")
                {
                    Car car = new Car();
                    car = getCar(prodElement);
                    productsList.cars.Add(car);
                    productsList.products.Add(car);

                }
                else if (prodElement.Name == "Phone")
                {
                    Phone phone = new Phone();
                    phone = getPhone(prodElement);
                    productsList.phones.Add(phone);
                    productsList.products.Add(phone);
                }
                else if (prodElement.Name == "Sneakers")
                {
                    Sneakers sneakers = new Sneakers();
                    sneakers = getSneak(prodElement);
                    productsList.sneakers.Add(sneakers);
                    productsList.products.Add(sneakers);
                }
            }
            return productsList;
        }
        public void Remove(string nameDelete)
        {
            XDocument xdoc = XDocument.Load(xmlprod);
            foreach (XElement product in xdoc.Element("Products").Elements())
            {
                XAttribute nameAttribute = product.Attribute("Name");
                if (nameAttribute.Value == nameDelete)
                {
                    product.Remove();
                }
            }
            xdoc.Save(xmlprod);
        }
        public void setCar(XDocument xdoc, Car car)
        {

            XElement root = xdoc.Element("Products");
            root.Add(new XElement("Car",
            new XAttribute("Name", car.Name),
            new XElement("Manufactur", car.Manufactur),
            new XElement("Description", car.Description),
            new XElement("Price", car.Price),
            new XElement("Currency", car.Currency),
            new XElement("Horsepower", car.Horsepower),
            new XElement("NumbOfWhel", car.NumbOfWhel)
            ));
        }
        public Car getCar(XElement prodElement)
        {
            Car car = new Car();
            XAttribute nameAttribute = prodElement.Attribute("Name");
            XElement manElement = prodElement.Element("Manufactur");
            XElement descElement = prodElement.Element("Description");
            XElement priceElement = prodElement.Element("Price");
            XElement currElement = prodElement.Element("Currency");
            XElement horseElement = prodElement.Element("Horsepower");
            XElement numbElement = prodElement.Element("NumbOfWhel");

            if (nameAttribute != null)
            {
                car = new Car(nameAttribute.Value, manElement.Value,
                    descElement.Value, currElement.Value,
                    Convert.ToInt32(priceElement.Value),
                    Convert.ToInt32(horseElement.Value),
                    Convert.ToInt32(numbElement.Value));
                return car;
            }
            return car;

        }
        public void setPhone(XDocument xdoc, Phone phone)
        {

            XElement root = xdoc.Element("Products");
            root.Add(new XElement("Phone",
            new XAttribute("Name", phone.Name),
            new XElement("Manufactur", phone.Manufactur),
            new XElement("Description", phone.Description),
            new XElement("Currency", phone.Currency),
            new XElement("Price", phone.Price),
            new XElement("Ram", phone.Ram),
            new XElement("Color", phone.Color)
            ));
        }
        public Phone getPhone(XElement prodElement)
        {
            Phone phone = new Phone();
            XAttribute nameAttribute = prodElement.Attribute("Name");
            XElement manElement = prodElement.Element("Manufactur");
            XElement descElement = prodElement.Element("Description");
            XElement currElement = prodElement.Element("Currency");
            XElement priceElement = prodElement.Element("Price");
            XElement horseElement = prodElement.Element("Ram");
            XElement numbElement = prodElement.Element("Color");

            if (nameAttribute != null)
            {
                phone = new Phone(nameAttribute.Value, manElement.Value,
                   descElement.Value, currElement.Value,
                   Convert.ToInt32(priceElement.Value),

                   numbElement.Value,
                   Convert.ToInt32(horseElement.Value));
                return phone;
            }
            return phone;

        }
        public void setSneak(XDocument xdoc, Sneakers sneak)
        {


            XElement root = xdoc.Element("Products");
            root.Add(new XElement("Sneakers",
            new XAttribute("Name", sneak.Name),
            new XElement("Manufactur", sneak.Manufactur),
            new XElement("Description", sneak.Description),
            new XElement("Currency", sneak.Currency),
            new XElement("Price", sneak.Price),
            new XElement("Size", sneak.Size),
            new XElement("Sex", sneak.Sex)
            ));
        }
        public Sneakers getSneak(XElement prodElement)
        {
            Sneakers sneakers = new Sneakers();
            XAttribute nameAttribute = prodElement.Attribute("Name");
            XElement manElement = prodElement.Element("Manufactur");
            XElement descElement = prodElement.Element("Description");
            XElement currElement = prodElement.Element("Currency");
            XElement priceElement = prodElement.Element("Price");
            XElement horseElement = prodElement.Element("Size");
            XElement numbElement = prodElement.Element("Sex");

            if (nameAttribute != null)
            {
                sneakers = new Sneakers(nameAttribute.Value, manElement.Value,
                   descElement.Value, currElement.Value,
                   Convert.ToInt32(priceElement.Value),
                   Convert.ToInt16(horseElement.Value),
                   Convert.ToChar(numbElement.Value));
                return sneakers;
            }
            return sneakers;

        }

    }
}

