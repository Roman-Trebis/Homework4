using System;
using System.IO;

namespace Homework___4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задание 4. ()* Сохранить дерево каталогов и файлов по заданному пути в текстовый файл — с рекурсией и без.
            Console.WriteLine("Введите путь к катологу, чтобы отобразить его дерево: ");
            string folderPath = Console.ReadLine();

            Console.WriteLine("Введите название файла для сохранения дерева каталогов: ");
            MyDirectory dir = new MyDirectory(folderPath, Console.ReadLine());
            dir.GetDirsRecurs();
            dir.Show();
        }
    }
}
