using System;
using System.Text;
using System.IO;

namespace Task__1
{
    class Program
    {//Создать методы для подзаданий
     //Задание 3 и 4
     //Почистить код от всякого г..на
        static void Main(string[] args)
        {
            using (StreamReader fileIn = new StreamReader(@"C:\Users\Хозяйн\Desktop\Lecture 1\HomeTask\textSample.txt"))
            using (StreamWriter fileOut = new StreamWriter(@"C:\Users\Хозяйн\Desktop\Lecture 1\HomeTask\newText.txt", false))
            {
                string line = fileIn.ReadToEnd();
                StringBuilder newline= new StringBuilder();
                Console.Write("Введите слово которое хотите удалить -> ");
                string delete = Console.ReadLine();
                StringBuilder newline2 = new StringBuilder();
                string[] split = line.Split(' ',',');
                bool test=true;
                int numStr=1;
                int numStr2 = 1;
                foreach(string x in split)
                {
                     if (x.Equals(delete) == false)
                     newline.Append(x + ' '); 
                     else test = false;
                    if(String.IsNullOrWhiteSpace(x))
                    continue;
                    if(numStr2 != 10)
                    newline2.Append(x + ' ');
                   else 
                    {
                        numStr2 = 0;
                        newline2.Append(x + ", ");
                    }

                    numStr++;
                    numStr2++;
                }
                Console.WriteLine($"Кол-во слов{numStr}");
                Console.WriteLine(newline2);
                if (test)
                Console.WriteLine("Увы такого слова нет");
                fileOut.WriteLine(newline);
                Console.ReadKey();
            }
        }
    }
}
