using System;
using System.IO;

namespace _02_Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader("Input.txt");
           
            using (var writer = new StreamWriter("Output.txt", true))
            {
                int counter = 1;
                string input;
                while ((input = reader.ReadLine()) != null)
                {
                    var result = $"{counter}. {input}";
                    writer.WriteLine(result);
                    Console.WriteLine(result);
                    counter++;
                }
            }
        }
    }
}
