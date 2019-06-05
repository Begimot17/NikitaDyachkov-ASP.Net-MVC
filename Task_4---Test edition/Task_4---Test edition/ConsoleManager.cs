using System;
using Task_4___Test_edition.Products;

namespace Task_4___Test_edition
{
    class ConsoleManager
    {
        public static void Add()
        {
            XMLRepa xml = new XMLRepa();
            Car car = new Car();
            Phone phone = new Phone();
            Sneakers sneakers = new Sneakers();
            Console.WriteLine("Какой продукт хотите добавить\n1=Car\n2=Phone\n3=Sneakers");
            int quest = Int32.Parse(Console.ReadLine());
            switch (quest)
            {
                case 1:
                    car.Add() ;
                    xml.SetProducts(car);
                    break;
                case 2:
                    phone.Add() ;
                    xml.SetProducts(phone);
                    break;
                case 3:
                    sneakers.Add();
                    xml.SetProducts(sneakers);
                    break;
                default:; break;
            }
        }
        public static void Remove()
        {
            XMLRepa xml = new XMLRepa();
            Console.WriteLine("Enter name Product");
            string delete = Console.ReadLine();
            xml.Remove(delete);
        }
    }
}
