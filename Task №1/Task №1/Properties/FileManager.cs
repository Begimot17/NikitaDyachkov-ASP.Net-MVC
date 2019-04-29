using System;
using System.Text;
using System.IO;
namespace Task__1
{
    class FileManager//Write and Read File 
    {
        public static string ReadFileString()
        {
            Console.WriteLine("Write the file path");
            string urlRead = Console.ReadLine();
            using (StreamReader fileIn = new StreamReader(urlRead, Encoding.GetEncoding(1251)))
            {
                string ReadFile = fileIn.ReadToEnd();
                return ReadFile;
            }
        }
        public static void WriteFile(string content)
        {
            Console.WriteLine("Enter the path to the file you want to write.");
            string urlWrite = Console.ReadLine();
            using (StreamWriter fileOut = new StreamWriter(urlWrite, false))
            {
                fileOut.WriteLine(content);
            }
        }
    }
}
