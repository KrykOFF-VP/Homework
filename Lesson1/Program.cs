using System;

namespace Lesson1
{
    internal class Program
    {       
        static void Main(string[] args)
        {
            Console.Write($"Укажите ваше имя: ");                                               // Запрашиваем имя
            string name = Console.ReadLine();                                                   //Сохраняем полученные данные в промежуточную переменную
            DateTime mydata = DateTime.Now;                                                     // Создаем переменую, которая получает текущее время
            Console.WriteLine($"Привет, {name} сегодня {mydata.ToString("dd.MM.yyyy")}");       // Выводим приветствие  и дату (ставим формат даты)
        }
    }
}
