using System;
using CodeChallenge.Models;
using CodeChallenge.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeChallenge.Tests.Services
{
    [TestClass]
    public class AsciiMapServiceTest
    {
        [TestMethod]
        public void ResolveMap()
        {
            MapResult expectedResult = new MapResult() { Letters = "BEEFCAKE", PathChars = "@---+B||E--+|E|+--F--+|C|||A--|-----K|||+--E--Ex" };
            char[][] testArray = new char[9][]
            {
                new char[] {' ', ' ', '@', '-', '-', '-', '+'},
                new char[] {' ', ' ', ' ', ' ', ' ', ' ', 'B'},
                new char[] {'K', '-', '-', '-', '-', '-', '|', '-', '-', 'A'},
                new char[] {'|', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', '|'},
                new char[] {'|', ' ', ' ', '+', '-', '-', 'E', ' ', ' ', '|'},
                new char[] {'|', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                new char[] {'+', '-', '-', 'E', '-', '-', 'E', 'x', ' ', 'C'},
                new char[] {' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                new char[] {' ', ' ', ' ', '+', '-', '-', 'F', '-', '-', '+'},
            };

            var result = AsciiMapService.ResolveMap(testArray);

            Assert.AreEqual(expectedResult.Letters, result.Letters);
            Assert.AreEqual(expectedResult.PathChars, result.PathChars);
        }
    }
}
