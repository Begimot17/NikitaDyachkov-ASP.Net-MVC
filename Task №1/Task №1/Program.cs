using System;
using System.Text;
using System.IO;

namespace Task__1
{
    class Url
    {
        public static string ReadUrl = @"C:\Users\Хозяйн\Documents\Институт\Lecture 1\HomeTask\textSample.txt";
        public static string WriteUrl = @"C:\Users\Хозяйн\Documents\Институт\Lecture 1\HomeTask\newText.txt";
    }// StreamReader/Writer Url
    class changeFile
    {
        
        public static void change()
        {
            using (StreamReader fileIn = new StreamReader(Url.ReadUrl, Encoding.GetEncoding(1251)))
            using (StreamWriter fileOut = new StreamWriter(Url.WriteUrl, false))
            {
                string line = fileIn.ReadToEnd();//Text in file
                Console.Write("\nВведите слово которое хотите удалить -> ");
                string wordToDelete = Console.ReadLine();
                string replace = line.Replace(wordToDelete, String.Empty);
                if (line==replace)
                Console.WriteLine("\nУвы такого слова нет\n");
                Console.WriteLine();
                fileOut.WriteLine(replace);
            }
        }

    }//Read txt file
    class numberWords
    {
        public static void number()
        {
            using (StreamReader fileIn = new StreamReader(Url.ReadUrl, Encoding.GetEncoding(1251)))
            using (StreamWriter fileOut = new StreamWriter(Url.WriteUrl, false))
            {
                string text = fileIn.ReadToEnd();
                StringBuilder newline = new StringBuilder();
                string[] split = text.Split(' ', ',');
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

    }//Word count output
    class addArrayString
    {
        public static void addArray()
        {
            using (StreamReader fileIn = new StreamReader(Url.ReadUrl, Encoding.GetEncoding(1251)))
            using (StreamWriter fileOut = new StreamWriter(Url.WriteUrl, false))
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
        }

    }//Reverse words
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
            int numDirectory;
            string quest = Console.ReadLine();
            if (int.TryParse(quest, out numDirectory)&& numDirectory < second.Length)
            {
                    Console.WriteLine();
                    string[] second2 = Directory.GetFiles(second[numDirectory - 1]);
                    Array.Sort(second2);
                    foreach (string x in second2)
                    {
                        Console.WriteLine(x);
                    }
            }
            else Console.WriteLine("Такой директории нет");

        }
    }//Work with directories
    class Program
    {
        static void Main(string[] args)
        {
            int numCase;
            string quest;
            while (true)
            {
                Console.Write("1.Считать тхт файл и удалить в нем указанное слово \n" +
                    "2.Вывести кол-во слов и вывести текст где после каждого 10го слова будет стоять запятая \n" +
                    "3.Перевернуть слова в предложении №3 \n4.Работа с директориями\n5.Выйти\nВыберите номер операции->");
                    quest = Console.ReadLine();
                    if( int.TryParse(quest, out numCase))
                    switch (numCase)
                    {
                        case 1: changeFile.change(); break;
                        case 2: numberWords.number(); break;
                        case 3: addArrayString.addArray(); break;
                        case 4: getDirectory.getDir(); break;
                        case 5: return;
                        default: Console.WriteLine("\nНеверный ввод!!!\n"); ; break;
                    }
                else Console.WriteLine("\nНомер кейса должен быть целочисленным!!!\n");
            }
        }
    }
}
