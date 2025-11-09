using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem3pract4
{
    public static class PrintFunctions
    {
        public static void PrintCollection<T>(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                Console.WriteLine("Коллекция пуста\n");
                return;
            }
            foreach(var item in collection)
            {
                Console.WriteLine($"--{item}");
            }
            Console.WriteLine();
        }
    }
}
