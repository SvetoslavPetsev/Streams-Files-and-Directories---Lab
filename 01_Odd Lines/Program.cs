using System;
using System.IO;

namespace _01_Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader("Input.txt");
            using (reader)
            {
                int counter = 0;
                using (var writer = new StreamWriter("Output.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (counter % 2 == 1)
                        {
                            Console.WriteLine(line);
                            writer.WriteLine(line);
                        }
                        counter++;
                    }
                }
            }
        }
    }
}
