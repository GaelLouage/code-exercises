﻿using System;
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
    }
}
