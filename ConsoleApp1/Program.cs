using Homework.MyUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            //Вывод с помошью класса
            OutputHelpers.PrintInfo(8, "Крюков Виталий Павлович");
            //Вывод ранее сохраненных данных
            Console.Title = Properties.Settings.Default.ApplicationName;
            Console.WriteLine($"{ Properties.Settings.Default.Greeting}: {Properties.Settings.Default.Name}");            
            Console.WriteLine($"Возраст: {Properties.Settings.Default.Age}");
            Console.WriteLine($"Деятельность: {Properties.Settings.Default.Activity}");            
            Console.WriteLine("===========================================");

            // Запись пользователя в файл настрек
            Console.Write("Для редактирования  пользователя введите ваше имя:  ");
            Properties.Settings.Default.Name=Console.ReadLine();
            Console.Write("Возраст: ");
            Properties.Settings.Default.Age=int.Parse(Console.ReadLine());
            Console.Write($"Деятельность: ");
            Properties.Settings.Default.Activity = Console.ReadLine();
            Properties.Settings.Default.Save();

            Console.ReadKey();
            return;

        }

    }



}
