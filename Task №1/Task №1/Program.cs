using System;
using System.Text;
using System.IO;

namespace Task__1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader fileIn = new StreamReader(@"C:\Users\Хозяйн\Desktop\Lecture 1\HomeTask\textSample.txt"))
            using (StreamWriter fileOut = new StreamWriter(@"C:\Users\Хозяйн\Desktop\Lecture 1\HomeTask\newText.txt", false))
            {
                string line = fileIn.ReadToEnd();
                StringBuilder newline= new StringBuilder();
                Console.Write("Введите слово которое хотите удалить -> ");
                string delete = Console.ReadLine();
                string[] split = line.Split(' ',',','.');
                bool test=true;
                foreach(string x in split)
                {
                    if (x.Equals(delete) == false)
                    newline.Append(x + ' '); 
                    else test = false;
                }
                if (test)
                Console.WriteLine("Увы такого слова нет");
                fileOut.WriteLine(newline);
                Console.WriteLine(newline);
                Console.ReadKey();
            }
        }
    }
}
