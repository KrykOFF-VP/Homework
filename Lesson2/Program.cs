using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    internal class Program
    {
        /// <summary>
        /// Оформление меню приложения и точки входа
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("Мои задачи");
            Console.WriteLine("=================================");
            Console.WriteLine("1 -> Задание 1");
            Console.WriteLine("2 -> Задание 2");
            Console.WriteLine("3 -> Задание 3");
            Console.WriteLine("4 -> Задание 4");
            //Console.WriteLine("5 -> Задание 5");
            //Console.WriteLine("6 -> Задание 6");
            Console.WriteLine("0 -> Завершение работы приложения");
            Console.WriteLine("=================================");

            Console.WriteLine("Введите номер задачи: ");
            double number = double.Parse(Console.ReadLine());

            switch (number)                                                                                                 //Создание меню программы
            {
                case 0:
                    Console.WriteLine("Завершение рвботы приложения");
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

                case 4:
                    Task4();
                    break;

                //case 5:
                //Task5();
                //break;

                //case 6:
                //Task6();
                //break;

                default:
                    Console.WriteLine("Укажите значение от 0 до 6");
                    break;
            }

            Task1();
            Task2();
            Task3();
            Task4();
            // Task5();
            // Task6();


        }
        /// <summary>
        /// Оформление первой задачи
        /// </summary>
        static void Task1()
        {
            Console.WriteLine($"Здравствуйте, укажите пожалуйста максимальную суточную температуру");
            int maxtemp = int.Parse(Console.ReadLine());

            Console.WriteLine($"А так же минимальную суточную температуру");
            int mintemp = int.Parse(Console.ReadLine());

            int middletemp = CalcMiddleTemp(maxtemp, mintemp);
            Console.WriteLine($"Среднесуточная температура:  {middletemp}");
            Console.ReadKey();
            return ;    
        }
        /// <summary>
        /// Вычесление среднесуточной температуры
        /// </summary>
        /// <param name="maxtemp"> Максимальная суточная температура </param>
        /// <param name="mintemp"> Минимальная суточная температура  </param>
        /// <returns></returns>
        static int CalcMiddleTemp(int maxtemp, int mintemp)
        {
            return (maxtemp + mintemp) / 2;
        }

        /// <summary>
        /// Оформление второй задачи
        /// </summary>
        static void Task2()
        {
            Console.WriteLine($"Здравствуйте, укажите пожалуйста порядковый номер текущего месяца");
            double month = double.Parse(Console.ReadLine());

            switch (month)                                                                                           // Создание списка с возможностью выбора 
            {
                case 1:
                    Console.WriteLine("Январь");
                    Console.ReadKey();
                    return;

                case 2:
                    Console.WriteLine("Февраль");
                    Console.ReadKey();
                    return;

                case 3:
                    Console.WriteLine("Март");
                    Console.ReadKey();
                    return;

                case 4:
                    Console.WriteLine("Апрель");
                    Console.ReadKey();
                    return;

                case 5:
                    Console.WriteLine("Май");
                    Console.ReadKey();
                    return;

                case 6:
                    Console.WriteLine("Июнь");
                    Console.ReadKey();
                    return;

                case 7:
                    Console.WriteLine("Июль");
                    Console.ReadKey();
                    return;

                case 8:
                    Console.WriteLine("Август");
                    Console.ReadKey();
                    return;

                case 9:
                    Console.WriteLine("Сентябрь");
                    Console.ReadKey();
                    return;

                case 10:
                    Console.WriteLine("Октябрь");
                    Console.ReadKey();
                    return;

                case 11:
                    Console.WriteLine("Ноябрь");
                    Console.ReadKey();
                    return;

                case 12:
                    Console.WriteLine("Декабрь");
                    Console.ReadKey();
                    return;

                default:
                    Console.WriteLine("Укажите значение от 0 до 12");
                    break;



            }
            Console.ReadKey();
            return;

        }

        /// <summary>
        /// Оформление третьей задачи
        /// </summary>
        static void Task3()
        {
            Console.WriteLine($"Здравствуйте, укажите пожалуйста любое число ");
            long num = long.Parse(Console.ReadLine());

            long even = num % 2;                                                                                 // Вычисление остатка от числа деления

            if (even == 0)
            {
                Console.WriteLine($" Число {num} - чётное");

            }
            else
            {
                Console.WriteLine($" Число {num} - нечётное");
            }
            Console.ReadKey();
            return ;
        }
        /// <summary>
        /// Оформление четвертой  задачи
        /// </summary>

        static void Task4()
        {
            int znkkt = 32316654;
            
            Console.WriteLine("Прайс");
            Console.WriteLine("=================================");
            Console.WriteLine("1->Чай  153 руб.");
            Console.WriteLine("2->Кофе 186 руб.");
            Console.WriteLine("3->Круасан 195 Руб.");
            Console.WriteLine("4->Пончик 99 руб.");
            Console.WriteLine("0 -> Завершение работы приложения");
            Console.WriteLine("=================================");

            Console.WriteLine($"Здравствуйте, выберите пожалуйста товар");
            string pricename = "";                                                                                     
            int choice = int.Parse(Console.ReadLine());                                                               // Создание переменной выбора
            int price=0;

            switch (choice)
                                                                                                                    // Создание списка с возможностью выбора 
            {
                case 0:
                    Console.WriteLine("Завершение работы приложения");

                    break;
                case 1:
                    pricename = "Чай";
                    price = 153;
                    break;

                case 2:
                    pricename = "Кофе";
                    price = 186;
                    break;

                case 3:
                    pricename = "Круасан";
                    price = 195;
                    break;
                case 4:
                    pricename = "Пончик";
                    price = 99;
                    break;
                default:
                    Console.WriteLine("Укажите значение от 0 до 4");
                    break;
            }
            Console.WriteLine($"Введите колличество товара");
            int amountnt = int.Parse(Console.ReadLine());
            int sumprice = Calcprice( price, amountnt);
            int NDS = sumprice / 100 * 6;
            DateTime data = DateTime.Now;


            Console.WriteLine("Приход");
            Console.WriteLine("____________ЧЕК ПРОДАЖИ____________ ");
            Console.WriteLine($"Заводской номер ккт {znkkt}");
            Console.WriteLine($"{pricename}  x  {amountnt}=...............{sumprice}");
            Console.WriteLine($"В Том числе НДС...........{NDS}");
            Console.WriteLine($"Дата: {data}");
            Console.WriteLine("________Спасибо за покупку_________");
            Console.ReadKey();
            return;
        }

        static int Calcprice(int price, int amountnt)
        {
            return amountnt * price;
        }



    }




}




