using CodeChallenge.Models;
using System;
using static CodeChallenge.Helpers.Enums;

namespace CodeChallenge.Helpers
{
    public static class Utils
    {
        public const char START_CHAR = '@';
        public const char END_CHAR = 'x';
        public const char CROSS_CHAR = '+';

        public static CharLocation DetermineInitialPosition(char[][] chars)
        {
            CharLocation startPosition = new CharLocation();

            for (int i = 0; i < chars.Length; i++)
            {
                for (int j = 0; j < chars[i].Length; j++)
                {
                    if (chars[i][j] == START_CHAR)
                    {
                        startPosition.X = j;
                        startPosition.Y = i;
                        startPosition.Character = START_CHAR;

                        return startPosition;
                    }
                }
            }
            return null;
        }

        public static Direction DetermineDirection(char[][] charsArray, CharLocation currLoc, CharLocation prevLoc = null)
        {
            var xAdd1 = new CharLocation() { X = currLoc.X + 1, Y = currLoc.Y };
            var xSub1 = new CharLocation() { X = currLoc.X - 1, Y = currLoc.Y };
            var yAdd1 = new CharLocation() { X = currLoc.X, Y = currLoc.Y + 1 };
            var ySub1 = new CharLocation() { X = currLoc.X, Y = currLoc.Y - 1 };
            var newDirection = Direction.None;
            int directionsCount = 0;

            if (prevLoc == null)
            {
                prevLoc = currLoc;
            }

            //Up
            if (LocationValid(charsArray, ySub1.Y, ySub1.X) && charsArray[ySub1.Y][ySub1.X] != ' ' && !AreSameCoordinates(prevLoc, ySub1))
            {
                newDirection = Direction.Up;
                directionsCount++;
            }

            //Down
            if (LocationValid(charsArray, yAdd1.Y, yAdd1.X) && charsArray[yAdd1.Y][yAdd1.X] != ' ' && !AreSameCoordinates(prevLoc, yAdd1))
            {
                newDirection = Direction.Down;
                directionsCount++;
            }

            //Right
            if (LocationValid(charsArray, xAdd1.Y, xAdd1.X) && charsArray[xAdd1.Y][xAdd1.X] != ' ' && !AreSameCoordinates(prevLoc, xAdd1))
            {
                newDirection = Direction.Right;
                directionsCount++;
            }

            //Left
            if (LocationValid(charsArray, xSub1.Y, xSub1.X) && charsArray[xSub1.Y][xSub1.X] != ' ' && !AreSameCoordinates(prevLoc, xSub1))
            {
                newDirection = Direction.Left;
                directionsCount++;
            }

            //Last
            if (directionsCount > 1)
            {
                return currLoc.Direction;
            }

            currLoc.Direction = newDirection;

            return newDirection;
        }

        public static CharLocation NextLocation(Direction direction, CharLocation currLocation, char[][] charsArray)
        {
            switch (direction)
            {
                case Direction.Right:
                    currLocation.X += 1;
                    break;
                case Direction.Left:
                    currLocation.X -= 1;
                    break;
                case Direction.Down:
                    currLocation.Y += 1;
                    break;
                case Direction.Up:
                    currLocation.Y -= 1;
                    break;
            }

            currLocation.Character = charsArray[currLocation.Y][currLocation.X];

            return currLocation;
        }

        public static CharLocation CopyLocation(CharLocation currLocation)
        {
            return new CharLocation() { X = currLocation.X, Y = currLocation.Y, Character = currLocation.Character, Direction = currLocation.Direction };
        }

        public static bool LocationValid(char[][] charsArray, int y, int x)
        {
            try
            {
                char value = charsArray[y][x];
            }

            catch (IndexOutOfRangeException)
            {
                return false;
            }

            return true;
        }

        public static bool AreSameCoordinates(CharLocation a, CharLocation b)
        {
            return (a.Y == b.Y && a.X == b.X);
        }

        public static bool IsCapitalLetter(char c)
        {
            return (c >= 'A' && c <= 'Z');
        }
    }
}