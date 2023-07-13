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

        /*
         Matching Phone Numbers
         Write a regular expression pattern to match phone numbers in the following format:
         
         The phone number should consist of 10 digits.
         The first digit cannot be zero.
         The phone number can be in any format, including hyphens, spaces, or parentheses, as long as it consists of exactly 10 digits.
         Your task is to write a regex pattern that matches phone numbers based on the above criteria.
         
         Example matches:
         
         1234567890
         (123) 456-7890
         123 456 7890
         Example non-matches:
         
         12345 (too few digits)
         0123456789 (first digit is zero)
         (123)-456-7890 (extra characters)
         In this pattern:

        ^ asserts the start of the string.
        [1-9] matches any digit from 1 to 9, ensuring that the first digit is not zero.
        [0-9]{9} matches any 9 digits from 0 to 9.
        $ asserts the end of the string.*/
        public static bool IsMatchingPhoneNumer(string phoneNumber) => Regex.IsMatch(phoneNumber, @"^[1-9][0-9]{9}$");

        /*Write a regular expression pattern in C# that matches strings containing only lowercase letters and numbers (0-9), with a length between 3 and 6 characters.*/
        /*The regular expression pattern ^[a-z0-9]{3,6}$ matches strings that:

        Begin with the start of the line (^).
        Consist of lowercase letters and numbers (0-9) only ([a-z0-9]).
        Have a length between 3 and 6 characters ({3,6}).
        End with the end of the line ($).*/
        public static bool CheckIfStringLowerCaseAndNumberWithRegex(string input)
        {
            return Regex.IsMatch(input, "^[a-z0-9]{3,6}$");
        }

    }
}
