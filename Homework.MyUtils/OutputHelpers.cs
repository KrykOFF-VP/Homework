using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.MyUtils
{
    public static class OutputHelpers
    {
        public static void PrintInfo(int homeworkNumber, string myname)
        {
            Console.WriteLine($"Домашняя работа. Урок{homeworkNumber}");
            Console.WriteLine($"Студент: {myname}");
            Console.WriteLine("==========================================\n");
        }
    }
}
