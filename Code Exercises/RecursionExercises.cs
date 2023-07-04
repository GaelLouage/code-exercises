using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Exercises
{
    internal class RecursionExercises
    {
        /* Write a program in C# Sharp to print the first n natural numbers using recursion.
        Test Data :
        How many numbers to print : 10
        Expected Output :
        1 2 3 4 5 6 7 8 9 10*/
        public static void FirstNaturalNumbers(int n)
        {
            if (n == 1)
            {
                Console.Write(n);
            }
            else
            {
                FirstNaturalNumbers(n - 1);
                Console.Write(" " + n);
            }
        }
    }
}
