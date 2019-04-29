using System;
using System.Text;
namespace Task__1
{
    class TextManager
    {
        public static bool ReplaceWords(string text, string wordForDelete)
        {
            string replace = text.Replace(wordForDelete, String.Empty);
            FileManager.WriteFile(replace);
            return text == replace;
        }
        public static int GetWordsCount(string text, out StringBuilder newtext)
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
}
