using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Code_Exercises
{
    internal class RegexExercises
    {
        /*1. Write a C# Sharp program to check whether a given string is a valid Hex code or not. Return true if this string is a valid code otherwise false.
        Sample Data:
        ("#CD5C5C") -> True
        ("#f08080") -> True
        ("#E9967A") -> True
        ("#EFFA07A") -> False
        */
        public static bool IsHexCode(string hexCode) =>
               Regex.IsMatch(hexCode, @"[#][0-9A-Fa-f]{6}\b");
        

    }
}
