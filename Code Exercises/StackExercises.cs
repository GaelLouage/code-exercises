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
        public static Stack<T> OrderedByDescendingStack<T>(Stack<T> values) => new Stack<T>(values.ToList().OrderByDescending(x => x));

        public static Stack<T> OrderedStack<T>(Stack<T> values) => new Stack<T>(values.ToList().OrderBy(x => x));
        //Write a C# program to find the minimum element in a stack.
        public static int FindMinimumInStack(Stack<int> myStack)
        {
            //// Initialize min with the top element of the stack
            int min = myStack.Peek();
            foreach (var num in myStack)
            {
                if (min > num)
                {
                    min = num;
                }
            }
            return min;
        }
        public static int FindMinimumInStackLinq(Stack<int> myStack) =>
        myStack.OrderBy(x => x).FirstOrDefault();
        //Write a C# program to count all the elements in a given stack.
        public static Stack<T> RemoveElementFromGivenPosition<T>(Stack<T> st, dynamic val)
        {
            var stC = new Stack<T>();
            while (st.Count() > 0)
            {
                var c = st.Pop();
                if (c != val)
                {
                    stC.Push(c);
                }
            }
            return stC;

        }
        //Write a C# program to remove all the elements from a given stack.
        public static void RemoveElementsFromStack<T>(Stack<T> st)
        {
            st.Clear();
        }
        //Write a C# program to count all the elements in a given stack.
        public static int CountElementsInStack<T>(Stack<T> st)
        {
            return st.Count();
        }
        //Write a C# program to count specified element in a given stack.
        public static int CountSpecifiedElementsInStack(Stack<int> st, int element)
        {
            int count = 0;
            foreach (var item in st)
            {
                if (item == element) count++;
            }
            return count;
        }
        /*Write a C# program to implement a stack that checks if a given element is present or not in the stack.*/
        public static bool StackContainsElement<T>(Stack<T> elements, T obj)
        {
            foreach (var element in elements.ToList())
            {
                if (EqualityComparer<T>.Default.Equals(element, obj)) return true;
            }
            return false;
        }
        public static bool StackContainsElementLinq<T>(Stack<T> elements, T obj) =>
                 elements.Any(x => EqualityComparer<T>.Default.Equals(x, obj));
    }
}
