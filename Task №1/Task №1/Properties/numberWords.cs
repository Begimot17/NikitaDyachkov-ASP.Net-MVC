using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task__1
{
    class numberWords
    {
        public static void number()
        {
            string text = FileManager.ReadFileString();
            Console.WriteLine($"\nNumber of words->{TextManager.GetWordsCount(text, out StringBuilder newline)}\n");
            Console.WriteLine(newline + "\n");
        }
    }//Word count output
}
