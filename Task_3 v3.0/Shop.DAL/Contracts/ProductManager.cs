using Shop.DAL.Models;
using Shop.DAL.Models.Product_children;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Shop.DAL.Contracts
{
    public class ProductManager : Product
    {
        public new void Add()
        {
            XmlManager xml = new XmlManager();
            Car car = new Car();
            Phone phone = new Phone();
            Sneakers sneakers = new Sneakers();
            Console.WriteLine("Enter number\n1=Car\n2=Phone\n3=Sneakers");
            int quest = Int32.Parse(Console.ReadLine());
            switch (quest)
            {
                case 1:
                    car.Add();
                    xml.SetProducts(car);
                    break;
                case 2:
                    phone.Add();
                    xml.SetProducts(phone);
                    break;
                case 3:
                    sneakers.Add();
                    xml.SetProducts(sneakers);
                    break;
                default:; break;
            }
        }
        public void Remove()
        {
            XmlManager xml = new XmlManager();
            Console.WriteLine("Enter name Product");
            string delete = Console.ReadLine();
            xml.Remove(delete);
        }
        public new void Show()
        {
            XmlManager xml = new XmlManager();
            ProductsList productsList = ProductsList.ProductListIni();
            productsList = xml.GetProducts(productsList);
            foreach(var item in productsList.products)
            {
                item.Show();
            }
        }
        public void ShowCategory()
        {
            XmlManager xml = new XmlManager();
            ProductsList productsList = ProductsList.ProductListIni();
            productsList = xml.GetProducts(productsList);
            Console.WriteLine("1=Car\n2=Phone\n3=Sneakers\n4=AllProducts");
            switch (Int32.Parse(Console.ReadLine()))
            {
                case 1:
                    foreach (var item in productsList.cars)
                    {
                        item.Show();
                    }; break;
                case 2:
                    foreach (var item in productsList.phones)
                    {
                        item.Show();
                    }; break;
                case 3:
                    foreach (var item in productsList.sneakers)
                    {
                        item.Show();
                    }; break;
                case 4:
                    foreach (var item in productsList.products)
                    {
                        item.Show();
                    }; break;

            }
            
            
        }
        public void Search()
        {
            Console.WriteLine("Enter name Product");
            var search = Console.ReadLine();
            XmlManager xml = new XmlManager();
            var productsList = ProductsList.ProductListIni();
             productsList = xml.GetProducts(productsList);
            foreach (var item in productsList.cars)
            {
                if (item.Name == search)
                    item.Show();
            }
            foreach (var item in productsList.phones)
            {
                if (item.Name == search)
                    item.Show();
            }
            foreach (var item in productsList.sneakers)
            {
                if (item.Name == search)
                    item.Show();
            }
        }

    }    
}
