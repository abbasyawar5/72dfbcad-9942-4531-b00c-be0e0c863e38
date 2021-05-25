using LISConsoleApp;
using System;
using Xunit;

namespace LISTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string inputStr = "6 2 4 6 1 5 9 2";
            Assert.Equal(3, LISProgram.longestSubsequence(inputStr));
        }
    }
}
