using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Exercises
{
    internal class StringExercises
    {
        /*count words in string*/
        public static int CountWordsInString(string words) =>
            words.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;

        /*Write a program in C# Sharp to compare two strings without using a string library functions.
        Test Data :
        Input the 1st string : This is first string
        Input the 2nd string : This is first string*/
        public static bool CompareStringWithoutLibrary(string one, string two)
        {
            if (one.Length != two.Length) return false;
            for (int i = 0; i < one.Length; i++)
            {
                if (one[i] != two[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool CompareStringy(string one, string two)
        {
            return String.Compare(one, two) == 0;
        }
        /*Write a program in C# Sharp to count the number of alphabets, digits and special characters in a string.
        Test Data :
        Input the string : Welcome to w3resource.com
        Expected Output :
        
        Number of Alphabets in the string is : 21 
        Number of Digits in the string is : 1 
        */
        public static StringBuilder GetAlfaSpecCharsAndDigits(string text)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Number of Alphabets in the string is : {text.Count(char.IsLetter)}");
            sb.AppendLine($"Number of Digits in the string is : {text.Count(char.IsNumber)}");
            sb.AppendLine($"Number of Alphabets in the string is : {text.Count(x => !char.IsLetterOrDigit(x))}");
            return sb;
        }
        /*Write a C# Sharp program to count the number of vowels or consonants in a string.*/
        public static StringBuilder GetNumberOfConsonantsAndVowels(string text)
        {
            var sb = new StringBuilder();
            sb.Append($"The total number of vowel in the string is: {text.Count(x => "aeiouAEIOU".Contains(x))}");
            sb.AppendLine();
            sb.Append($"The total number of consonant in the string is: {text.Count(x => char.IsLetter(x) && !"aeiouAEIOU".Contains(x))}");
            return sb;
        }
    }
}
