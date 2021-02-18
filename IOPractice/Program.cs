using System;
using System.Collections.Generic;
using System.IO;

namespace IOPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            //-----------------1------------------
            Console.WriteLine("Введите путь к текстовому фалу:");
            var pathToRead = Console.ReadLine();

            var symbols = new Dictionary<char, int>();

            for (int i = 0; i < 256; i++)
            {
                symbols.Add((char)i, 0);
            }

            try
            {
                using (var stream = File.OpenRead(pathToRead))
                {
                    var data = new byte[stream.Length];
                    stream.Read(data, 0, data.Length);

                    foreach (var symbol in data)
                    {
                        symbols[(char)symbol]++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            foreach (var symbol in symbols)
            {
                Console.WriteLine($"{symbol.Key} - {symbol.Value}");
            }

            //-----------------2------------------
            Console.Write("Введите имя: ");
            var name = Console.ReadLine();

            Console.Write("Введите фамилию: ");
            var surname = Console.ReadLine();

            Console.Write("Введите возраст: ");
            if (int.TryParse(Console.ReadLine(), out int age))
            {
                age = 18;
            }

            Console.WriteLine("Введите путь к текстовому файлу: ");
            var pathToWrite = Console.ReadLine();

            try
            {
                using (var stream = new StreamWriter(File.OpenWrite(pathToWrite)))
                {
                    stream.WriteLine(name);
                    stream.WriteLine(surname);
                    stream.WriteLine(age);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

        }
    }
}
