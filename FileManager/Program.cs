using Filemanager.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace FileManager
{
    internal class Program
    {
        const int WINDOW_HEIGTH = 30;
        const int WINDOW_WIDTH = 120;
        private static string currentDir = Directory.GetCurrentDirectory();


        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Title = "Filemanager";
            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGTH);
            Console.SetBufferSize(WINDOW_WIDTH, WINDOW_HEIGTH);

            DrawWindow(0, 0, WINDOW_WIDTH, 18);
            DrawWindow(0, 18, WINDOW_WIDTH, 8);
            UpdateConsole();
            Console.ReadKey(true);

        }
        /// <summary>
        /// Вспомогательный метод получения, текущей позиции курсора
        /// </summary>
        /// <returns></returns>
        static (int left, int top) GetCursorPosition()
        {
            return (Console.CursorLeft, Console.CursorTop);
        }

        /// <summary>
        /// Обработка процесса ввода данных с консоли
        /// </summary>
        /// <param name="width">Длинна строки ввода</param>
        static void ProcessEnterCommand(int width)
        {
            (int left, int top) = GetCursorPosition();
            StringBuilder command = new StringBuilder();
            ConsoleKeyInfo keyinfo;
            char key;
            do
            {
                keyinfo = Console.ReadKey();
                key = keyinfo.KeyChar;
                if (keyinfo.Key != ConsoleKey.Enter && keyinfo.Key != ConsoleKey.Backspace &&
                   keyinfo.Key != ConsoleKey.UpArrow)
                    command.Append(key);
                (int currentleft, int currenttop) = GetCursorPosition();

                if (currentleft == width - 2)
                {
                    Console.SetCursorPosition(currentleft - 1, top);
                    Console.Write(" ");
                    Console.SetCursorPosition(currentleft - 1, top);
                }

                if (keyinfo.Key == ConsoleKey.Backspace)
                {
                    if (command.Length > 0)
                        command.Remove(command.Length - 1, 1);
                    if (currentleft >= left)
                    {
                        Console.SetCursorPosition(currentleft, top);
                        Console.Write(" ");
                        Console.SetCursorPosition(currentleft, top);
                    }
                    else
                    {
                        command.Clear();
                        Console.SetCursorPosition(left, top);
                    }

                }
            }
            while (keyinfo.Key != ConsoleKey.Enter);
            ParseCommandSring(command.ToString());


        }
        static void ParseCommandSring(string command)
        {
            string[] commandParams = command.ToLower().Split(' ');
            if (commandParams.Length > 0)
            {
                switch (commandParams[0])
                {
                    case "cd":
                        if (commandParams.Length > 1)
                            if (Directory.Exists(commandParams[1]))
                            {
                                currentDir = commandParams[1];

                            }
                        break;
                    case "ls":
                        if (commandParams.Length > 1 && Directory.Exists(commandParams[1]))
                            if (commandParams.Length > 3 && commandParams[2] == "-p" && int.TryParse(commandParams[3], out int n))
                            {
                                DrawTree(new DirectoryInfo(commandParams[1]), n);

                            }
                            else
                            {
                                DrawTree(new DirectoryInfo(commandParams[1]), 1);
                                UpdateConsole();
                            }
                        break;
                    case "cp":
                        if (commandParams.Length > 2)
                        {

                            if (File.Exists(commandParams[1]))
                            {
                                try                                                                                                                 // поиск исключений
                                {
                                    Console.WriteLine(@"Копирование {0}\{1}", commandParams[1], commandParams[2]);
                                    File.Create(commandParams[2]).Dispose();
                                    File.Copy(commandParams[1], commandParams[2], true);

                                }
                                catch (Exception ex)
                                {
                                    DrawWindow(0, 18, WINDOW_WIDTH, 8);
                                    System.Threading.Thread.Sleep(100);
                                    Console.SetCursorPosition(2, 19);
                                    Console.WriteLine($"произошло исключение.\n{ex.Message}");

                                }

                            }

                            else if (Directory.Exists(commandParams[1]))
                            {
                                try                                                                                                                 // поиск исключений
                                {

                                    CopyDir(commandParams[1], commandParams[2]);
                                    DrawWindow(0, 0, WINDOW_WIDTH, 18);
                                    DrawWindow(0, 18, WINDOW_WIDTH, 8);
                                    UpdateConsole();
                                }
                                catch (Exception ex)
                                {
                                    DrawWindow(0, 18, WINDOW_WIDTH, 8);
                                    System.Threading.Thread.Sleep(100);
                                    Console.SetCursorPosition(2, 19);
                                    Console.WriteLine($"произошло исключение.\n{ex.Message}");

                                }
                            }

                        }
                        break;
                    case "rm":
                        if (commandParams.Length > 1)
                            if (File.Exists(commandParams[1]))
                            {
                                try                                                                                                                 // поиск исключений
                                {
                                    Console.WriteLine($"Удаление  {commandParams[1]}");
                                    File.Delete(commandParams[1]);
                                }
                                catch (Exception ex)
                                {
                                    DrawWindow(0, 18, WINDOW_WIDTH, 8);
                                    System.Threading.Thread.Sleep(100);
                                    Console.SetCursorPosition(2, 19);
                                    Console.WriteLine($"произошло исключение.\n{ex.Message}");

                                }

                            }
                            else if (Directory.Exists(commandParams[1]))
                            {

                                try                                                                                                                 // поиск исключений
                                {
                                    Console.WriteLine($"Удаление  {commandParams[1]}");
                                    DelDir(commandParams[1]);
                                    DrawWindow(0, 0, WINDOW_WIDTH, 18);
                                    DrawWindow(0, 18, WINDOW_WIDTH, 8);
                                    UpdateConsole();
                                }
                                catch (Exception ex)
                                {
                                    DrawWindow(0, 18, WINDOW_WIDTH, 8);
                                    System.Threading.Thread.Sleep(100);
                                    Console.SetCursorPosition(2, 19);
                                    Console.WriteLine($"произошло исключение.\n{ex.Message}");
                                }

                            }
                        break;
                    case "info":
                        if (commandParams.Length > 1)
                            if (File.Exists(commandParams[1]))
                            {
                                try                                                                                                                 // поиск исключений
                                {
                                    DrawWindow(0, 18, WINDOW_WIDTH, 8);
                                    System.Threading.Thread.Sleep(100);
                                    InfoFile(new FileInfo(commandParams[1]));
                                }
                                catch (Exception ex)
                                {
                                    DrawWindow(0, 18, WINDOW_WIDTH, 8);
                                    System.Threading.Thread.Sleep(100);
                                    Console.SetCursorPosition(2, 19);
                                    Console.WriteLine($"произошло исключение.\n{ex.Message}");

                                }

                            }
                            else if (Directory.Exists(commandParams[1]))
                            {
                                try                                                                                                                 // поиск исключений
                                {
                                    DrawWindow(0, 18, WINDOW_WIDTH, 8);
                                    System.Threading.Thread.Sleep(100);
                                    DirInfo(new DirectoryInfo(commandParams[1]));

                                }
                                catch (Exception ex)
                                {
                                    DrawWindow(0, 18, WINDOW_WIDTH, 8);
                                    System.Threading.Thread.Sleep(100);
                                    Console.SetCursorPosition(2, 19);
                                    Console.WriteLine($"произошло исключение.\n{ex.Message}");

                                }
                                
                            }
                        break;
                }    

            }

            UpdateConsole();
        }
        static string GetShortPath(string path)
        {

            StringBuilder shortPathName = new StringBuilder((int)API.MAX_PATH);
            API.GetShortPathName(path, shortPathName, API.MAX_PATH);
            return shortPathName.ToString();

        }


        /// <summary>
        /// Обновление ввода с консоли
        /// </summary>
        static void UpdateConsole()
        {
            DrawConsole(GetShortPath(currentDir), 0, 26, WINDOW_WIDTH, 3);
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
        static void DrawConsole(string dir, int x, int y, int width, int height)
        {
            DrawWindow(x, y, width, height);
            Console.SetCursorPosition(x + 1, y + height / 2);
            Console.Write($"{dir}>");

        }

        /// <summary>
        /// Отрисовка Окна
        /// </summary>
        /// <param name="x">Начальная позиция по оси X</param>
        /// <param name="y">Начальная позиция по оси Y</param>
        /// <param name="width">Ширина окна</param>
        /// <param name="height">Высота окна</param>
        static void DrawWindow(int x, int y, int width, int height)
        {

            // header - шапка
            Console.SetCursorPosition(x, y);
            Console.Write("╔");

            for (int i = 0; i < width - 2; i++)
                Console.Write("═");

            Console.Write("╗");

            // Window-окно
            Console.SetCursorPosition(x, y + 1);
            for (int i = 0; i < height - 2; i++)
            {
                Console.Write("║");
                for (int j = x + 1; j < x + width - 1; j++)
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
        /// <summary>
        /// Отрисовать дерево каталогов
        /// </summary>
        /// <param name="dir">Директория</param>
        /// <param name="page">Страница</param>
        static void DrawTree(DirectoryInfo dir, int page)
        {
            StringBuilder tree = new StringBuilder();
            GetTree(tree, dir, "", true);
            DrawWindow(0, 0, WINDOW_WIDTH, 18);
            (int currentLeft, int currentTop) = GetCursorPosition();
            int pageLines = 16;
            string[] lines = tree.ToString().Split('\n');
            int pageTotal = (lines.Length + pageLines - 1) / pageLines;
            if (page > pageTotal)
                page = pageTotal;

            for (int i = (page - 1) * pageLines, counter = 0; i < page * pageLines; i++, counter++)
            {
                if (lines.Length - 1 > i)
                {
                    Console.SetCursorPosition(currentLeft + 1, currentTop + 1 + counter);
                    Console.WriteLine(lines[i]);
                }

            }
            //Отрисуем Footer
            string footer = $"╡ {page} of {pageTotal} ╞";
            Console.SetCursorPosition(WINDOW_WIDTH / 2 - footer.Length / 2, 17);
            Console.WriteLine(footer);


        }

        static void GetTree(StringBuilder tree, DirectoryInfo dir, string indent, bool lastDirectory)
        {
            tree.Append(indent);
            if (lastDirectory)
            {
                tree.Append("└");
                indent += " ";
            }
            else
            {
                tree.Append("├");
                indent += "│ ";

            }
            tree.Append($"{dir.Name}\n");

            FileInfo[] subFiles = dir.GetFiles();
            for (int i = 0; i < subFiles.Length; i++)
            {
                if (i == subFiles.Length - 1)
                {
                    tree.Append($"{indent}└{subFiles[i].Name}\n");

                }
                else
                {
                    tree.Append($"{indent}├{subFiles[i].Name}\n");

                }

            }
            DirectoryInfo[] subDirects = dir.GetDirectories();
            for (int i = 0; i < subDirects.Length; i++)
                GetTree(tree, subDirects[i], indent, i == subDirects.Length - 1);
        }




        /// <summary>
        /// Скопировать дирректорию
        /// </summary>
        /// <param name="sourceDirectory">Начальная Дерриктория</param>
        /// <param name="targetDirectory">Целевая дирректория</param>
        public static void CopyDir(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);
            CopyAll(diSource, diTarget);
        }
        /// <summary>
        /// Метод копирования
        /// </summary>
        /// <param name="source">Изначальная дирректория </param>
        /// <param name="target">Целевая дирректория</param>
        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            // Создание дирректории ,если  она отсутсвует
            if (Directory.Exists(target.FullName) == false)
            {
                Directory.CreateDirectory(target.FullName);
            }

            // Копируем все файлы в новую директорию
            foreach (FileInfo files in source.GetFiles())
            {

                Console.WriteLine(@"Копирование {0}\{1}", target.FullName, files.Name);

                files.CopyTo(Path.Combine(target.ToString(), files.Name), true);


            }


            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {

                DirectoryInfo nextTargetSubDir =
                  target.CreateSubdirectory(diSourceSubDir.Name);


                CopyAll(diSourceSubDir, nextTargetSubDir);
            }


        }


        /// <summary>
        /// Удалить дирректорию
        /// </summary>
        /// <param name="delDirectory">Удаляемая директория</param>
        public static void DelDir(string delDirectory)
        {
            DirectoryInfo dirdel = new DirectoryInfo(delDirectory);
            DirectoryInfo[] deleted = dirdel.GetDirectories();

            foreach (FileInfo file in dirdel.GetFiles())
            {
                Console.WriteLine(@"Удаление {0}\{1}", dirdel.FullName, file.Name);
                string targetFilePath = Path.Combine(delDirectory, file.Name);
                file.Delete();
            }



            foreach (DirectoryInfo subDir in deleted)
            {

                DelDir(subDir.FullName);
            }
            Directory.Delete(delDirectory);

        }

       
        
        static  void InfoFile( FileInfo file)
        {
            Console.SetCursorPosition(2, 19);
            Console.WriteLine($"{file.Attributes}- Название");
            Console.SetCursorPosition(2, 20);
            Console.WriteLine($"{file.FullName}- Путь");
            Console.SetCursorPosition(2, 21);
            Console.WriteLine($"{file.Extension}- Расширение");            
            Console.SetCursorPosition(2, 22);
            Console.WriteLine($"{file.LastAccessTime}- Время последнего изменения");
            Console.SetCursorPosition(2, 23);
            Console.WriteLine($"{file.CreationTime}- Время создания");            
            Console.SetCursorPosition(2, 24);
            Console.WriteLine($"Размер {file.Length} Байт"); 

        }

        static void DirInfo(DirectoryInfo dir)
        {
    
            Console.SetCursorPosition(2, 20);
            Console.WriteLine($"{dir.FullName}- Путь");
            Console.SetCursorPosition(2, 21);
            Console.WriteLine($"{dir.LastWriteTime}- Время последнего чтения");
            Console.SetCursorPosition(2, 22);
            Console.WriteLine($"{dir.LastAccessTime}- Время последнего изменения");
            Console.SetCursorPosition(2, 23);
            Console.WriteLine($"{dir.CreationTime}- Время создания");
           

        }

    }
}