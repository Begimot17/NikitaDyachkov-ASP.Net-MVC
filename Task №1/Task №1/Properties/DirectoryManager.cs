using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task__1
{
    class DirectoryManager
    {
        public static void getDir()
        {
            string directory = @"C:\Users\Хозяйн";
            string[] second = Directory.GetDirectories(directory);
            Array.Sort(second);
            for (int i = 0; i < second.Length; i++)
            {
                Console.WriteLine((i + 1) + "/////////" + second[i]);
            }
            Console.Write("\nEnter directory ID->");
            int numDirectory;
            string quest = Console.ReadLine();
            if (int.TryParse(quest, out numDirectory) && numDirectory < second.Length)
            {
                Console.WriteLine();
                string[] second2 = Directory.GetFiles(second[numDirectory - 1]);
                Array.Sort(second2);
                foreach (string x in second2)
                {
                    Console.WriteLine(x);
                }
            }
            else Console.WriteLine("There is no such directory.");

        }
    }//Work with directories
}
