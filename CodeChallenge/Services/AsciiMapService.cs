using CodeChallenge.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using static CodeChallenge.Helpers.Utils;
using static CodeChallenge.Helpers.Enums;

namespace CodeChallenge.Services
{
    public static class AsciiMapService
    {
        public static MapResult ProcessUploadedFile(HttpPostedFileBase file)
        {
            var fileContent = GetStringFromFile(file);
            var linesArray = GetLinesArrrayFromString(fileContent);

            return ResolveMap(linesArray);
        }

        private static string GetStringFromFile(HttpPostedFileBase file)
        {
            BinaryReader b = new BinaryReader(file.InputStream);
            byte[] binData = b.ReadBytes(file.ContentLength);

            return Encoding.UTF8.GetString(binData);
        }

        private static char[][] GetLinesArrrayFromString(string content)
        {
            string[] lines = content.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            return lines.Select(item => item.ToArray()).ToArray();
        }

        private static MapResult ResolveMap(char[][] charsArray)
        {
            CharLocation currLoc;
            CharLocation prevLoc;
            StringBuilder path = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            List<CharLocation> previousLocations = new List<CharLocation>();

            currLoc = DetermineInitialPosition(charsArray);

            if (currLoc == null)
            {
                return null;
            }

            Direction direction = DetermineDirection(charsArray, currLoc);

            path.Append(currLoc.Character);

            while (currLoc.Character != END_CHAR && direction != Direction.None)
            {
                prevLoc = CopyLocation(currLoc);

                currLoc = NextLocation(direction, currLoc, charsArray);

                path.Append(currLoc.Character);
                previousLocations.Add(CopyLocation(currLoc));

                if (currLoc.Character == CROSS_CHAR)
                {
                    direction = DetermineDirection(charsArray, currLoc, prevLoc);
                }
                else if (IsCapitalLetter(currLoc.Character))
                {
                    if (previousLocations.Count(item => item.X == currLoc.X && item.Y == currLoc.Y) < 2)
                    {
                        letters.Append(currLoc.Character);
                    }

                    direction = DetermineDirection(charsArray, currLoc, prevLoc);
                }
            }

            return new MapResult { Letters =letters.ToString(), PathChars = path.ToString() };
        }        
    }
}