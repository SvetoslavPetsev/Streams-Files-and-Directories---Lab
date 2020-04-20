using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _04_Merge_Files
{
    class Program
    {
        static void Main()
        {
            var fileOne = File.ReadLines("FileOne.txt");
            var fileTwo = File.ReadLines("FileTwo.txt");

            var FirstQueue = new Queue<string>(fileOne);
            var SecondQueue = new Queue<string>(fileTwo);
            List<string> mergeList = new List<string>();
            while (FirstQueue.Any() && SecondQueue.Any())
            {
                if (FirstQueue.Any())
                {
                    mergeList.Add(FirstQueue.Dequeue());
                }

                if (SecondQueue.Any())
                {
                    mergeList.Add(SecondQueue.Dequeue());
                }

            }
            var merge = mergeList.ToArray();
            File.WriteAllLines("Output.txt", merge);
        }
    }
}
