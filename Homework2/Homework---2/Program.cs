using System;
using System.IO;

namespace Homework___2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задание 2. Написать программу, которая при старте дописывает текущее время в файл «startup.txt».
            AppendTime();
        }

        static void AppendTime()
        {
            using var sw = File.AppendText("startup.txt");
            var time = DateTime.Now.ToString("HH:mm:ss");
            sw.WriteLine(time);

            Console.Write($"Добавляю в startup.txt новое время, время: {time}, иди проверяй.");
        }
    }
}
