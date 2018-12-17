using System;
using System.Collections.Generic;
using System.Linq;

namespace Asteroids
{
    public class TasksLists
    {
        private static List<int> _myInts;

        static TasksLists()
        {
            _myInts = new List<int>();
            var rnd = new Random();
            var count = 10;
            for (int i = 0; i < count; i++)
                _myInts.Add(rnd.Next(5)); 
        }

        public static void Run()
        {
            SearchForIntNumbers(_myInts);
            SearchForGenericCollection(_myInts);
            SearchWithLinq(_myInts);
            Test();

            Console.ReadKey();
        }

        /// <summary>
        /// Поиск для целый чисел
        /// </summary>
        /// <param name="myList"></param>
        public static void SearchForIntNumbers(List<int> myList)
        {
            Console.WriteLine("Для целых чисел");
            for (int i = 0; i < myList.Count; i++)
            {
                var count = 0;
                for (int j = 0; j < myList.Count; j++)
                {
                    if (myList[i].Equals(myList[j])) count++;
                }
                Console.WriteLine($"Число {myList[i]} содержится {count} раз");
            }
        }

        /// <summary>
        /// Поиск для обощенных коллекций
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="myList"></param>
        public static void SearchForGenericCollection<T>(List<T> myList)
        {
            Console.WriteLine("Для обобщенных коллекций");
            for (int i = 0; i < myList.Count; i++)
            {
                var count = 0;
                for (int j = 0; j < myList.Count; j++)
                {
                    if (Equals(myList[i], myList[j])) count++;
                }
                Console.WriteLine($"Число {_myInts[i]} содержится в массиве {count} раз");
            }
        }

        /// <summary>
        /// Поиск с помощщью Linq
        /// </summary>
        public static void SearchWithLinq(List<int> myList)
        {
            Console.WriteLine("С помощью Linq");
            myList.ForEach(i => Console.WriteLine(myList.Count(j => j == i)));
        }

        /// <summary>
        /// Свернуть-развернуть
        /// </summary>
        public static void Test()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four", 4 },
                {"two", 2 },
                { "one", 1 },
                {"three", 3 },
            };
            Console.WriteLine("Неотсортированный словарь");
            foreach (var pair in dict)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }

            Console.WriteLine("OrderBy с делегатом");
            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }

            Console.WriteLine("OrderBy с лямбда-выражением");
            d = dict.OrderBy(x => x.Value);
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }

        }
    }
}
