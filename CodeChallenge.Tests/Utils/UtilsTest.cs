using System;
using CodeChallenge.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static CodeChallenge.Helpers.Enums;

namespace CodeChallenge.Tests.Utils
{
    [TestClass]
    public class UtilsTest
    {
        [TestMethod]
        public void DetermineInitialPosition()
        {
            CharLocation expectedLocation = new CharLocation() { Character = '@', Direction = Direction.Left, X = 2, Y = 0 };
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

            var result = Helpers.Utils.DetermineInitialPosition(testArray);

            Assert.AreEqual(expectedLocation.Character, result.Character);
            Assert.AreEqual(expectedLocation.Direction, result.Direction);
            Assert.AreEqual(expectedLocation.X, result.X);
            Assert.AreEqual(expectedLocation.Y, result.Y);
        }
    }
}
