using System;

namespace Task_4___Test_edition
{
    class Program
    {
        static void Main(string[] args)
        {
            XMLRepa xml = new XMLRepa();
            while (true)
            {
                Console.WriteLine("1=AddProduct\n2=ShowProduct\n3=DeleteProduct");
                int quest = 0;
                Int32.TryParse(Console.ReadLine(),out quest);
                switch (quest)
                {
                    case 1: ConsoleManager.Add(); break;
                    case 2: xml.GetProducts(); break;
                    case 3: ConsoleManager.Remove();break;
                    default:; break;
                }
            }
        }
    }
}
