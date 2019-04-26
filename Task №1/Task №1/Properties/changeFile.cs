using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task__1
{
    class changeFile
    {
        public static void change()
    {
        string line = FileManager.ReadFileString();
        Console.Write("\nEnter the word you want to delete. -> ");
        string wordToDelete = Console.ReadLine();
        bool quest = TextManager.ReplaceWords(line, wordToDelete);
        if (!quest)
            Console.WriteLine("\nThere is no such word\n");
    }

}//Read txt file
}
