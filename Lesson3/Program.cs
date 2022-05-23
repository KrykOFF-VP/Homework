using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
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

                    //case 4:
                    //Task4();
                    //break;


                    default:
                        Console.WriteLine("Укажите значение от 0 до 6");
                        break;
                }
            }
            Task1();
            Task2();
            Task3();
            //Task4();



        }
        /// <summary>
        /// Решение первого задания
        /// </summary>
        static void Task1()
        {
            Console.WriteLine("Введите 1 значение размерности массива ");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите 2 значение размерности массива ");
            int y = int.Parse(Console.ReadLine());
            Console.WriteLine("Элементы двумерного массива по диагонали");
            Console.WriteLine("========================================");
            int[,] arr = new int[x, y];
            Random rnd = new Random();


            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rnd.Next(-100, 100);

                    Console.WriteLine(arr[i, j].ToString().PadLeft(x += 1));
                }
            }

            Console.Write("Для выхода нажмите Enter\n");
            Console.ReadKey();

        }

        static void Task2()
        {
            string[,] phonebook = new string[5, 2]
            {
                { "Иванов", "89855854556"},
                { "Петров", "89546548798"},
                { "Сидоров", "8954845654"},
                { "Петрова", "8949565132"},
                { "Филиппова", "589451655"},
                };
            while (true)
            {
                Console.WriteLine("Список абонентов");
                Console.WriteLine("=================================");
                Console.WriteLine("1 -> Иванов");
                Console.WriteLine("2 -> Петров");
                Console.WriteLine("3 -> Сидоров");
                Console.WriteLine("4 -> Петрова");
                Console.WriteLine("5 -> Филиппова");
                Console.WriteLine("0 -> Завершение работы приложения");
                Console.WriteLine("=================================");

                Console.WriteLine("Введите порядковй номер абонента: ");
                int number = int.Parse(Console.ReadLine());

                switch (number)
                {
                    case 0:
                        Console.WriteLine("Завершение рвботы приложения");
                        Console.ReadKey();
                        return;


                    case 1:
                        Console.WriteLine($"{phonebook[0, 0]} -{phonebook[0, 1]}\n");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine($"{phonebook[1, 0]} -{phonebook[1, 1]}\n");
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.WriteLine($"{phonebook[2, 0]} -{phonebook[2, 1]}\n");
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.WriteLine($"{phonebook[3, 0]} -{phonebook[3, 1]}\n");
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.WriteLine($"{phonebook[4, 0]} -{phonebook[4, 1]}\n");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Укажите значение от 0 до 5");
                        break;
                }



            }
        }
        /// <summary>
        /// Решение третьего задания
        /// </summary>
        static void Task3()
        {
             Console.WriteLine("Напишите любое слово.");
             string word = Console.ReadLine();
             Console.WriteLine(word.Reverse().ToArray());
             Console.Write("Для выхода нажмите Enter\n");
             Console.ReadKey();
            
        }

    }
}
