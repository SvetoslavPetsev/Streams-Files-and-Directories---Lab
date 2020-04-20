using System;
using System.IO;

namespace _06_Folder_Size
{
    class Program
    {
        static void Main()
        {
            var files = Directory.GetFiles("TestFolder");
            var totalLenght = 0m;
            foreach (var file in files)
            {
                var fileSize = new FileInfo(file);
                totalLenght += fileSize.Length;
            }
            Console.WriteLine($"{totalLenght / 1024 / 1024:F4} MB");
        }
    }
}
