using Shop.DAL.Models;
using Shop.DAL.Models.Product_children;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Shop.DAL.Contracts
{
    public class ProductManager : Product
    {
        string fileProduct = @"C:\Users\Хозяйн\Documents\asp.net-mvc repa\Task_3 v3.0\Shop.DAL\Repositories\Products.xml";
        public void Add()
        {
            XmlManager xml = new XmlManager();
            Car car = new Car();
            Phone phone = new Phone();
            Sneakers sneakers = new Sneakers();
            Console.WriteLine("Какой продукт хотите добавить\n1=Car\n2=Phone\n3=Sneakers");
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
        public void Show()
        {
            XmlManager xml = new XmlManager();
            ProductsList productsList = ProductsList.ProductListIni();
            productsList = xml.GetProducts(productsList);
            foreach(var item in productsList.products)
            {
                item.Show();
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
