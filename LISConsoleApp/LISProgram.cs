using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace LISConsoleApp
{
    public class LISProgram
    {
        public static List<int> ConvertStrToIntList(string inputStr)
        {

            List<string> strList = inputStr.Split(' ').ToList();
            List<int> outputIntegerList = strList.Select(int.Parse).ToList();
            return outputIntegerList;
        }

        public static string ConvertIntListToStr(List<int> inputList)
        {
            // conver the list to str but in reverse order
            var outStr = inputList.Select(i => i.ToString(CultureInfo.InvariantCulture))
                .Aggregate((s1, s2) => s2 + " " + s1);

            return outStr;
        }
        public static int GetCorrectPosition(List<int> outList, int n)
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
                    if (!outDictionary.ContainsKey(inputIntegerList[i]))
                    {
                        // if next > current
                        if (inputIntegerList[i] > outputIntegerList.Last())
                        {
                            outputIntegerList.Add(inputIntegerList[i]);
                            outDictionary.Add(inputIntegerList[i], outputIntegerList[outputIntegerList.Count - 2]);
                        }
                        else
                        {
                            // if number already exist, ignore it

                            int correctPosition = GetCorrectPosition(outputIntegerList, inputIntegerList[i]);
                            outputIntegerList[correctPosition] = inputIntegerList[i];
                            if (correctPosition > 0)
                                outDictionary.Add(inputIntegerList[i], outputIntegerList[correctPosition - 1]);
                            else
                                outDictionary.Add(inputIntegerList[i], -991);
                        }
                    }

                }

            }

            int last = outputIntegerList.Last();
            List<int> finalList = new List<int>();
            while (last != -991)
            {
                finalList.Add(last);
                last = outDictionary[last];
            }
            return ConvertIntListToStr(finalList);
        }


        static void Main(string[] args)
        {
            string inputStr = "6 1 5 9 2";
            CalculateLongestSubsequence(inputStr);
            Console.WriteLine("Longest increasing subsequnce is {0}", CalculateLongestSubsequence(inputStr));
            Console.ReadLine();
        }
    }
}
