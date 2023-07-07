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
    }
}
