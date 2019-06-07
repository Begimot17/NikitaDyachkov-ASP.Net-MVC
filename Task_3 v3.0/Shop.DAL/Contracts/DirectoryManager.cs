using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Contracts
{
    public class DirectoryManager
    {
        public static int Ind { get; set; }
        public static string DirManager(string box)
        {
            Ind = 0;
            string[] dirs = Directory.GetDirectories(box);
            if (Directory.Exists(box))
            {
                Console.WriteLine("Directory:");
                foreach (string s in dirs)
                {
                    Console.WriteLine(Ind + "->" + @s);
                    Ind++;
                }
                Ind = 0;
                Console.WriteLine();
                Console.WriteLine("File:");
                string[] files = Directory.GetFiles(box);
                foreach (string s in files)
                {
                    Console.WriteLine(@s);
                }
            }
                Console.WriteLine("Enter Id Directory->");
                var Id = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Отслеживается папка->"+dirs[Id]);

                return @dirs[Id] ;

        }
        public void Go(string box)
        {
            FileWatcher fileWatcher = new FileWatcher();
            fileWatcher.Run(DirManager(box));
        }
    }
}
