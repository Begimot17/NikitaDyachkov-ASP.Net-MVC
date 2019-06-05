using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Models.Product_children
{
    
    public class Phone:Product
    {

        public string Color { get; set; }
        public int Ram { get; set; }
        public Phone()
        {

        }
        public Phone(string name, string man, string description, string сurrency, int price, string color, int ram) : base(name, man, description, сurrency, price)
        {
            Color = color;
            Ram = ram;
        }

        public override void Show()
        {
            Console.WriteLine("Phone");
            base.Show();
            Console.WriteLine($"{"Color-" + Color,-15}{"RAM-" + Ram,-15}\n");
        }
        public override void Add()
        {
            base.Add();
            Console.WriteLine("Color->>>");
            Color = Console.ReadLine();
            Console.WriteLine("Ram->>>");
            Ram = Int32.Parse(Console.ReadLine());
        }


    }
}
