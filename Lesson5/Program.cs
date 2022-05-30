using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace Lesson5
{
    internal class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Мои задачи");
                Console.WriteLine("=================================");
                Console.WriteLine("1 -> Задание 1");
                Console.WriteLine("2 -> Задание 2");
                Console.WriteLine("3 -> Задание 3");
                Console.WriteLine("4 -> Задание 4");
                Console.WriteLine("0 -> Завершение работы приложения");
                Console.WriteLine("=================================");

                Console.WriteLine("Введите номер задачи: ");
                int number = int.Parse(Console.ReadLine());

                switch (number)                                                                                                 //Создание меню программы
                {
                    case 0:
                        Console.WriteLine("Завершение работы приложения");
                        Console.ReadKey();
                        return;

                    case 1:
                        Task1();
                        break;

                    case 2:
                        Task2();
                        break;

                    case 3:
                        Task3();
                        break;


                    default:
                        Console.WriteLine("Укажите значение от 0 до 3");
                        break;
                }
            }
        }

        /// <summary>
        /// Решение первого задания
        /// </summary>
        static void Task1()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("Введите название файла");
            string filename = (Console.ReadLine()+ ".txt");
            Console.WriteLine("Введите любые значения для записи в файл");
            string str = (Console.ReadLine());            
            File.WriteAllText(filename, str);                                                 // записываем в файл строку
            string fileText = File.ReadAllText(filename);
            Console.WriteLine($"Вы записали в файл значение: {fileText}");
            Console.Write("Для выхода нажмите Enter\n");
            Console.ReadKey();
        }


        /// <summary>
        /// Решение второго задания
        /// </summary>
        static void Task2()
        {
            Console.WriteLine("================================================");
            string filename = "startup.txt";            
            Console.WriteLine("Нажмите любую клавишу для запуска записи времени в файл\n");
            Console.ReadKey();
            DateTime mydata = DateTime.Now; ;
            File.WriteAllText(filename,  mydata.ToString("HH: mm:ss"));                                                 // записываем в файл строку
            string fileText = File.ReadAllText(filename);
            Console.WriteLine($"Вы записали в файл значение: {fileText}");
            Console.Write("Для выхода нажмите Enter\n");
            Console.ReadKey();
        }

        /// <summary>
        /// Решение третьего задания
        /// </summary>
        static void Task3()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("Введите название файла");
            string filename = (Console.ReadLine() + ".bin");
            Console.WriteLine("Введите с клавиатуры произвольный набор чисел (0...255) через пробел");
            string numbs = Console.ReadLine();
            string[] split=numbs.Split(' ');
            
            for (int i = 0; i < split.Length; i++)
            {
                byte x = Convert.ToByte(split[i]);
                
                
               File.WriteAllBytes(filename, x);                                                 // записываем в файл строку
               
            }
            Console.Write("Для выхода нажмите Enter\n");
            Console.ReadKey();

        }
        


    }
}

