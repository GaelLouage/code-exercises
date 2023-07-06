using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Exercises
{
    internal class StackExercises
    {
        //Write a C# program to implement a stack with push and pop operations.
        public static void StackPopPush()
        {
            var stackPopPush = new Stack<char>();
            stackPopPush.Push('s');
            stackPopPush.Push('t');
            stackPopPush.Push('a');
            stackPopPush.Push('c');
            stackPopPush.Push('k');
            //Returns the item at the top of the stack without removing it.
            var peek = stackPopPush.Peek();
            Console.WriteLine($"peek: {peek}");
            // removes the last element of the array and store it
            var pop = stackPopPush.Pop();
            Console.WriteLine($"pop: {pop}");
            foreach (var item in stackPopPush)
            {
                Console.WriteLine(item);
            }
        }

        /*Write a C# program to sort the elements of a given stack in descending order.*/
        public static Stack<T> OrderedStack<T>(Stack<T> values) => new Stack<T>(values.ToList().OrderByDescending(x => x));

    }
}
