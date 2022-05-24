using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
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
         

        }
        /// <summary>
        /// Решение второго задания
        /// </summary>
        static void Task2()
        {
       
                



            
        }
        /// <summary>
        /// Решение третьего задания
        /// </summary>
        static void Task3()
        {
      
        }

    }
}
        
    

