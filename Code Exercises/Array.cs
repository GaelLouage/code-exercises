using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Exercises
{
    internal class Array
    {
        //Write a C# Sharp program in to count duplicate elements in an array.
        public static int CountDuplicates(int[] array)
        {
            var duplicates = new Dictionary<int, int>();
            foreach (var num in array)
            {
                if (duplicates.ContainsKey(num))
                {
                    duplicates[num]++;
                }
                else
                {
                    duplicates.Add(num, 1);
                }
            }
            return duplicates.Count(x => x.Value > 1);
        }

        public static int CountDuplicatesLinq(int[] array) =>
         array.GroupBy(x => x).Count(z => z.Count() > 1);
        public static IEnumerable<T> GetAllUniqueValues<T>(List<T> values) =>
                values.GroupBy(x => x).Where(x => x.Count() <= 1).Select(x => x.Key);
        /*"How can I merge two lists together and sort the resulting list in C#?*/
        public static IEnumerable<T> MergeTwoList<T>(List<T> listOne, List<T> listTwo)
        {
            listOne.AddRange(listTwo);
            return listOne.OrderBy(x => x);
        }
        /*using func to test*/
        public static Func<IEnumerable<T>> MergeTwoListFunc<T>(List<T> listOne, List<T> listTwo)
        {

            return () =>
            {
                listOne.AddRange(listTwo);
                return listOne.OrderBy(x => x);
            };
        }
    }
}
