using System;
using System.Text;
using System.IO;

namespace Task__1
{
    class Program
    {
        static string url = @"C:\Users\Хозяйн\Desktop\Lecture 1\HomeTask\textSample.txt"; // Чтение 
        static string url_2 = @"C:\Users\Хозяйн\Desktop\Lecture 1\HomeTask\newText.txt";// Запись
        static void changeFile()
        {
            using (StreamReader fileIn = new StreamReader(url,Encoding.GetEncoding(1251)))
            using (StreamWriter fileOut = new StreamWriter(url_2, false))
            {
                string line = fileIn.ReadToEnd();
                StringBuilder newline = new StringBuilder();
                Console.Write("Введите слово которое хотите удалить -> ");
                string delete = Console.ReadLine();
                string[] split = line.Split(' ', ',','.','?');
                bool test = true;
                foreach (string x in split)
                {
                    if (String.IsNullOrWhiteSpace(x))
                        continue;
                    else if (x.Equals(delete) == false)
                        newline.Append(x + ' ');
                    else test = false;


                }
                if (test)
                    Console.WriteLine("Увы такого слова нет\n\n");
                fileOut.WriteLine(newline);
            }
        }
        static void numberWords()
        {
            using (StreamReader fileIn = new StreamReader(url, Encoding.GetEncoding(1251)))
            using (StreamWriter fileOut = new StreamWriter(url_2, false))
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
                Console.WriteLine($"Кол-во слов->{numStr}");
                Console.WriteLine(newline+"\n");
            }
        }
        static void addArrayString()
        {
            using (StreamReader fileIn = new StreamReader(url, Encoding.GetEncoding(1251)))
            using (StreamWriter fileOut = new StreamWriter(url_2, false))
            {
                string line = fileIn.ReadToEnd();
                StringBuilder newline = new StringBuilder();
                string[] split = line.Split('.', '?');
                string [] split2=split[2].Split(',',' ', '.', '?');
                foreach(string x in split2)
                    {
                        char[] a = x.ToCharArray();
                        Array.Reverse(a);
                        string temp = new string(a);
                        newline.Append(temp+" ");
                    }
                StringBuilder text = new StringBuilder();
                for (int i = 0; i < split.Length; i++)
                    {
                        if (split[2]==split[i])
                            text.Append(Convert.ToString(newline));
                        else
                            text.Append(split[i]);
                    }
                Console.WriteLine(newline);
            }
        }
        static void getDirectory()
        {
            string directory = @"C:\Users\Хозяйн";
            string[] second = Directory.GetDirectories(directory);
            Array.Sort(second);
            for (int i = 0; i < second.Length; i++)
            {
                Console.WriteLine((i+1)+"/////////"+second[i]);
            }
            Console.Write("Введите идентификатор директории->");
            try
            {
                int quest = Convert.ToInt16(Console.ReadLine());
                string[] second2 = Directory.GetFiles(second[quest - 1]);

                Array.Sort(second2);
                foreach (string x in second2)
                {
                    Console.WriteLine(x);
                }
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IndexOutOfRangeException ex )
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void Main(string[] args)
        {
            int quest;
            for (;true;)
            {
                Console.WriteLine("Выберите номер операции \n1.Считать тхт файл и удалить в нем указанное слово \n" +
                    "2.Вывести кол-во слов и вывести текст где после каждого 10го слова будет стоять запятая \n" +
                    "3.Перевернуть слова в предложении №3 \n4.Работа с директориями\n5.Выйти");
                quest = Convert.ToInt16(Console.ReadLine());
                switch (quest)
                {
                    case 1: changeFile(); break;
                    case 2: numberWords(); break;
                    case 3: addArrayString(); break;
                    case 4: getDirectory(); break;
                    case 5: return;
                    default: Console.WriteLine("Неверный ввод"); break;
                }
            }
        }
    }
}
