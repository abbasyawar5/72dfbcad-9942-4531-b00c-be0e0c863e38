using System;
using System.Collections.Generic;
using System.Linq;

namespace LISConsoleApp
{
    public class LISProgram
    {
        static int max_ref;
        public static int GetlongestSubsequenceLength(List<int> arr, int size)
        {

            if (size == 1)
                return 1;
            int res, max_ending_here = 1;

            for (int i = 1; i < size; i++)
            {
                res = GetlongestSubsequenceLength(arr, i);
                if (arr[i - 1] < arr[size - 1]
                    && res + 1 > max_ending_here)
                    max_ending_here = res + 1;
            }

            if (max_ref < max_ending_here)
                max_ref = max_ending_here;

            return max_ending_here;

        }

        public static int longestSubsequence(string inputStr) {

            List<string> listStrLineElements = inputStr.Split(' ').ToList();
            List<int> listoOfNumbers = new List<int>();
            foreach (string x in listStrLineElements)
            {
                int y = int.Parse(x);
                listoOfNumbers.Add(y);
            }
            return GetlongestSubsequenceLength(listoOfNumbers, listoOfNumbers.Count);

        }
        static void Main(string[] args)
        {
            string input = "6 2 4 6 1 5 9 2";
            Console.WriteLine("Length of longest subsequnce is {0}", longestSubsequence(input)); 
        }
    }
}
