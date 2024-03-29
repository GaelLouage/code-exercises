﻿using System;
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
        /*. Write a C# Sharp program to count the frequency of each element in an array.*/
        public static string GetFrenquencyOfElements(int[] arr)
        {
            var elementDictionary = new Dictionary<int, int>();
            foreach (var num in arr)
            {
                if (elementDictionary.ContainsKey(num))
                {
                    elementDictionary[num]++;

                }
                else
                {
                    elementDictionary.Add(num, 1);
                }
            }

            return string.Join("\n", elementDictionary
                               .Select(x => x.Value > 1 ? $"{x.Key} Occurs : {x.Value} times" : $"{x.Key} Occurs : {x.Value} time"));
        }
        public static string GetFrequencyOfElementsLinq(int[] arr) =>
                            string.Join("\n", arr
                                                    .GroupBy(x => x)
                                                    .Select(x => new Func<string>(() => x.Count() > 1 ? $"{x.Key} occurs {x.Count()} times" : $"{x.Key} occurs {x.Count()} time")()));
        /*Write a C# Sharp program to find the maximum and minimum elements in an array.*/
        public static (int min, int max) GetMinMaxOfArray(int[] array)
        {
            if (array.Length < 1)
            {
                return (0, 0);
            }
            int min = array[0];
            int max = array[0];
            foreach (var num in array)
            {
                if (min > num) min = num;
                if (max < num) max = num;
            }
            return (min: min, max: max);
        }
        public static (int min, int max) GetMinMaxOfArrayLinq(int[] array)
        {
            if (array.Length < 1)
            {
                return (0, 0);
            }
            return (min: array.Min(), max: array.Max());
        }
        //Write a program in C# Sharp to separate odd and even integers into separate arrays.
        public static (int[] arrayEven, int[] arrayOdd) GetEvenAndOddInts(int[] array)
        {
            return (array.Where(x => x % 2 == 0).ToArray(), array.Where(x => x % 2 != 0).ToArray());
        }
        // Write a C# Sharp program to sort elements of an array in ascending order.
        public static IEnumerable<int> OrderInDescendingOrder(int[] array)
        {
            return array.OrderBy(x => x);
        }
        /*Write a C# Sharp program to find the maximum and minimum elements in an array.
        Test Data :
        Input the number of elements to be stored in the array :3
        Input 3 elements in the array :
        element - 0 : 45
        element - 1 : 25
        element - 2 : 21
        Expected Output :
        Maximum element is : 45
        Minimum element is : 21*/
        public static (int min, int max) FindMinAndMaxValue(int[] array)
        {
            if (array is null || array.Length == 0)
            {
                return (0, 0);
            }
            // cannot surpass those values as int
            var min = int.MaxValue;
            var max = int.MinValue;
            foreach (var num in array)
            {
                if (min > num) min = num;
                if (max < num) max = num;
            }
            return (min, max);
        }
    }
}
