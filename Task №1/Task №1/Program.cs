using System;
using System.Text;
using System.IO;

namespace Task__1
{
    class FileManager//Write and Read File 
    {
        public static string ReadFileString()
        {
            Console.WriteLine("Пропишите путь к файлу");
            string urlRead = Console.ReadLine();
            using (StreamReader fileIn = new StreamReader(urlRead, Encoding.GetEncoding(1251)))
            {
                string ReadFile = fileIn.ReadToEnd();
                return ReadFile;
            }
        }
        public static void WriteFile(string content)
        {
            Console.WriteLine("Введите путь к файлу в который хотите записать");
            string urlWrite = Console.ReadLine();
            using (StreamWriter fileOut = new StreamWriter(urlWrite,false))
            {
                fileOut.WriteLine(content);
            }
        }
    }
    class TextManager
    {

        public static bool ReplaceWords(string text, string wordForDelete)
        {
            string replace = text.Replace(wordForDelete, String.Empty);
            FileManager.WriteFile(replace);
            if (text == replace)
                return true;
            else return false;
        }
        public static int GetWordsCount(string text,out StringBuilder newtext)
        {
            newtext = new StringBuilder();
            string[] split = text.Split(' ', ',');
            int numStr = 1;
            int numStr2 = 1;
            foreach (string x in split)
            {
                if (String.IsNullOrWhiteSpace(x))
                    continue;
                if (numStr2 != 10)
                    newtext.Append(x + ' ');
                else
                {
                    numStr2 = 0;
                    newtext.Append(x + ", ");
                }
                numStr++;
                numStr2++;
            }
            return numStr;
        }

        public static string GetSentence(string text, int sentenceNumber)
        {
            StringBuilder newline = new StringBuilder();
            string[] split = text.Split('.', '?');
                string[] split2 = split[sentenceNumber - 1].Split(',', ' ', '.', '?');
                foreach (string x in split2)
                {
                    newline.Append(x + " ");
                }
                return Convert.ToString(newline);
        }
        public static string ReverseSentence(string sentence)
        {
            StringBuilder newline = new StringBuilder();

            string[] split2 = sentence.Split(',', ' ', '.', '?');
                foreach (string x in split2)
                {
                    char[] a = x.ToCharArray();
                    Array.Reverse(a);
                    string temp = new string(a);
                    newline.Append(temp + " ");
                }
                return Convert.ToString(newline);
        }
    }
    class changeFile
    {
        public static void change()
        {
                string line = FileManager.ReadFileString();
                Console.Write("\nВведите слово которое хотите удалить -> ");
                string wordToDelete = Console.ReadLine();
            bool quest =TextManager.ReplaceWords(line, wordToDelete);
            if (!quest)
                Console.WriteLine("\nУвы такого слова нет\n");
        }

    }//Read txt file
    class numberWords
    {
        public static void number()
        {
                string text = FileManager.ReadFileString();
                Console.WriteLine($"\nКол-во слов->{TextManager.GetWordsCount(text, out StringBuilder newline)}\n");
                Console.WriteLine(newline + "\n");
        }
    }//Word count output
    class addArrayString
    {
        public static void addArray()
        {
            string text = FileManager.ReadFileString();
            Console.WriteLine("Какое предложение вы хотите перевернуть");
            string temp=Console.ReadLine();
            int sentenceNum;
            Int32.TryParse(temp, out sentenceNum);
            string sentence = TextManager.ReverseSentence(TextManager.GetSentence(text, sentenceNum));
                Console.WriteLine($"\n{sentence}\n");
        }
    }//Reverse words*/
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
                    "3.Перевернуть слова в предложении \n4.Работа с директориями\n5.Выйти\nВыберите номер операции->");
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
