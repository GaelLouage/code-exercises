using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Exercises
{
    internal class Diverse
    {
        public static string AlphabetPosition(string text)
        {
            var positions = new StringBuilder();
            string alfa = "abcdefghijklmnopqrstuvwxyz";
            foreach (var c in text.ToLower())
            {
                if (alfa.Contains(c.ToString()))
                {
                    positions.Append(alfa.IndexOf(c) + 1 + " ");
                }

            }
            return positions.ToString().Trim();
        }
        public static string AlphabetPositionLinq(string text) =>
            string.Join(" ", text.ToLower().Where(c => char.IsLetter(c)).Select(x => "abcdefghijklmnopqrstuvwxyz".IndexOf(x) + 1).ToArray());
        public static int Persistence(long n)
        {
            int result = 0;
            long tempNumber = n;

            if (tempNumber.ToString().Length == 1)
                return 0;

            while (tempNumber.ToString().Length > 1)
            {
                string tempNumberAsString = tempNumber.ToString();
                int product = 1;

                for (int i = 0; i < tempNumberAsString.Length; i++)
                {
                    product *= (int)char.GetNumericValue(tempNumberAsString[i]);
                }

                result++;
                tempNumber = product;
            }

            return result;
        }

        public static int NthSmallest(int[][] arr, int n)
        {
            List<int> arrTemp = new List<int> { };
            foreach (int[] array in arr)
            {
                foreach (int value in array)
                {
                    arrTemp.Add(value);
                }
            }
            arrTemp.Sort();
            return arrTemp[n - 1];
        }
        public static int NthSmallestLinq(int[][] arr, int n) => arr.SelectMany(x => x).OrderBy(x => x).Skip(n - 1).First();
        public static string High(string s)
        {
            var alfaHigh = new List<int>();
            int points = 1;
            var alfa = "abcdefghijklmnopqrstuvwxyz";
            var splittedString = s.Split(" ");
            foreach (var c in splittedString)
            {
                foreach (char ch in c)
                {
                    points += alfa.IndexOf(ch) + 1;
                }
                alfaHigh.Add(points);
                points = 0;
            }
            int max = alfaHigh[0];
            int index = 0;
            for (int i = 0; i < alfaHigh.Count; i++)
            {
                if (max < alfaHigh[i])
                {
                    max = alfaHigh[i];
                    index = i;
                }
            }
            return splittedString[index];
        }
        public static int[] MoveZeroes(int[] arr)
        {
            // TODO: Program me
            var nulls = new List<int>();
            var nonNulls = new List<int>();
            var newArray = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    nulls.Add(arr[i]);
                }
                else
                {
                    nonNulls.Add(arr[i]);
                }
            }
            newArray.AddRange(nonNulls);
            newArray.AddRange(nulls);
            return newArray.ToArray();
        }
        public static int[] MoveZeroesLinq(int[] arr) =>
         arr.OrderBy(x => x == 0).ToArray();
        //The main idea is to count all the occurring characters in a string. If you have a string
        //like aba, then the result should be {'a': 2, 'b': 1}.
        public static Dictionary<char, int> CountLinq(string str) =>
            str.GroupBy(x => x).ToDictionary(c => c.Key, c => c.Count());
        public static Dictionary<char, int> Count(string str)
        {
            var dictionary = new Dictionary<char, int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (dictionary.ContainsKey(str[i]))
                {
                    dictionary[str[i]] += 1;
                }
                else
                {
                    dictionary.Add(str[i], 1);
                }
            }
            return dictionary;
        }
        public static string Rot13(string message)
        {
            // your code here
            string alfa = "abcdefghijklmnopqrstuvwxyz";
            var rot13 = new StringBuilder();
            foreach (var c in message)
            {
                if (char.IsUpper(c))
                {
                    var tempLower = c.ToString().ToLower();
                    var setUpper = "";
                    if (alfa.IndexOf(tempLower) + 13 > 25)
                    {
                        setUpper = alfa[alfa.IndexOf(tempLower) + 13 - 26].ToString().ToUpper();
                        rot13.Append(setUpper);
                    }
                    else
                    {
                        setUpper = alfa[alfa.IndexOf(tempLower) + 13].ToString().ToUpper();
                        rot13.Append(setUpper);
                    }
                    setUpper = "";
                }

                if (alfa.Contains(c))
                {
                    if (alfa.IndexOf(c) + 13 > 25)
                    {
                        rot13.Append(alfa[alfa.IndexOf(c) + 13 - 26]);
                    }
                    else
                    {
                        rot13.Append(alfa[alfa.IndexOf(c) + 13]);
                    }
                }
                else if (!char.IsUpper(c))
                {
                    rot13.Append(c);
                }
            }
            return rot13.ToString();
        }
        /*John has invited some friends. His list is:

        s = "Fred:Corwill;Wilfred:Corwill;Barney:Tornbull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
        Could you make a program that
        
        makes this string uppercase
        gives it sorted in alphabetical order by last name.
        When the last names are the same, sort them by first name. Last name and first name of a guest come in the result between parentheses separated by a comma.
        
        So the result of function meeting(s) will be:*/
        public static string Meeting(string s)
        {
            // your code
            var splitted = s.Split(";");
            var persons = new List<string>();
            foreach (var name in splitted)
            {
                var sp = name.Split(":");
                persons.Add($"({sp[1].ToUpper()}, {sp[0].ToUpper()})");

            }
            return string.Join("", persons.OrderBy(x => x));
        }

        public static string MeetingLinq(string s) =>
    string.Join("", s.Split(";").Select(x => new { Name = $"({x.Split(":")[1].ToUpper()}, {x.Split(":")[0].ToUpper()})" }).OrderBy(x => x.Name).Select(x => x.Name));

        public static int[] ArrayDiff(int[] a, int[] b)
        {
            // Your brilliant solution goes here
            // It's possible to pass random tests in about a second ;)
            var arrayDiff = a.ToList();
            for (int i = 0; i < b.Length; i++)
            {
                arrayDiff.RemoveAll(x => x == b[i]);
            }
            return arrayDiff.ToArray();
        }

        public static int[] ArrayDiff(int[] a, int[] b) =>
        a.Where(x => !b.Contains(x)).ToArray();
    }

}
