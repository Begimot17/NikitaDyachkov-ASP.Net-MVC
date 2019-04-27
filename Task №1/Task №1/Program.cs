using System;
using System.Text;
using System.IO;

namespace Task__1
{
    class Program
    {
        static void Main(string[] args)
        {
            Action action = new Action();
            while (true)
            {
                Console.Write("1. Read txt file and delete the specified word in it \n" +
                            "2. Enter the number of words and output the text where after each 10th word there will be a comma \n" +
                         "3.Turn the words in the sentence \n4. Work with directories \n5.Exit \n nSelect the operation number->");
                string quest = Console.ReadLine();
                    if( int.TryParse(quest, out int numCase))
                    switch (numCase)
                    {
                        case 1: action.Change(); break;
                        case 2: action.Number(); break;
                        case 3: action.AddArray(); break;
                        case 4: action.GetDir(); break;
                        case 5: return;
                        default: Console.WriteLine("\nInvalid input!!!\n"); ; break;
                    }
                else Console.WriteLine("\nCase number must be an integer!!!\n");
            }
        }
    }
}
