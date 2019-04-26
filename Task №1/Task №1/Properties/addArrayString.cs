using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task__1
{
    class addArrayString
    {
        public static void addArray()
        {
            string text = FileManager.ReadFileString();
            Console.WriteLine("What sentence do you want to flip");
            string temp = Console.ReadLine();
            int sentenceNum;
            Int32.TryParse(temp, out sentenceNum);
            string sentence = TextManager.ReverseSentence(TextManager.GetSentence(text, sentenceNum));
            Console.WriteLine($"\n{sentence}\n");
        }
    }//Reverse words*/
}
