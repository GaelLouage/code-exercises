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
    }

}
