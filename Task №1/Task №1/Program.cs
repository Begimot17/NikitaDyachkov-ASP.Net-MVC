using System;
using System.Text;
using System.IO;

namespace Task__1
{
    class changeFile
    {
        public static void change()
        {
             string ReadUrl = @"C:\Users\Хозяйн\Desktop\Lecture 1\HomeTask\textSample.txt"; // Чтение 
             string WriteUrl = @"C:\Users\Хозяйн\Desktop\Lecture 1\HomeTask\newText.txt";// Запись
            using (StreamReader fileIn = new StreamReader(ReadUrl, Encoding.GetEncoding(1251)))
            using (StreamWriter fileOut = new StreamWriter(WriteUrl, false))
            {
                string line = fileIn.ReadToEnd();//Текст в файле
                StringBuilder newline = new StringBuilder();
                Console.Write("\nВведите слово которое хотите удалить -> ");
                string delete = Console.ReadLine();
                string[] split = line.Split(' ', ',', '.', '?');
                bool test = true;//Переменная проверки наличия указанного слова
                foreach (string x in split)
                {
                    if (String.IsNullOrWhiteSpace(x))
                        continue;
                    else if (x.Equals(delete) == false)
                        newline.Append(x + ' ');
                    else test = false;
                }
                if (test)
                    Console.WriteLine("\nУвы такого слова нет\n");
                Console.WriteLine();
                fileOut.WriteLine(newline);
            }
        }

    }//Метод считывания txt файла 
    class numberWords
    {
        public static void number()
        {
             string ReadUrl = @"C:\Users\Хозяйн\Desktop\Lecture 1\HomeTask\textSample.txt"; // Чтение 
             string WriteUrl = @"C:\Users\Хозяйн\Desktop\Lecture 1\HomeTask\newText.txt";// Запись
            using (StreamReader fileIn = new StreamReader(ReadUrl, Encoding.GetEncoding(1251)))
            using (StreamWriter fileOut = new StreamWriter(WriteUrl, false))
            {
                string line = fileIn.ReadToEnd();
                StringBuilder newline = new StringBuilder();
                string[] split = line.Split(' ', ',');
                int numStr = 1;
                int numStr2 = 1;
                foreach (string x in split)
                {
                    if (String.IsNullOrWhiteSpace(x))
                        continue;
                    if (numStr2 != 10)
                        newline.Append(x + ' ');
                    else
                    {
                        numStr2 = 0;
                        newline.Append(x + ", ");
                    }
                    numStr++;
                    numStr2++;
                }
                Console.WriteLine($"\nКол-во слов->{numStr}\n");
                Console.WriteLine(newline + "\n");
            }
        }

    }//Метод вывода колличества слов в тексте
    class addArrayString
    {
        public static void addArray()
        {
             string ReadUrl = @"C:\Users\Хозяйн\Desktop\Lecture 1\HomeTask\textSample.txt"; // Чтение 
             string WriteUrl = @"C:\Users\Хозяйн\Desktop\Lecture 1\HomeTask\newText.txt";// Запись
            using (StreamReader fileIn = new StreamReader(ReadUrl, Encoding.GetEncoding(1251)))
            using (StreamWriter fileOut = new StreamWriter(WriteUrl, false))
            {
                string line = fileIn.ReadToEnd();
                StringBuilder newline = new StringBuilder();
                string[] split = line.Split('.', '?');
                string[] split2 = split[2].Split(',', ' ', '.', '?');
                foreach (string x in split2)
                {
                    char[] a = x.ToCharArray();
                    Array.Reverse(a);
                    string temp = new string(a);
                    newline.Append(temp + " ");
                }
                StringBuilder text = new StringBuilder();
                for (int i = 0; i < split.Length; i++)
                {
                    if (split[2] == split[i])
                        text.Append(Convert.ToString(newline));
                    else
                        text.Append(split[i]);
                }
                Console.WriteLine($"\n{newline}\n");
            }
        }//Метод вывода слов наоборот

    }//Метод вывода слов наоборот
    class getDirectory
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
            Console.Write("\nВведите идентификатор директории->");

            int quest = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine();
                string[] second2 = Directory.GetFiles(second[quest - 1]);
                Array.Sort(second2);
                foreach (string x in second2)
                {
                    Console.WriteLine(x);
                }
            
        }
    }//Метод работы с директориями

    class Program
    {
       
        static void Main(string[] args)
        {
            int quest;
            while (true)
            {
                Console.Write("1.Считать тхт файл и удалить в нем указанное слово \n" +
                    "2.Вывести кол-во слов и вывести текст где после каждого 10го слова будет стоять запятая \n" +
                    "3.Перевернуть слова в предложении №3 \n4.Работа с директориями\n5.Выйти\nВыберите номер операции->");
                try
                {

                    quest = Convert.ToInt16(Console.ReadLine());//Переменная выбора операции 
                    switch (quest)
                    {
                        case 1: changeFile.change(); break;
                        case 2: numberWords.number(); break;
                        case 3: addArrayString.addArray(); break;
                        case 4: getDirectory.getDir(); break;
                        case 5: return;
                        default: Console.WriteLine("\nНеверный ввод!!!\n"); ; break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n{ex.Message}\n");
                }
            }
        }
    }
}
