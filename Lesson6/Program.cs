using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;



namespace Lesson6
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Console.Out.WriteLine("==========Список  запущенных процессов=========");
            Process[] list = Process.GetProcesses();
            foreach (var process in list)
            {

                Console.Out.WriteLine($"{process.ProcessName}==={process.Id}");

            }
            Console.Out.WriteLine("================================================");




            while (true)
            {
               
                Console.WriteLine("Если хотите закрыть процесс по Id нажите 1, если по имени то нажите 2, для выхода нажмите 0 ");
                int number = int.Parse(Console.ReadLine());

                switch (number)                                                                                                 //Создание меню программы
                {
                    case 0:
                        Console.WriteLine("Завершение работы приложения");
                        Console.ReadKey();
                        return;

                    case 1:
                        Console.Write("Введите ID процесса:   ");
                        int IDnumber = int.Parse(Console.ReadLine());
                        foreach (var process in list)
                        {
                   
                            if (process.Id == IDnumber)
                            {
                                process.Kill();
                            }
                        }
                        Console.Write($"Процесс с ID {IDnumber}-завершен");
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Write("Введите имя процесса:   ");
                        string Nameproc = (Console.ReadLine());
                        foreach (var process in list)
                        {

                            if (process.ProcessName == Nameproc)
                            {
                                process.Kill();
                            }
                        }
                        Console.Write($"Процесс с именем {Nameproc}-завершен");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Укажите значение от 0 до 2");
                        break;
                }

            }

            
       
        }
        
        
        
        
    }
}
