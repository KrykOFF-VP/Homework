using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    internal class Program
    {
        const int WINDOW_HEIGTH = 30;
        const int WINDOW_WIDTH = 120;
        private static string currentDir=Directory.GetCurrentDirectory();


        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Title = "Filemanager";
            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGTH);
            Console.SetBufferSize(WINDOW_WIDTH, WINDOW_HEIGTH);

            DrawWindow(0,0,WINDOW_WIDTH,18);
            DrawWindow(0, 18, WINDOW_WIDTH, 8);
            UpdateConsole();
            Console.ReadKey(true);

        }

        /// <summary>
        /// Обработка процесса ввода данных с консоли
        /// </summary>
        /// <param name="width">Длинна строки ввода</param>
        static void ProcessEnterCommand(int width)
        {
         ///ssdfsdf

        }
        /// <summary>
        /// Обновление ввода с консоли
        /// </summary>
        static void UpdateConsole()
        {
            DrawConsole(currentDir, 0, 26, WINDOW_WIDTH, 3);
            ProcessEnterCommand(WINDOW_WIDTH);

        }
        /// <summary>
        /// Отрисовка консоли
        /// </summary>
        /// <param name="dir">Директория</param>
        /// <param name="x">Начальная позиция по оси X</param>
        /// <param name="y">Начальная позиция по оси Y</param>
        /// <param name="width">Ширина окна</param>
        /// <param name="height">Высота окна</param>
        static void DrawConsole(string dir, int x,int y,int width,int height)
        {
            DrawWindow(x, y, width, height);
            Console.SetCursorPosition(x+1, y + height/2);
            Console.Write($"{dir}>");

        }

        /// <summary>
        /// Отрисовка Окна
        /// </summary>
        /// <param name="x">Начальная позиция по оси X</param>
        /// <param name="y">Начальная позиция по оси Y</param>
        /// <param name="width">Ширина окна</param>
        /// <param name="height">Высота окна</param>
        static void DrawWindow(int x, int y, int width,int height)
        {
         
            // header - шапка
            Console.SetCursorPosition(x, y);
            Console.Write("╔");

               for (int i = 0; i < width - 2; i++)
                  Console.Write("═");
        
            Console.Write("╗");

            // Window-окно
            Console.SetCursorPosition(x, y+1);
            for(int i = 0; i < height - 2; i++)
            {
                Console.Write("║");
                for(int j = x+1; j < x+width - 1; j++)
                    Console.Write(" ");

                Console.Write("║");
            }
            // footer - подвал
           Console.Write("╚");

            for (int i = 0; i < width - 2; i++)
                Console.Write("═");

            Console.Write("╝");
            Console.SetCursorPosition(x, y);
        }



    }

}

