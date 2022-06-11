using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.MyUtils
{
    public class OutputHelpers
    {
        public void PrintInfo(int homeworkNumber, string myname)
        {
            Console.WriteLine($"Доашняя работа. Урок{homeworkNumber}");
            Console.WriteLine($"Студент: {myname}");
            Console.WriteLine("==========================================")
        }
    }
}
