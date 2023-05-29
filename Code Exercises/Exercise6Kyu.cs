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
    }
}
