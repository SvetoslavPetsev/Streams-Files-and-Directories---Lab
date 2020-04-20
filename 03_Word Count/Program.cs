using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _03_Word_Count
{
    class Program
    {
        static void Main()
        {
            var wordList= new Dictionary<string, int>();
            using var readerWord = new StreamReader("words.txt");
            {
                string[] line = readerWord.ReadLine().Split();
                foreach (var word in line)
                {
                    wordList.Add(word, 0);
                }
            }
            var fullString = new StringBuilder();
            using var readerText = new StreamReader("text.txt");
            {
                string line;
                while ((line = readerText.ReadLine())!= null)
                {
                    fullString.Append(line);
                }
            }
            string[] fullSplitedTex = fullString.ToString()
                .ToLower()
                .Split(new char[] {' ', ',', '?','!','-','.'},StringSplitOptions.RemoveEmptyEntries);

            var tempList = new Dictionary<string, int>(wordList);

            foreach (var wordInFullText in fullSplitedTex)
            {
                foreach (var (key, value) in tempList)
                {
                    if (wordInFullText == key)
                    {
                        wordList[wordInFullText]++;
                    }
                }
            }
            using var writer = new StreamWriter("Output.txt");
            {
                foreach (var word in wordList.OrderByDescending(x=>x.Value))
                {
                    var result = $"{word.Key} - {word.Value}";
                    writer.WriteLine(result);
                }          
            }
        }
    }
}
