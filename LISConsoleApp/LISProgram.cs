using System;
using System.Collections.Generic;
using System.Linq;

namespace LISConsoleApp
{
    public class LISProgram
    {
        public static int GetlongestSubsequenceLength(List<int> A)
        {
            int[] dp = new int[A.Count];
            dp[0] = 1;
            for (int i = 1; i < A.Count; i++)
            {
                int max = 1;
                for (int j = 0; j < i; j++)
                {
                    if (A[j] > A[i])
                        max = Math.Max(max, dp[j] + 1);
                }

                dp[i] = max;
            }

            return dp.Max();
        }

        public static int longestSubsequence(string inputStr) {

            List<string> listStrLineElements = inputStr.Split(' ').ToList();
            List<int> listoOfNumbers = new List<int>();
            foreach (string x in listStrLineElements)
            {
                int y = int.Parse(x);
                listoOfNumbers.Add(y);
            }
            return GetlongestSubsequenceLength(listoOfNumbers);

        }
        static void Main(string[] args)
        {
            string input = "6 2 4 6 1 5 9 2";
            Console.WriteLine("Length of longest subsequnce is {0}", longestSubsequence(input)); 
        }
    }
}
