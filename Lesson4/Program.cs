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



        }
        /// <summary>
        /// Решение первого задания
        /// </summary>
        static void Task1()
        {
            Console.WriteLine("Введите колличество строк в списке фамилий");
            int number = int.Parse(Console.ReadLine());
            string firstName = "";                                                                          ///объявление необходимых переменных и массива
            string lastName = "";
            string patronymic = "";
            string[] str = new string[number];                                                             ///объявлем массив с циклом длинны number
            for (int i = 0; i < str.Length; i++)
            {
                Console.WriteLine("=================================");
                Console.WriteLine("Введите Фамилию");
                firstName = (Console.ReadLine());
                Console.WriteLine("Введите Имя");
                lastName = (Console.ReadLine());
                Console.WriteLine("Введите Отчество");
                patronymic = (Console.ReadLine());
                str[i] = GetFullName(firstName, lastName, patronymic);
                Console.WriteLine("=================================");
                Console.WriteLine($"{i + 1} {str[i]}");                                                    //Вывод строки с порядковым номером

            }

            Console.Write("Для выхода нажмите Enter\n");
            Console.ReadKey();

        }
        /// <summary>
        /// Метод для склейки переменных в нужном порядке
        /// </summary>

        static string GetFullName(string firstName, string lastName, string patronymic)
        {
            string fullName = firstName + " " + lastName + " " + patronymic + " ";

            return fullName;
        }
        /// <summary>
        /// Решение второго задания
        /// </summary>
        static void Task2()
        {

            Console.WriteLine("Введите любые числа через пробел");
            string numbs = (Console.ReadLine());
            CalckString(numbs);
            Console.Write("Для выхода нажмите Enter\n");
            Console.ReadKey();
        }

        static string[] separators = { " " };

        static void CalckString(string numbs)
        {
            string[] mass = numbs.Split(separators, StringSplitOptions.RemoveEmptyEntries);         //Убираем пробелы
            int result = 0;
            int[] conv = { };
            for (int i = 0; i < mass.Length; i++)
            {
                result += Convert.ToInt32(mass[i]);                                                   //конвертируем массив в числовое значение и складываем получившийся результат

            }
            Console.WriteLine($"Cумма чисел равна {result}");
        }


        /// <summary>
        /// Решение третьего задания
        /// </summary>

        enum Seasons 
        {

            Winter =1,            
            Spring ,
            Summer ,
            Autumn 
        
        }

       
       
        static void Task3()
        {

         Askforseasons(Nowseason());        
            object Askforseasons(object e)
            {
                if (e is (Seasons)1)
                {
                    string a = "Зима";
                    Console.WriteLine($"Время года: {a}");
                }
                else if (e is (Seasons)2)
                {
                    string a = "Весна";
                    Console.WriteLine($"Время года {a}");
                }
                else if (e is (Seasons)3)
                {
                    string a = "Лето";
                    Console.WriteLine($"Время года {a}");
                }

                else if (e is (Seasons)4)
                {
                    string a = "Осень";
                    Console.WriteLine($"Время года {a}");
                }
                return 0;
            }
            object Nowseason()
            {
                Console.Write("Укажите порядковый номер месяца: ");
                int monthNo = int.Parse(Console.ReadLine());

                if (monthNo <= 0 || monthNo > 12)
                {
                    Console.WriteLine("Вы ввели неправильный месяц");
                    Console.WriteLine("Завершение работы...");
                    return 0;
                }
                else if (monthNo == 12 || monthNo == 1 || monthNo == 2)
                {

                    Seasons x = (Seasons)1;
                    object season = x;
                    return season;
                }


                else if (monthNo == 3 || monthNo == 4 || monthNo == 5)
                {
                    Seasons x = (Seasons)2;
                    object season = x;
                    return season;
                }

                else if (monthNo == 6 || monthNo == 7 || monthNo == 8)
                {
                    Seasons x = (Seasons)3;
                    object season = x;
                    return season;
                }
                else
                {
                    Seasons x = (Seasons)4;
                    object season = x;
                    return season;
                }

            }
            Console.Write("Для выхода нажмите Enter\n");
            Console.ReadKey();



        }

    }
    
}
        
    

