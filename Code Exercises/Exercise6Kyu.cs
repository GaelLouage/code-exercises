using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Exercises
{
    internal  class Exercise6Kyu
    {
        public  StringBuilder BreakCamelCase(string str)
        {
            // complete the function
            var builder = new StringBuilder();
            foreach (var c in str)
            {
                if (char.IsUpper(c))
                {
                    builder.Append(" ");
                }
                builder.Append(c);
            }
            return builder;
        }
        public static string BreakCamelCaseLinq(string str) => string.Concat(str.Select(x => char.IsUpper(x) ? " " + x : x.ToString()));
        /*Count the number of Duplicates
        Write a function that will return the count of distinct case-insensitive alphabetic characters and numeric digits that occur more than once in the input string.
        The input string can be assumed to contain only alphabets (both uppercase and lowercase) and numeric digits.*/
        public static int DuplicateCount(string str)
        {
            return str.ToLower().ToCharArray().GroupBy(x => x).Where(x => x.Count() > 1).Count();
        }
    }
}
