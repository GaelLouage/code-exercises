using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Exercises
{
    internal class LinqExrcises
    {
        /*Write a program in C# Sharp to show how the three parts of a query operation execute.
        Expected Output:
        The numbers which produce the remainder 0 after divided by 2 are :
        0 2 4 6 8*/
        public static IEnumerable<int> GetNumbersWithRemainder0(IEnumerable<int> numbers) =>
        numbers.Where(x => x % 2 == 0);

        // find numbers in range
        public static List<int> NumbersInRange(List<int> numbers, int rangeStart, int rangeEnd) =>
              numbers.Where(x => x >= rangeStart && x <= rangeEnd).ToList();

        /*Write a program in C# Sharp to find the number of an array and the square of each number.
        Expected Output :
        { Number = 9, SqrNo = 81 }
        { Number = 8, SqrNo = 64 }
        { Number = 6, SqrNo = 36 }
        { Number = 5, SqrNo = 25 }
        */
        public static IEnumerable SquareNumbers(int[] array) =>
             array.Select(x => new { Number = x, SqrNo = Math.Pow(x, 2) }).ToArray();
    }
}
