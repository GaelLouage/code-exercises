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
    }
}
