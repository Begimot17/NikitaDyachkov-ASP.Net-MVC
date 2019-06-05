using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Models.Product_children
{
    public class Sneakers :Product
    {
        public int Size { get; set; }
        public char Sex { get; set; }
        public Sneakers()
        {

        }
        public Sneakers(string name, string man, string description, string сurrency, int price, int size, char sex) : base(name, man, description, сurrency, price)
        {
            Size = size;
            Sex = sex;
        }
        public override void Show()
        {
            Console.WriteLine("Sneakers");

            base.Show();

            Console.WriteLine($"{"Size-" + Size,-15}{"Sex-" + Sex,-15}\n");
        }
        public override void Add()
        {
            base.Add();
            Console.WriteLine("Size->>>");
            Size = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Sex->>>");
            Sex = Char.Parse(Console.ReadLine());
        }
    }
}
