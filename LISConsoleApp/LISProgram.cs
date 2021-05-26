using System;
using System.Collections.Generic;
using System.Linq;

namespace LISConsoleApp
{
    public class LISProgram
    {

        public static int GetCorrectPosition (List<int> outList, int n)
        {
            int left = 0, right = outList.Count - 1;
            while (left <= right)
            {
                int middle = (left + right) / 2;

                if (outList[middle] < n)
                    left = middle + 1;
                else
                    right = middle - 1;
            }
            return left;
        }

        public static string CalculateLongestSubsequence(string inputStr)
        {

            //Converting input string to integer list
            List<int> inputIntegerList = ConvertStrToIntList(inputStr);

            //calculating subsequence
            List<int> outputIntegerList = new List<int>();
            Dictionary<int, int> outDictionary = new Dictionary<int, int>();

            for (int i = 0; i < inputIntegerList.Count; i++)
            {
                //base case
                if (outputIntegerList.Count == 0)
                {
                    outputIntegerList.Add(inputIntegerList[i]);
                    outDictionary.Add(inputIntegerList[i], -991);
                }
                else
                {
                    if (inputIntegerList[i] > outputIntegerList.Last())
                    {
                        outputIntegerList.Add(inputIntegerList[i]);
                        outDictionary.Add(inputIntegerList[i], outputIntegerList[outputIntegerList.Count-2]);
                    } else
                    {
                        int correctPosition = GetCorrectPosition(inputIntegerList, inputIntegerList[i]);
                    }

                }

            }


            return null;
        }

        public static List<int> ConvertStrToIntList(string inputStr)
        {

            List<string> strList = inputStr.Split(' ').ToList();
            List<int> outputIntegerList = strList.Select(int.Parse).ToList();
            return outputIntegerList;
        }
        static void Main(string[] args)
        {
            string inputStr = "6 2 4 6 1 5 9 2";

            CalculateLongestSubsequence(inputStr);

            //Console.WriteLine("Length of longest subsequnce is {0}", longestSubsequence(input)); 
        }
    }
}
