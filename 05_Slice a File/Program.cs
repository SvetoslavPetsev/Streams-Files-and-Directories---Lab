using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace _05_Slice_a_File
{
    class Program
    {
        static void Main()
        {
            var stream = new FileStream("sliceMe.txt", FileMode.OpenOrCreate);
            var parts = 4;
            var length = (int)Math.Ceiling((decimal)stream.Length / parts); // вземеме 1/4 от дължината на входния текст - по условие, като го закръгляме нагоре // добра практика е дължината да е кратна на 4, защото мин. байта за ч символ = 4байта!!!

            var buffer = new byte[length]; //създаваме буфер с дължина

            for (int i = 0; i < parts; i++)
            {
                var bytesRead = stream.Read(buffer, 0, buffer.Length); //взема колко байта са прочетени от буфера/

                if (bytesRead < buffer.Length) // проверка за дължината на буфера в последната част 
                {
                    buffer = buffer.Take(bytesRead).ToArray(); //вземи толкова колкото могат да са прочетат ... до края
                }

                using var currPartStream = new FileStream($"Part-{i+1}.txt", FileMode.OpenOrCreate);

                currPartStream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
