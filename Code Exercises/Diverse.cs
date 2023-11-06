using Code_Exercises.Cl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Code_Exercises
{
    internal class Diverse
    {
        public static string AlphabetPosition(string text)
        {
            var positions = new StringBuilder();
            string alfa = "abcdefghijklmnopqrstuvwxyz";
            foreach (var c in text.ToLower())
            {
                if (alfa.Contains(c.ToString()))
                {
                    positions.Append(alfa.IndexOf(c) + 1 + " ");
                }

            }
            return positions.ToString().Trim();
        }
        public static string AlphabetPositionLinq(string text) =>
            string.Join(" ", text.ToLower().Where(c => char.IsLetter(c)).Select(x => "abcdefghijklmnopqrstuvwxyz".IndexOf(x) + 1).ToArray());
        public static int Persistence(long n)
        {
            int result = 0;
            long tempNumber = n;

            if (tempNumber.ToString().Length == 1)
                return 0;

            while (tempNumber.ToString().Length > 1)
            {
                string tempNumberAsString = tempNumber.ToString();
                int product = 1;

                for (int i = 0; i < tempNumberAsString.Length; i++)
                {
                    product *= (int)char.GetNumericValue(tempNumberAsString[i]);
                }

                result++;
                tempNumber = product;
            }

            return result;
        }

        public static int NthSmallest(int[][] arr, int n)
        {
            List<int> arrTemp = new List<int> { };
            foreach (int[] array in arr)
            {
                foreach (int value in array)
                {
                    arrTemp.Add(value);
                }
            }
            arrTemp.Sort();
            return arrTemp[n - 1];
        }
        public static int NthSmallestLinq(int[][] arr, int n) => arr.SelectMany(x => x).OrderBy(x => x).Skip(n - 1).First();
        public static string High(string s)
        {
            var alfaHigh = new List<int>();
            int points = 1;
            var alfa = "abcdefghijklmnopqrstuvwxyz";
            var splittedString = s.Split(" ");
            foreach (var c in splittedString)
            {
                foreach (char ch in c)
                {
                    points += alfa.IndexOf(ch) + 1;
                }
                alfaHigh.Add(points);
                points = 0;
            }
            int max = alfaHigh[0];
            int index = 0;
            for (int i = 0; i < alfaHigh.Count; i++)
            {
                if (max < alfaHigh[i])
                {
                    max = alfaHigh[i];
                    index = i;
                }
            }
            return splittedString[index];
        }
        public static int[] MoveZeroes(int[] arr)
        {
            // TODO: Program me
            var nulls = new List<int>();
            var nonNulls = new List<int>();
            var newArray = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    nulls.Add(arr[i]);
                }
                else
                {
                    nonNulls.Add(arr[i]);
                }
            }
            newArray.AddRange(nonNulls);
            newArray.AddRange(nulls);
            return newArray.ToArray();
        }
        public static int[] MoveZeroesLinq(int[] arr) =>
         arr.OrderBy(x => x == 0).ToArray();
        //The main idea is to count all the occurring characters in a string. If you have a string
        //like aba, then the result should be {'a': 2, 'b': 1}.
        public static Dictionary<char, int> CountLinq(string str) =>
            str.GroupBy(x => x).ToDictionary(c => c.Key, c => c.Count());
        public static Dictionary<char, int> Count(string str)
        {
            var dictionary = new Dictionary<char, int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (dictionary.ContainsKey(str[i]))
                {
                    dictionary[str[i]] += 1;
                }
                else
                {
                    dictionary.Add(str[i], 1);
                }
            }
            return dictionary;
        }
        public static string Rot13(string message)
        {
            // your code here
            string alfa = "abcdefghijklmnopqrstuvwxyz";
            var rot13 = new StringBuilder();
            foreach (var c in message)
            {
                if (char.IsUpper(c))
                {
                    var tempLower = c.ToString().ToLower();
                    var setUpper = "";
                    if (alfa.IndexOf(tempLower) + 13 > 25)
                    {
                        setUpper = alfa[alfa.IndexOf(tempLower) + 13 - 26].ToString().ToUpper();
                        rot13.Append(setUpper);
                    }
                    else
                    {
                        setUpper = alfa[alfa.IndexOf(tempLower) + 13].ToString().ToUpper();
                        rot13.Append(setUpper);
                    }
                    setUpper = "";
                }

                if (alfa.Contains(c))
                {
                    if (alfa.IndexOf(c) + 13 > 25)
                    {
                        rot13.Append(alfa[alfa.IndexOf(c) + 13 - 26]);
                    }
                    else
                    {
                        rot13.Append(alfa[alfa.IndexOf(c) + 13]);
                    }
                }
                else if (!char.IsUpper(c))
                {
                    rot13.Append(c);
                }
            }
            return rot13.ToString();
        }
        /*John has invited some friends. His list is:

        s = "Fred:Corwill;Wilfred:Corwill;Barney:Tornbull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
        Could you make a program that
        
        makes this string uppercase
        gives it sorted in alphabetical order by last name.
        When the last names are the same, sort them by first name. Last name and first name of a guest come in the result between parentheses separated by a comma.
        
        So the result of function meeting(s) will be:*/
        public static string Meeting(string s)
        {
            // your code
            var splitted = s.Split(";");
            var persons = new List<string>();
            foreach (var name in splitted)
            {
                var sp = name.Split(":");
                persons.Add($"({sp[1].ToUpper()}, {sp[0].ToUpper()})");

            }
            return string.Join("", persons.OrderBy(x => x));
        }

        public static string MeetingLinq(string s) =>
    string.Join("", s.Split(";").Select(x => new { Name = $"({x.Split(":")[1].ToUpper()}, {x.Split(":")[0].ToUpper()})" }).OrderBy(x => x.Name).Select(x => x.Name));

        public static int[] ArrayDiff(int[] a, int[] b)
        {
            // Your brilliant solution goes here
            // It's possible to pass random tests in about a second ;)
            var arrayDiff = a.ToList();
            for (int i = 0; i < b.Length; i++)
            {
                arrayDiff.RemoveAll(x => x == b[i]);
            }
            return arrayDiff.ToArray();
        }

        public static int[] ArrayDiffLinq(int[] a, int[] b) =>
        a.Where(x => !b.Contains(x)).ToArray();
        /* create N×N multiplication table, of size provided in parameter.
        For example, when given size is 3:
        1 2 3
        2 4 6
        3 6 9
        */
        public static int[,] MultiplicationTable(int size)
        {
            int[,] arrMulti = new int[size, size];
            for (int i = 0; i < arrMulti.GetLength(0); i++)
            {
                for (int j = 0; j < arrMulti.GetLength(1); j++)
                {
                    arrMulti[i, j] = (i + 1) * (j + 1);
                }

            }
            return arrMulti;
        }
        public static bool XOString(string input)
        {
            int o = 0;
            int x = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].ToString().ToLower() == "o")
                {
                    o++;
                }
                else if (input[i].ToString().ToLower() == "x")
                {
                    x++;
                }
            }
            return o == x;
        }
        public static bool XODictionary(string input)
        {
            if (string.IsNullOrEmpty(input)) return true;
            var dictionaryXO = new Dictionary<char, int>();
            foreach (var c in input)
            {
                var cToLower = Convert.ToChar(c.ToString().ToLower());
                if (dictionaryXO.ContainsKey(c))
                {
                    dictionaryXO[cToLower]++;
                }
                else
                {
                    dictionaryXO.Add(cToLower, 1);
                }
            }
            return dictionaryXO.ContainsKey('o') && dictionaryXO.ContainsKey('x') && dictionaryXO['o'] == dictionaryXO['x'];//Code it!
        }
        /*Check to see if a string has the same amount of 'x's and 'o's. The method must return a boolean and be case insensitive. The string can contain any char.

        Examples input/output:
        
        XO("ooxx") => true
        XO("xooxx") => false
        XO("ooxXm") => true
        XO("zpzpzpp") => true // when no 'x' and 'o' is present should return true
        XO("zzoo") => false*/
        public static bool XOLinq(string input) =>
                input.Count(x => x.ToString().ToLower() == "x") == input.Count(x => x.ToString().ToLower() == "o");
        public static int SquareSumLinq(int[] numbers) =>
                numbers.Sum(x => x * x);
        public static int SquareSum(int[] numbers)
        {
            var sum = 0;
            foreach (var num in numbers)
            {
                sum += num * num; // Math.Pow(num,2) - math lib; 
            }
            return sum;
        }
        public static int StringToNumber(string str)
        {
            if (int.TryParse(str, out int val))
            {
                return val;
            }
            return 0;
        }
        public static int StringToNumberLinq(string str) =>
             str.All(x => char.IsNumber(x) || (char.IsNumber(x) || x == '-')) ? int.Parse(str) : 0;
        /*There is a bus moving in the city which takes and drops some people at each bus stop.
        
        You are provided with a list (or array) of integer pairs. Elements of each pair represent the number of people that get on the bus (the first item) and the number of people that get off the bus (the second item) at a bus stop.
        
        Your task is to return the number of people who are still on the bus after the last bus stop (after the last array). Even though it is the last bus stop, the bus might not be empty and some people might still be inside the bus, they are probably sleeping there :D
        
        Take a look on the test cases.
        
        Please keep in mind that the test cases ensure that the number of people in the bus is always >= 0. So the returned integer can't be negative.
        
        The second value in the first pair in the array is 0, since the bus is empty in the first bus stop.
        
        */
        public static int Number(List<int[]> peopleListInOut)
        {
            var onTheBus = 0;
            for (int i = 0; i < peopleListInOut.Count; i++)
            {

                for (int j = 0; j < peopleListInOut[i].Length - 1; j++)
                {
                    onTheBus += peopleListInOut[i][j] - peopleListInOut[i][j + 1];
                }

            }
            return onTheBus;
        }
        public static int NumberLinq(List<int[]> peopleListInOut) =>
              peopleListInOut.SelectMany(x => x).Where((c, i) => i % 2 == 0).Sum() -
              peopleListInOut.SelectMany(x => x).Where((c, i) => i % 2 != 0).Sum();
        public static int NumberLinqShort(List<int[]> peopleListInOut) => peopleListInOut.Sum(x => x[0] - x[1]);
        public static string AbbrevName(string name) =>
                 $"{name[0]}.{name[name.IndexOf(" ") + 1]}".ToUpper();
        //create a function that takes a list of non-negative integers and strings and returns a new list with the strings filtered out.
        public static IEnumerable<int> GetIntegersFromList(List<object> listOfItems)
            => listOfItems.OfType<int>();

        /*return the sum of all of the positives ones.
        Example[1, -4, 7, 12] => 1 + 7 + 12 = 20 */
        public static int PositiveSum(int[] arr) =>
            arr.Where(x => x > 0).Sum();


        /*make a function that can take any non-negative integer as an argument and return it with its digits in descending order. Essentially, rearrange the digits to create the highest possible number.
        
        Examples:
        Input: 42145 Output: 54421
        
        Input: 145263 Output: 654321
        
        Input: 123456789 Output: 987654321*/
        public static int DescendingOrder(int num) =>
             int.Parse(string.Concat(num.ToString().OrderByDescending(x => x)));

        /*Given a year, return the century it is in.
       Examples
       1705 --> 18
       1900 --> 19
       1601 --> 17
       2000 --> 20*/
        public static int СenturyFromYear(int year) =>
                year % 100 == 0 ? year / 100 : year / 100 + 1;

        //public static string CreatePhoneNumber(int[] numbers)
        //{
        //    var numbersToString = string.Concat(Array.ConvertAll(numbers, x => x.ToString()));
        //    return $"({numbersToString.Substring(0, 3)}) {numbersToString.Substring(3, 3)}-{numbersToString.Substring(6, 4)}";
        //}
        public static string CreatePhoneNumberStringFormat(int[] numbers) =>
              long.Parse(string.Concat(numbers)).ToString("(000) 000-0000");

        // return negative number
        public static int MakeNegative(int number) =>
                    number < 0 ? number : number * -1;

        public static string DisemvowelLinq(string str) =>
            string.Concat(str.Where(x => !"aeiouAEIOU".ToArray().Contains(x)));
        public static string Disemvowel(string str)
        {
            var vowels = "aeiouAEIOU".ToArray();
            var sb = new StringBuilder();
            foreach (var c in str)
            {
                if (!vowels.Contains(c))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        /*Your classmates asked you to copy some paperwork for them. You know that there are 'n' classmates and the paperwork has 'm' pages.
        Your task is to calculate how many blank pages do you need. If n < 0 or m < 0 return 0.*/
        public static int Paperwork(int n, int m) =>
           n < 0 || m < 0 ? 0 : n * m;


        /*Task:
        Given a list of integers, determine whether the sum of its elements is odd or even.

        Give your answer as a string matching "odd" or "even".

        If the input array is empty consider it as: [0] (array with a zero).*/
        public static string OddOrEven(int[] array) =>
             array.Sum() % 2 == 0 ? "even" : "odd";

        /*An isogram is a word that has no repeating letters, consecutive or non-consecutive. Implement a function that determines whether a string that contains only letters is an isogram. Assume the empty string is an isogram. Ignore letter case.
        Example: (Input --> Output)
        "Dermatoglyphics" --> true "aba" --> false "moOse" --> false (ignore letter case)*/
        public static bool IsIsogramLinq(string str) => str.ToLower().Distinct().Count() == str.Length;
        public static bool IsIsogram(string str)
        {
            var letters = new Dictionary<int, int>();
            foreach (var c in str.ToLower())
            {
                if (letters.ContainsKey(c))
                {
                    return false;
                }
                else
                {
                    letters.Add(c, 1);
                }
            }
            return true;
        }

        /*Convert number to reversed array of digits
        Given a random non-negative number, you have to return the digits of this number within an array in reverse order.
        
        Example(Input => Output):
        35231 => [1,3,2,5,3]
        0 => [0]*/
        public static long[] Digitize(long n) =>
        n.ToString().Reverse().Select(x => (long)char.GetNumericValue(x)).ToArray();

        /*This time no story, no theory. The examples below show you how to write function accum:
        Examples:
        accum("abcd") -> "A-Bb-Ccc-Dddd"
        accum("RqaEzty") -> "R-Qq-Aaa-Eeee-Zzzzz-Tttttt-Yyyyyyy"
        accum("cwAt") -> "C-Ww-Aaa-Tttt"
        The parameter of accum is a string which includes only letters from a..z and A..Z.*/
        public static string Accum(string s)
        {
            var stringLengt = 0;
            var sb = new StringBuilder();
            foreach (var c in s)
            {
                for (int i = 0; i <= stringLengt; i++)
                {
                    if (i == 0)
                    {
                        sb.Append(c.ToString().ToUpper());
                    }
                    else
                    {
                        sb.Append(c.ToString().ToLower());
                    }
                    if (i == stringLengt && stringLengt < s.Length - 1)
                    {
                        sb.Append("-");
                    }
                }
                stringLengt++;
            }

            return sb.ToString();
        }
        public static string AccumLinq(string s) =>
             string.Join("-", s.Select((c, i) => char.ToUpper(c) + new string(char.ToLower(c), i)));
        /*Complete the solution so that it returns true if the first argument(string) passed in ends with the 2nd argument (also a string).
        
        Examples:
        
        solution('abc', 'bc') // returns true
        solution('abc', 'd') // returns false*/
        public static bool StringEndsWith(string str, string ending) =>
              str.Length >= ending.Length && str.Substring(str.Length - ending.Length, ending.Length) == ending;

        public static bool StringEndsWithLinq(string str, string ending) =>
                str.EndsWith(ending);

        /*Complete the method which returns the number which is most frequent in the given input array. If there is a tie for most frequent number, return the largest number among them.

        Note: no empty arrays will be given.
        
        Examples
        [12, 10, 8, 12, 7, 6, 4, 10, 12]              -->  12
        [12, 10, 8, 12, 7, 6, 4, 10, 12, 10]          -->  12
        [12, 10, 8, 8, 3, 3, 3, 3, 2, 4, 10, 12, 10]  -->   3*/
        public static int HighestRank(int[] arr)
        {

            var highestCount = new List<int>();
            var maxValue = 0;

            var dictionaryArr = new Dictionary<int, int>();
            foreach (var num in arr)
            {
                if (dictionaryArr.ContainsKey(num))
                {
                    dictionaryArr[num]++;
                    if (maxValue < dictionaryArr[num])
                    {
                        maxValue = dictionaryArr[num];
                    }
                }
                else
                {
                    dictionaryArr.Add(num, 1);
                }
            }

            foreach (var item in dictionaryArr)
            {
                if (maxValue == item.Value)
                {
                    highestCount.Add(item.Key);
                }
            }
            return highestCount.Count == 0 ? dictionaryArr.ToList().Max(x => x.Key) : highestCount.Max();
        }
        public static int HighestRankLinq(int[] arr) =>
                          arr.GroupBy(x => x)
                         .OrderByDescending(x => x.Count())
                         .ThenByDescending(x => x.Key)
                         .Select(x => x.Key)
                         .First();

        /*Implement a function that adds two numbers together and returns their sum in binary. The conversion can be done before, or after the addition.
        
        The binary number returned should be a string.
        
        Examples:(Input1, Input2 --> Output (explanation)))
        
        1, 1 --> "10" (1 + 1 = 2 in decimal or 10 in binary)
        5, 9 --> "1110" (5 + 9 = 14 in decimal or 1110 in binary)*/
        public static string AddBinary(int a, int b) => Convert.ToString(a + b, 2);
        /*Calc bmi*/
        public static string Bmi(double weight, double height)
        {
            var bmi = weight / (height * height);
            if (bmi <= 18.5)
            {
                return "Underweight";
            }
            else if (bmi <= 25.0)
            {
                return "Normal";
            }
            else if (bmi <= 30.0)
            {
                return "Overweight";
            }
            else
            {
                return "Obese";
            }
        }

        /*Given an array of integers, find the one that appears an odd number of times.

        There will always be only one integer that appears an odd number of times.
        
        Examples
        [7] should return 7, because it occurs 1 time (which is odd).
        [0] should return 0, because it occurs 1 time (which is odd).
        [1,1,2] should return 2, because it occurs 1 time (which is odd).
        [0,1,0,1,0] should return 0, because it occurs 3 times (which is odd).
        [1,2,2,3,3,3,4,3,3,3,2,2,1] should return 4, because it appears 1 time (which is odd).
        
        */
        public static int FindItLinq(int[] seq)
        {
            return seq.GroupBy(x => x).First(k => k.Count() % 2 != 0).Key;
        }
        public static int FindIt(int[] seq)
        {
            var numsD = new Dictionary<int, int>();

            foreach (var num in seq)
            {
                if (numsD.ContainsKey(num))
                {
                    numsD[num]++;
                }
                else
                {
                    numsD.Add(num, 1);
                }
            }
            foreach (var k in numsD)
            {
                if (k.Value % 2 != 0)
                {
                    return k.Key;
                }
            }
            return -1;
        }

        /*Consider an array/list of sheep where some sheep may be missing from their place. We need a function that counts the number of sheep present in the array (true means present).*/
        public static int CountSheeps(bool[] sheeps) =>
                                sheeps.Count(x => x);

        /*In this little assignment you are given a string of space separated numbers, and have to return the highest and lowest number.
        
        Examples
        Kata.HighAndLow("1 2 3 4 5");  // return "5 1"
        Kata.HighAndLow("1 2 -3 4 5"); // return "5 -3"
        Kata.HighAndLow("1 9 3 4 -5"); // return "9 -5"*/
        public static string HighAndLow(string numbers)
        {
            var min = 9999999999;
            var max = -9999999999;
            foreach (var num in numbers.Split(' '))
            {
                var n = Convert.ToInt32(num);
                if (min > n) min = (int)n;
                if (max < n) max = (int)n;
            }
            return $"{max} {min}";
        }
        public static string HighAndLowLinq(string numbers) =>
            $"{numbers.Split(' ').Max(int.Parse)} {numbers.Split(' ').Min(int.Parse)}";
        /*Deoxyribonucleic acid, DNA is the primary information storage molecule in biological systems. It is composed of four nucleic acid bases Guanine ('G'), Cytosine ('C'), Adenine ('A'), and Thymine ('T').

        Ribonucleic acid, RNA, is the primary messenger molecule in cells. RNA differs slightly from DNA its chemical structure and contains no Thymine. In RNA Thymine is replaced by another nucleic acid Uracil ('U').
        
        Create a function which translates a given DNA string into RNA.
        
        For example:
        
        "GCAT"  =>  "GCAU"
        The input string can be of arbitrary length - in particular, it may be empty. All input is guaranteed to be valid, i.e. each input string will only ever consist of 'G', 'C', 'A' and/or 'T'.*/
        public string dnaToRna(string dna) =>
                 dna.Replace("T", "U");

        public static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(n));

            for (int i = 3; i <= boundary; i += 2)
                if (n % i == 0)
                    return false;

            return true;
        }
        public static string ToJadenCase(this string phrase) =>
                string.Join(" ", phrase.Split(' ').Select(w =>
                {
                    if (string.IsNullOrEmpty(w))
                        return w;
                    return char.ToUpper(w[0]) + w.Substring(1);
                }));


        public static string EvenOrOdd(int number)
        {
            return number % 2 == 0 ? "Even" : "Odd";
        }
        /*Sentence Smash
        Write a function that takes an array of
        words and smashes them together into a sentence and returns the sentence. You can ignore any need to sanitize words or add punctuation, but you should add spaces between each word. Be careful, there shouldn't be a space at the beginning or the end of the sentence!*/
        public static string Smash(string[] words)
        {
            // Smash words
            return string.Join(" ", words);
        }
        /*Given an array of integers your solution should find the smallest integer.

        For example:
        
        Given [34, 15, 88, 2] your solution will return 2
        Given [34, -345, -1, 100] your solution will return -345*/
        public static int FindSmallestInt(int[] args)
        {

            if (args.Length <= 0) return 0;
            int min = args[0];
            foreach (var num in args)
            {
                if (min > num)
                {
                    min = num;
                }
            }
            return min;
        }
        public static int FindSmallestIntLinq(int[] args) => args.Min();


        public static int GetVowelCount(string str)
        {
            var vowels = "aeiou";
            var count = 0;
            foreach (var c in str)
            {
                if (vowels.Contains(c))
                {
                    count++;
                }
            }
            return count;
        }
        public static int GetVowelCountLinq(string str) =>
                 str.ToLower().Count(i => "aeiou".Contains(i));
        /*If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
        Finish the solution so that it returns the sum of all the multiples of 3 or 5 below the number passed in. Additionally,
        if the number is negative, return 0 (for languages that do have them).
        Note: If the number is a multiple of both 3 and 5, only count it once.*/
        public static int DivisbleBy3And5(int value)
        {
            // Magic Happens
            int sum = 0;
            for (int i = 0; i < value; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }
        public static int DivisbleBy3And5Linq(int value) =>
                Enumerable.Range(0, value).Where(i => i % 3 == 0 || i % 5 == 0).Sum();
        /*Given an array of integers of any length, return an array that has 1 added to the value represented by the array.
        
        the array can't be empty
        only non-negative, single digit integers are allowed
        Return nil (or your language's equivalent) for invalid inputs.
        
        Examples
        Valid arrays
        
        [4, 3, 2, 5] would return [4, 3, 2, 6]
        [1, 2, 3, 9] would return [1, 2, 4, 0]
        [9, 9, 9, 9] would return [1, 0, 0, 0, 0]
        [0, 1, 3, 7] would return [0, 1, 3, 8]
        
        Invalid arrays
        
        [1, -9] is invalid because -9 is not a non-negative integer
        
        [1, 2, 33] is invalid because 33 is not a single-digit intege*/
        public static int[] UpArray(int[] num)
        {
            if (num.Length <= 0 || num.Any(x => x > 9 || x < 0)) return null;
            var numberToBigInteger = (BigInteger.Parse(string.Join("", num)) + 1).ToString();
            var numbersIntoArray = numberToBigInteger.Select(x => (int)char.GetNumericValue(x)).ToList();
            if (num[0] == 0)
            {
                numbersIntoArray.Insert(0, 0);
            }
            return numbersIntoArray.ToArray();
        }

        public static void FizzBuzz()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }
        public static int Factorial(int a)
        {
            if (a <= 1)
            {
                return a;
            }
            return a * Factorial(a - 1);
        }
        public static int[] GenerateFibonacci(int n)
        {
            var fiboList = new int[n];
            int one = 0;
            int two = 1;
            int fibo = 0;
            for (int i = 0; i < n; i++)
            {
                fiboList[i] = fibo;
                one = two;
                two = fibo;
                fibo = one + two;
            }
            return fiboList;
        }
        public static bool IsPalindrome(string str)
        {
            var charsToLower = string.Concat(str.Where(x => char.IsLetter(x))).ToLower();
            return charsToLower == string.Concat(charsToLower.Reverse());
        }
        public static bool AreAnagrams(string str1, string str2)
        {
            return string.Concat(str1.OrderBy(x => x)) == string.Concat(str2.OrderBy(x => x));
        }
        public static bool IsPrimeLoop(int num)
        {
            int counter = 0;
            for (int i = 1; i <= num; i++)
            {
                if (num % i == 0) counter++;
            }
            return counter == 2;
        }
        public static int SumOfPrimesInRange(int a, int b)
        {
            int sum = 0;
            for (int i = a; i < b; i++)
            {
                if (IsPrime(i))
                {
                    sum += i;
                }
            }
            return sum;
        }
        public static string ReverseString(string str)
        {
            // Your code here 
            return string.Concat(str.Reverse());
        }
        public static (int vowels, int consonants) CountVowelsAndConsonants(string str)
        {
            return (str.Count(x => "aeiouAEIOU".Contains(x)), str.Count(x => !"aeiouAEIOU".Contains(x)));
        }
        public static string LongestWord(string sentence)
        {
            // Your code here
            var sentences = sentence.Split(" ");
            var maxWord = sentences.FirstOrDefault();
            for (int i = 0; i < sentences.Length; i++)
            {
                if (maxWord.Length < sentences[i].Length)
                {
                    maxWord = sentences[i];
                }
            }
            return maxWord;
        }
        public static string LongestWordLinq(string sentence)
        {
            return sentence.Split(" ").OrderByDescending(x => x.Length).ToList().FirstOrDefault();
        }
        public static string ToTitleCase(string input)
        {
            input = input.ToLower();
            var sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (i == 0 || input[i - 1] == ' ')
                {
                    sb.Append(input[i].ToString().ToUpper());
                }
                else
                {
                    sb.Append(input[i]);
                }
            }

            return sb.ToString();
        }
        /*It's pretty straightforward. Your goal is to create a 
         * function that removes the first and last characters of a string. You're given one parameter, 
         * the original string. You don't have to worry with strings with less than two characters.*/
        public static string Remove_char(string s)
        {
            // Your Code
            return s.Substring(1, s.Length - 2);
        }

        public static string MeetingClass(string s)
        {
            var persons = s.Split(";").Select(x => new Person() { FirstName = x.Split(":")[0].ToUpper(), LastName = x.Split(":")[1].ToUpper() })
              .OrderBy(x => x.LastName)
              .ThenBy(x => x.FirstName);
            return string.Concat(persons);
        }
        public static int FindEvenIndex(int[] arr)
        {
            int totalSum = 0;
            int leftSum = 0;

            foreach (int num in arr)
            {
                totalSum += num;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                totalSum -= arr[i];
                if (leftSum == totalSum)
                {
                    return i;
                }
                leftSum += arr[i];
            }

            return -1;
        }
        /*Examples
        Valid arrays
        a = [121, 144, 19, 161, 19, 144, 19, 11]  
        b = [121, 14641, 20736, 361, 25921, 361, 20736, 361]
        comp(a, b) returns true because in b 121 is the square of 11, 14641 is the square of 121, 20736 the square of 144, 361 the square of 19, 25921 the square of 161, and so on. It gets obvious if we write b's elements in terms of squares:
        
        a = [121, 144, 19, 161, 19, 144, 19, 11] 
        b = [11*11, 121*121, 144*144, 19*19, 161*161, 19*19, 144*144, 19*19]
        Invalid arrays
        If, for example, we change the first number to something else, comp is not returning true anymore:
        
        a = [121, 144, 19, 161, 19, 144, 19, 11]  
        b = [132, 14641, 20736, 361, 25921, 361, 20736, 361]
        comp(a,b) returns false because in b 132 is not the square of any number of a.
        
        a = [121, 144, 19, 161, 19, 144, 19, 11]  
        b = [121, 14641, 20736, 36100, 25921, 361, 20736, 361]
        comp(a,b) returns false because in b 36100 is not the square of any number of a.
        
        Remarks
        a or b might be [] or {} (all languages except R, Shell).
        a or b might be nil or null or None or nothing (except in C++, COBOL, Crystal, D, Dart, Elixir, Fortran, F#, Haskell, Nim, OCaml, Pascal, Perl, PowerShell, Prolog, PureScript, R, Racket, Rust, Shell, Swift).
        If a or b are nil (or null or None, depending on the language), the problem doesn't make sense so return false.
        
        Note for C
        The two arrays have the same size (> 0) given as parameter in function comp.*/
        public static bool comp(int[] a, int[] b)
        {
            if ((a is null || b is null) || (a.Length != b.Length)) return false;
            var aList = a.ToList();

            foreach (var num in b)
            {
                if (!aList.Contains((int)Math.Sqrt(num)))
                {
                    return false;
                }
                else
                {
                    aList.Remove((int)Math.Sqrt(num));
                }
            }
            return true;
        }
        /*Complete the function, which calculates how much you need to tip based on the total amount of the bill and the service.
       
       You need to consider the following ratings:
       
       Terrible: tip 0%
       Poor: tip 5%
       Good: tip 10%
       Great: tip 15%
       Excellent: tip 20%
       The rating is case insensitive (so "great" = "GREAT"). If an unrecognised rating is received, then you need to return:
       
       "Rating not recognised" in Javascript, Python and Ruby...
       ...or null in Java
       ...or -1 in C#
       Because you're a nice person, you always round up the tip, regardless of the service.*/
        public static int CalculateTip(double amount, string rating)
        {
            var ratingLower = rating.ToLower();
            var tipsDictionary = new Dictionary<string, int>()
                                {
                                  {"terrible",0},
                                  {"poor",5},
                                  {"good",10},
                                  {"great",15},
                                  {"excellent",20},
                                };
            if (tipsDictionary.ContainsKey(ratingLower))
            {
                return (int)(Math.Ceiling(amount * tipsDictionary[ratingLower] / 100));
            }
            return -1;
        }
        public static string Encrypt(string text, int n)
        {
            if (string.IsNullOrEmpty(text) || n <= 0)
            {
                return text;
            }

            for (int i = 0; i < n; i++)
            {
                var sbEven = new StringBuilder();
                var sbOdd = new StringBuilder();

                for (int j = 0; j < text.Length; j++)
                {
                    if (j % 2 == 0)
                    {
                        sbEven.Append(text[j]);
                    }
                    else
                    {
                        sbOdd.Append(text[j]);
                    }
                }

                text = sbOdd.ToString() + sbEven.ToString();
            }

            return text;
        }
        /*Implement a pseudo-encryption algorithm which given a string S and an integer N concatenates all the odd-indexed characters of S with all the even-indexed characters of S, this process should be repeated N times.
        
        Examples:
        
        encrypt("012345", 1)  =>  "135024"
        encrypt("012345", 2)  =>  "135024"  ->  "304152"
        encrypt("012345", 3)  =>  "135024"  ->  "304152"  ->  "012345"
        
        encrypt("01234", 1)  =>  "13024"
        encrypt("01234", 2)  =>  "13024"  ->  "32104"
        encrypt("01234", 3)  =>  "13024"  ->  "32104"  ->  "20314"
        Together with the encryption function, you should also implement a decryption function which reverses the process.
        
        If the string S is an empty value or the integer N is not positive, return the first argument without changes.*/
        public static string Decrypt(string encryptedText, int n)
        {
            if (string.IsNullOrEmpty(encryptedText) || n <= 0)
            {
                return encryptedText;
            }

            int length = encryptedText.Length;
            int halfLength = length / 2;

            for (int i = 0; i < n; i++)
            {
                var sb = new StringBuilder();

                for (int j = 0; j < halfLength; j++)
                {
                    sb.Append(encryptedText[j + halfLength]);
                    sb.Append(encryptedText[j]);
                }

                if (length % 2 != 0)
                {
                    sb.Append(encryptedText[length - 1]);
                }

                encryptedText = sb.ToString();
            }

            return encryptedText;
        }
        /*You probably know the "like" system from Facebook and other pages. People can "like" blog posts, pictures or other items. We want to create the text that should be displayed next to such an item.
        
        Implement the function which takes an array containing the names of people that like an item. It must return the display text as shown in the examples:
        
        []                                -->  "no one likes this"
        ["Peter"]                         -->  "Peter likes this"
        ["Jacob", "Alex"]                 -->  "Jacob and Alex like this"
        ["Max", "John", "Mark"]           -->  "Max, John and Mark like this"
        ["Alex", "Jacob", "Mark", "Max"]  -->  "Alex, Jacob and 2 others like this"
        Note: For 4 or more names, the number in "and 2 others" simply increases.*/
        public static string Likes(string[] name)
        => name.Length switch
        {
            0 => "no one likes this",
            1 => $"{name[0]} likes this",
            2 => $"{name[0]} and {name[1]} like this",
            3 => $"{name[0]}, {name[1]} and {name[2]} like this",
            _ => $"{name[0]}, {name[1]} and {name.Length - 2} others like this"
        };

        //Complete the solution so that it splits the string into pairs of two characters.
        //If the string contains an odd number of characters then it should replace the missing second character of the final pair with an underscore ('_').
        public string[] Solution(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return new string[0];
            }

            var arr = new List<string>();
            for (int i = 0; i < str.Length; i++)
            {
                if (str.Length % 2 != 0 && i == str.Length - 1)
                {
                    arr.Add($"{str[i]}_");
                }
                else
                {
                    arr.Add($"{str[i]}{str[i + 1]}");
                    i++;
                }
            }
            return arr.ToArray();
        }

        public static int[] TwoSum(int[] numbers, int target)
        {
            // O(n^2)
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] + numbers[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[0];
        }

        public static int[] ArrayDiff2(int[] a, int[] b)
        {
            var result = new List<int>();
            result.AddRange(a);
            foreach (var num in b)
            {
                if (result.Contains(num))
                {
                    result.RemoveAll(x => x == num);
                }
            }
            return result.ToArray();
        }
        /*Complete the method/function so that it converts dash/underscore delimited words into camel casing. The first word within the output should be capitalized only if the original word was capitalized (known as Upper Camel Case, also often referred to as Pascal case). The next words should be always capitalized.

        Examples
        "the-stealth-warrior" gets converted to "theStealthWarrior"
        
        "The_Stealth_Warrior" gets converted to "TheStealthWarrior"
        
        "The_Stealth-Warrior" gets converted to "TheStealthWarrior"*/
        public static string ToCamelCase(string str)
        {
            var result = "";
            for (int i = 0; i < str.Length; i++)
            {
                result += str[i];
                if (str[i] == '-' || str[i] == '_')
                {
                    result += str[i + 1].ToString().ToUpper();
                    i++;
                }
            }
            return result.Replace("-", "").Replace("_", "");

        }
        public static string ToCamelCaseLinq(string str) =>
                      string.IsNullOrEmpty(str) ? str :
                      string.Concat(str.Split('-', '_').Select((s, i) => i == 0 ? s : $"{s[0].ToString().ToUpper()}{s.Substring(1)}"));

        /*The main idea is to count all the occurring characters in a string. If you have a string like aba, then the result should be {'a': 2, 'b': 1}.

        What if the string is empty? Then the result should be empty object literal, {}.*/
        public static Dictionary<char, int> CountChars(string str)
        {
            var result = new Dictionary<char, int>();
            foreach (var c in str)
            {
                if (result.ContainsKey(c))
                {
                    result[c]++;
                }
                else
                {
                    result.Add(c, 1);
                }

            }
            return result;
        }
        public static Dictionary<char, int> CountCharsLinq(string str) =>
            str.GroupBy(c => c).ToDictionary(x => x.Key, elem => elem.Count());
        /*Your task, is to create N×N multiplication table, of size provided in parameter.
        
        For example, when given size is 3:
        
        1 2 3
        2 4 6
        3 6 9
        For the given example, the return value should be:
        
        [[1,2,3],[2,4,6],[3,6,9]]*/
        public static int[,] MultiplicationTableV2(int size)
        {
            if (size <= 0) return new int[size, size];
            var result = new int[size, size];
            for (int j = 0; j < result.GetLength(0); j++)
            {
                for (int i = 0; i < result.GetLength(1); i++)
                {
                    result[i, j] = (j + 1) * (i + 1);
                }
            }
            return result;
        }
        /*Complete the solution so that the function will break up camel casing, using a space between words.

        Example
        "camelCasing"  =>  "camel Casing"
        "identifier"   =>  "identifier"
        ""             =>  ""*/
        public static string BreakCamelCase(string str)
        {
            // complete the function
            var result = "";
            foreach (var c in str)
            {
                if (char.IsUpper(c))
                {

                    result += " " + c;
                }
                else
                {
                    result += c;

                }
            }
            return result;
        }
        public static string BreakCamelCaseLinq(string str) =>
   string.Concat(str.Select(x => char.IsUpper(x) ? " " + x : x.ToString()));

        public static string ReverseStringV2(string str)
        {
            return string.Concat(str.Reverse());
        }

        /*In this little assignment you are given a string of space separated numbers, and have to return the highest and lowest number.

                Examples
                Kata.HighAndLow("1 2 3 4 5");  // return "5 1"
                Kata.HighAndLow("1 2 -3 4 5"); // return "5 -3"
                Kata.HighAndLow("1 9 3 4 -5"); // return "9 -5"
                Notes
                All numbers are valid Int32, no need to validate them.
                There will always be at least one number in the input string.
                Output string must be two numbers separated by a single space, and highest number is first.
                */
        public static string HighAndLowV2(string numbers)
        {
            if (string.IsNullOrEmpty(numbers)) return "";
            var min = int.MaxValue;
            var max = int.MinValue;
            var splittedSpace = numbers.Split(" ");
            foreach (var num in splittedSpace)
            {
                if (int.TryParse(num, out int number))
                {
                    if (max < number)
                    {
                        max = number;
                    }
                    if (min > number)
                    {
                        min = number;
                    }
                }
            }
            return $"{max} {min}";
        }
        public static string HighAndLowLinqV2(string numbers)
        {
            var numbersSplitted = numbers.Split(" ").Select(x => int.Parse(x));
            return $"{numbersSplitted.Max()} {numbersSplitted.Min()}";
        }
        public static bool IsIsogramV2(string str)
        {
            // Code on you crazy diamond!
            str = str.ToLower();
            var dictionary = new Dictionary<char, int>();
            foreach (var c in str)
            {
                if (dictionary.ContainsKey(c))
                {
                    dictionary[c]++;
                }
                else
                {
                    dictionary.Add(c, 1);
                }
            }
            return dictionary.All(x => x.Value == 1);

        }
    }
}

