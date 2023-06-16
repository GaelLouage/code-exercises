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
    }

}
