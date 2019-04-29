using System;
using System.IO;
using System.Text;
namespace Task__1
{
    class Action
    {
        public Action() { }
        public void GetDir()
        {
            string directory = @"C:\Users\Хозяйн";
            string[] second = Directory.GetDirectories(directory);
            Array.Sort(second);
            for (int i = 0; i < second.Length; i++)
            {
                Console.WriteLine((i + 1) + "/////////" + second[i]);
            }
            Console.Write("\nEnter directory ID->");
            string quest = Console.ReadLine();
            if (int.TryParse(quest, out int numDirectory) && numDirectory < second.Length)
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
        public void AddArray()
        {
            string text = FileManager.ReadFileString();
            Console.WriteLine("What sentence do you want to flip");
            string temp = Console.ReadLine();
            Int32.TryParse(temp, out int sentenceNum);
            string sentence = TextManager.ReverseSentence(TextManager.GetSentence(text, sentenceNum));
            Console.WriteLine($"\n{sentence}\n");
        }
        public void Number()
        {
            string text = FileManager.ReadFileString();
            Console.WriteLine($"\nNumber of words->{TextManager.GetWordsCount(text, out StringBuilder newline)}\n");
            Console.WriteLine(newline + "\n");
        }
        public void Change()
        {
            string line = FileManager.ReadFileString();
            Console.Write("\nEnter the word you want to delete. -> ");
            string wordToDelete = Console.ReadLine();
            bool quest = TextManager.ReplaceWords(line, wordToDelete);
            if (!quest)
                Console.WriteLine("\nThere is no such word\n");
        }
    }
}
