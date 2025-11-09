using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem3pract4
{
    public static class Tasks
    {
        public static void Task1()
        {
            Console.WriteLine("====================ЗАДАНИЕ 1=====================");

            string[] months =
            {
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
            };

            // последовательность месяцев с длиной названия равной n
            int n = 8;
            var selectedMonths1 = from m in months
                                  where m.Length == n
                                  select m;
            Console.WriteLine("Месяцы с длиной названия 8:\nИспользуя операторы запросов:");
            PrintFunctions.PrintCollection(selectedMonths1);

            var selectedMonths2 = months.Where(m => m.Length == n);
            Console.WriteLine("Используя методы расширения:");
            PrintFunctions.PrintCollection(selectedMonths2);


            //только летние и зимние месяцы
            string[] onlySummerAndWinter = { "June", "July", "August", "December", "January", "February" };
            var selectedMonths3 = from m in months
                                  where onlySummerAndWinter.Contains(m)
                                  select m;
            Console.WriteLine("\nТолько летние и зимние месяцы:\nИспользуя операторы запросов:");
            PrintFunctions.PrintCollection(selectedMonths3);

            var selectedMonths4 = months.Where(m => onlySummerAndWinter.Contains(m));
            Console.WriteLine("Используя метод расширения:");
            PrintFunctions.PrintCollection(selectedMonths4);


            // названия месяцев в алфовитном порядке
            var selectedMonths5 = from m in months
                                  orderby m
                                  select m;
            Console.WriteLine("\nНазвания месяцев в алфавитном порядке:\nИспользуя операторы запросов:");
            PrintFunctions.PrintCollection(selectedMonths5);

            var selectedMonths6 = months.OrderBy(m => m);
            Console.WriteLine("Используя метод расширения:");
            PrintFunctions.PrintCollection(selectedMonths6);


            // количество месяцев, содержащих в названии букву "u" и длиной имени не менее 4 символов
            Console.WriteLine("\nКоличество месяцев, содержащих в названии букву \"u\" и длиной имени не менее 4 символов:");
            var selectedMonths7 = from m in months
                                  where m.Contains("u") && m.Length >= 4
                                  select m;
            Console.WriteLine("Используя операторы запросов:");
            PrintFunctions.PrintCollection(selectedMonths7);

            var selectedMonths8 = months.Where(m => m.Contains("u") && m.Length >= 4);
            Console.WriteLine("Используя метод расширения:");
            PrintFunctions.PrintCollection(selectedMonths8);
        }

        public static List<IntArray> Task3()
        {
            List<IntArray> list = new List<IntArray>
            {
                new IntArray(new int[] {1, 2, 3, 4, 5, 6, 7}),
                new IntArray(new int[] {10, 20, 30, 40, 50}),
                new IntArray(new int[] {2, 4, 6, 8, 10, 12}),
                new IntArray(new int[] {5, 10, 15, 20, 25}),
                new IntArray(new int[] {1, 3, 5, 7, 9, 11, 13}),
                new IntArray(new int[] {100, 200, 300}),
                new IntArray(new int[] {8, 6, 7, 5, 3, 0, 9}),
                new IntArray(new int[] {12, 24, 36, 48}),
                new IntArray(new int[] {11, 22, 33, 44, 55}),
                new IntArray(new int[] {9, 8, 7, 6, 5, 4}),
                new IntArray(new int[] {15, 30, 45, 60}),
                new IntArray(new int[] {1, 1, 2, 3, 5, 8, 13}),
                new IntArray(new int[] {7, 14, 21, 28, 35}),
                new IntArray(new int[] {4, 8, 12, 16, 20, 24}),
                new IntArray(new int[] {25, 50, 75, 100}),
                new IntArray(new int[] {6, 12, 18, 24, 30}),
                new IntArray(new int[] {3, 6, 9, 12, 15, 18}),
                new IntArray(new int[] {20, 40, 60, 80}),
                new IntArray(new int[] {13, 26, 39, 52}),
                new IntArray(new int[] {23, 46, 69, 92}),
                new IntArray(new int[] {27, 54, 81}),
                new IntArray(new int[] {31, 62, 93}),
                new IntArray(new int[] {35, 70}),
                new IntArray(5)
            };
            return list;
        }


        public static void Task4()
        {
            List<IntArray> list = Task3();

            // вывести массивы только с четными значениями элементов
            Console.WriteLine("Массивы только с четными элементами:");
            var selectedArray1 = from array in list
                                 where array.Items.All(x => x % 2 == 0)
                                 select array;
            Console.WriteLine("Используя операторы запросов:");
            PrintFunctions.PrintCollection(selectedArray1);

            Console.WriteLine("Используя методы расширения:");
            var selectedArray2 = list.Where(array => array.Items.All(x => x % 2 == 0));
            PrintFunctions.PrintCollection(selectedArray2);


            // массив с наибольшей суммой элементов
            Console.WriteLine("Массив с наибольшей суммой элементов:");
            var selectedArray3 = (from array in list
                                  orderby array.Items.Sum() descending
                                  select array
                                 ).Take(1);
            Console.WriteLine("Используя операторы запросов:");
            PrintFunctions.PrintCollection(selectedArray3);

            var selectedArray4 = list.OrderByDescending(array => array.Items.Sum()).Take(1);
            Console.WriteLine("Используя методы расширения:");
            PrintFunctions.PrintCollection(selectedArray4);


            // массив с минимальным количеством элементов
            Console.WriteLine("Массив с наименьшим количеством элементов:");
            var selectedArray5 = (from array in list
                                  orderby array.Items.Count()
                                  select array
                                  ).Take(1);
            Console.WriteLine("Используя операторы запросов:");
            PrintFunctions.PrintCollection(selectedArray5);

            var selectedArray6 = list.OrderBy(array => array.Items.Count()).Take(1);
            Console.WriteLine("Используя методы расширения:");
            PrintFunctions.PrintCollection(selectedArray6);


            // количество массивов, содержащих заданное значение (6)
            int requiredNumber = 6;
            Console.WriteLine("Количество массивов, содержащих заданное значение (6):");
            var selectedCount1 = (from array in list
                                  where array.Contains(requiredNumber)
                                  select array
                                 ).Count();
            Console.WriteLine($"Используя операторы запросов: {selectedCount1}");

            var selectedCount2 = list.Where(array => array.Contains(requiredNumber)).Count();
            Console.WriteLine($"Используя методы расширения: {selectedCount2}\n");


            // количество равных по количеству элементов массивов
            Console.WriteLine("Количество массивов по количеству элементов:");
            Console.WriteLine("Используя операторы запросов:");
            var groups1 = from array in list
                          group array by array.Items.Count() into g
                          orderby g.Key
                          select new { Count = g.Key, ArraysCount = g.Count() };
            foreach (var group in groups1)
            {
                Console.WriteLine($"Массивов с {group.Count} элементами: {group.ArraysCount}");
            }

            Console.WriteLine("\nИспользуя методы расширения:");
            var groups2 = list.GroupBy(array => array.Items.Count())
                 .OrderBy(g => g.Key)
                 .Select(g => new { Count = g.Key, ArraysCount = g.Count() });

            foreach (var group in groups2)
            {
                Console.WriteLine($"Массивов с {group.Count} элементами: {group.ArraysCount}");
            }



            // упорядоченный массив массивов по первому элементу(пользователь выбирает, по возрастанию или по убыванию)
            Console.WriteLine("\nУпорядоченный массив массивов по первому элементу:");

            int choice;
            while (true)
            {
                Console.WriteLine("1. Упорядоченный по возрастанию");
                Console.WriteLine("2. Упорядоченный по убыванию");
                Console.Write("Ваш выбор (цифра): ");
                string c = Console.ReadLine();
                if (!int.TryParse(c, out choice))
                {
                    Console.WriteLine("Неверный выбор");
                    continue;
                }
                if (choice != 1 && choice != 2)
                    Console.WriteLine("Неверный выбор");
                else
                    break;
            }

            if (choice == 1)     // по возрастанию
            {
                var ascendingArrays1 = from array in list
                                       orderby array[0]
                                       select array;
                Console.WriteLine("Используя операторы запросов:");
                PrintFunctions.PrintCollection(ascendingArrays1);

                var ascendingArrays2 = list.OrderBy(array => array[0]);
                Console.WriteLine("Используя методы расширения:");
                PrintFunctions.PrintCollection(ascendingArrays2);
            }
            else
            {
                var descendingArrays1 = from array in list
                                        orderby array[0] descending
                                        select array;
                Console.WriteLine("Используя операторы запросов:");
                PrintFunctions.PrintCollection(descendingArrays1);

                var descendingArrays2 = list.OrderByDescending(array => array[0]);
                Console.WriteLine("Используя методы расширения:");
                PrintFunctions.PrintCollection(descendingArrays2);
            }
        }
    }
}
