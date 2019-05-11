using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task__2.Properties
{
    public class ConsoleOutput
    {
        public static  void ShowProduct(Product x)
        {
            Console.WriteLine($"{"Name",-25}  {"Description",-11}  {"Type",-10}  {"Price",-5}");
            Console.WriteLine($"{x.Name,-25}  {x.Description,-11}  {x.Type,-10}  {x.Price,-5}");
        }

    }
}
