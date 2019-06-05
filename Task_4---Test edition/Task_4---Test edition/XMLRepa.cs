using System;
using System.Xml.Linq;
using Task_4___Test_edition.Products;

namespace Task_4___Test_edition
{
    class XMLRepa
    {
        string xml = @"C:\Users\Хозяйн\source\repos\Task_4---Test edition\Task_4---Test edition\Product.xml";

        public void SetProducts<T>(T obj)where T: Product 
        {
            Car car = new Car();
            Phone phone = new Phone();
            Sneakers sneak = new Sneakers();

            XDocument xdoc = XDocument.Load(xml);
            if (obj.GetType()==car.GetType())
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
            xdoc.Save(xml);
            
        }
        public void GetProducts()
        {
            XDocument xdoc = XDocument.Load(xml);
            foreach (XElement prodElement in xdoc.Element("Products").Elements())
            {
                if (prodElement.Name == "Car")
                {
                    Car car=getCar(prodElement);
                    car.Show();
                    
                }
                 else if (prodElement.Name == "Phone")
                {
                    Phone phone =getPhone(prodElement);
                    phone.Show();

                }
                else if (prodElement.Name == "Sneakers")
                {
                    Sneakers sneak=getSneak(prodElement);
                    sneak.Show();

                }
                Console.WriteLine();
            }
        }
        public void Remove(string nameDelete)
        {
            XDocument xdoc = XDocument.Load(xml);
            foreach (XElement product in xdoc.Element("Products").Elements())
            {
                XAttribute nameAttribute = product.Attribute("Name");
                if (nameAttribute.Value == nameDelete)
                {
                    product.Remove();
                }
            }
            xdoc.Save(xml);
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
                car = new Car(nameAttribute.Value,manElement.Value,
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
