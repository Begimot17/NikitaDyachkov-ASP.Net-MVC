using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Models.Product_children
{
    public class Car:Product
    {
        public int NumbOfWhel { get; set; }
        public int Horsepower { get; set; }
        public Car()
        {

        }
        public Car(string name, string man, string description, string сurrency, int price, int num, int horse) : base(name, man, description, сurrency, price)
        {
            NumbOfWhel = num;
            Horsepower = horse;
        }
        public override void Show()
        {
            Console.WriteLine("Car");
            base.Show();
            Console.WriteLine($"{"NumbOfWhel-" + NumbOfWhel,-15}{"Horsepower-" + Horsepower,-15}\n");
        }
        public override void Add()
        {
            base.Add();
            Console.WriteLine("NumbOfWhel->>>");
            NumbOfWhel = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Horsepower->>>");
            Horsepower = Int32.Parse(Console.ReadLine());
        }
    }
}
