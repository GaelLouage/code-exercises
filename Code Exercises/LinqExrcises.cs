using System;
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
    }
}
