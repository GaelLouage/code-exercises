using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Exercises
{
    internal class BasicAlgo
    {
        /*Write a C# Sharp program to compute the sum of the two numerical values. If the two values are the same, return triple their sum.
        Sample Input:
        1, 2
        3, 2
        2, 2
        Expected Output:
        3
        5
        12   */
        public static int ComputeSumWithCondition(int one, int two) =>
                 one == two ? (one + two) * 3 : one + two;
        /*Write a C# Sharp program to get the absolute difference between n and 51. If n is broader than 51 return triple the absolute difference.*/
        public static int GetAbsoluteDifference(int n) =>
            n > 51 ? (n - 51) * 3 : 51 - n;
        /*Write a C# Sharp program to check two given integers, and return true if one of them is 30 or if their sum is 30.

        Sample Input:
        30, 0
        25, 5
        20, 30
        20, 25*/
        public static bool Is30(int one, int two)
                  => one + two == 30 || one == 30 || two == 30;
        /* Write a C# Sharp program to exchange the first and last characters in a given string and return the new string.

        Sample Input:
        "abcd"
        "a"
        "xy"
        Expected Output:
        
        dbca
        a
        yx*/
        public static string ChangeFirstAndLastLetter(string text) =>
         text.Length <= 1 ? text : $"{text[text.Length - 1]}{text.Substring(1, text.Length - 2)}{text[0]}";
        public static string ChangeFirstAndLastLetterSb(string text)
        {
            if (text.Length <= 1) return text;
            var st = new StringBuilder();
            st.Append(text[text.Length - 1]);
            for (int i = 1; i < text.Length - 2; i++)
            {
                st.Append(text[i]);
            }
            st.Append(text[0]);
            return st.ToString();
        }
        //Write a C# Sharp program to create a string which is 4 copies of the 2 front characters of a given string. If the given string length is less than 2 return the original string.
        public static string Get2CharsOfString(string text)
        {
            if (text.Length < 2) return text;

            string front2Chars = text.Substring(0, 2);
            return new StringBuilder().Insert(0, front2Chars, 3).ToString();
        }
        /*The cockroach is one of the fastest insects. Write a function which takes its speed in km per hour and returns it in cm per second, rounded down to the integer (= floored).*/
        public static int CockroachSpeed(double x)
        {
            return (int)Math.Floor((x * 1000) / 36);
        }
    }
}
