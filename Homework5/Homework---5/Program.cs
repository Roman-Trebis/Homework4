using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

namespace Homework___5
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Задание 5. ()* Список задач (ToDo-list):
            написать приложение для ввода списка задач;
            задачу описать классом ToDo с полями Title и IsDone;
            на старте, если есть файл tasks.json/xml/bin (выбрать формат), загрузить из него массив имеющихся задач и вывести их на экран;
            если задача выполнена, вывести перед её названием строку «[x]»;
            вывести порядковый номер для каждой задачи;
            при вводе пользователем порядкового номера задачи отметить задачу с этим порядковым номером как выполненную;
            записать актуальный массив задач в файл tasks.json/xml/bin.
            */

            string format = (args.Length > 0) ? args[0] : "json";
            string fileName = $"todo.{format}";

            List<ToDo> todoList = ReadFile(format, fileName);
            ShowList(todoList);

            while(true)
            {
                Console.Write($"'i' - редактировать задачу\n" +
                    "'n' - добавить новую задачу\n" +
                    "'q' - выход: ");
                string choise = Console.ReadLine();
                Console.WriteLine();
                switch (choise)
                {
                    case "i":
                        Edit(ref todoList);
                        break;

                    case "n":
                        Add(ref todoList);
                        break;

                    case "q":
                        Save(format, fileName, todoList);
                        return;

                    default:
                        Console.WriteLine("Ошибка");
                        break;
                }
                ShowList(todoList);
            }
        }

        static void ShowList(List<ToDo> todoList)
        {
            for(int i = 0; i < todoList.Count; i++)
            {
                string isTaskDone = todoList[i].IsDone ? "[X]" : "";
                Console.WriteLine($"{i} {isTaskDone,3} {todoList[i].Title}");
            }
            Console.WriteLine();
        }

        static void Edit(ref List<ToDo> todoList)
        {
            if(todoList.Count == 0)
            {
                Console.WriteLine("Список задач пуст.");
                return;
            }
            Console.Write("Введите порядковый номер задачи: ");
            if(int.TryParse(Console.ReadLine(), out int number))
            {
                if (number < todoList.Count)
                {
                    todoList[number].IsDone = true;
                }

                else
                {
                    Console.WriteLine($"Указан неверный номер задачи. Введите номер от 0 до {todoList.Count - 1}");
                    Edit(ref todoList);
                }
            }
        }

        static void Add(ref List<ToDo> todoList)
        {
            Console.Write("Введите текст задачи: ");
            string task = Console.ReadLine();
            todoList.Add(new ToDo(task));
        }

        static List<ToDo> ReadFile(string format, string fileName)
        {
            List<ToDo> todoList;

            switch (format)
            {
                case "xml":
                    todoList = ReadXml(fileName);
                    break;

                case "json":
                default:
                    todoList = ReadJson(fileName);
                    break;
            }
            return todoList;
        }

        static void Save(string format, string fileName, List<ToDo> todoList)
        {
            switch (format)
            {
                case "xml":
                    SaveXml(todoList, fileName);
                    break;

                case "json":
                default:
                    SaveJson(todoList, fileName);
                    break;
            }
        }

        static List<ToDo> ReadXml(string fileName)
        {
            List<ToDo> todoList = new List<ToDo>();
            if(File.Exists(fileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<ToDo>));
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    todoList = (List<ToDo>)serializer.Deserialize(fs);
                }
            }
            return todoList;
        }

        static List<ToDo> ReadJson(string fileName)
        {
            List<ToDo> todoList = new List<ToDo>();
            if(File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                todoList = JsonSerializer.Deserialize<List<ToDo>>(jsonString);
            }
            return todoList;
        }

        static void SaveJson(List<ToDo> todoList, string fileName)
        {
            string json = JsonSerializer.Serialize(todoList);
            File.WriteAllText("task.json", json);
        }

        static void SaveXml(List<ToDo> todoList, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ToDo));
            string xml = todoList.ToString();
            File.WriteAllText("Task.xml", xml);
        }
    }
}
