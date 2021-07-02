using System;
using System.IO;

namespace Homework___1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задание 1. Ввести с клавиатуры произвольный набор данных и сохранить его в текстовый файл.
            ReadDataAndSaveFile();
        }

        static void ReadDataAndSaveFile()
        {
            Console.WriteLine("Путь к входному файлу для сохранения данных");
            var path = Console.ReadLine();
            
            if(string.IsNullOrEmpty(path) || string.IsNullOrWhiteSpace(path))
            {
                Console.WriteLine("Неверный путь");
                return;
            }

            if (!path.EndsWith(".txt")) path += ".txt";
            var fs = new FileStream(path, File.Exists(path) ? FileMode.Append : FileMode.OpenOrCreate);
            var sw = new StreamWriter(fs);


            Console.WriteLine("Введите данные для сохранения в текстовом файле, нажмите esc, чтобы остановить");
            sw.AutoFlush = true;
            while(true)
            {
                var InputKey = Console.ReadKey();

                if (InputKey.Key == ConsoleKey.Escape)
                    break;

                if (InputKey.Key == ConsoleKey.Enter)
                {
                    sw.Write("\n");
                    Console.WriteLine();
                }

                else
                {
                    sw.Write(InputKey.KeyChar);
                }

                //Остановка программы
                Console.WriteLine("\nРабота сделана.");
            }
        }
    }
}
