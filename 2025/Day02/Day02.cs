using System.Text.RegularExpressions;
using Common;

namespace Solution.Day02
{
    public class Day02 : SolutionBase
    {
        private const string Pattern = "^([1-9]\\d*)-([1-9]\\d*)$";

        public override string SolvePart1(string input)
        {
            var lines = GetCSV(input);
            long totalSum = 0;
            foreach (var line in lines)
            {
                //Console.WriteLine(line);
                var (rangeStart, rangeEnd) = ParseCommand(line);
                Console.WriteLine($"rangeStart: {rangeStart}, rangeEnd: {rangeEnd}");
                if (rangeStart.Length == rangeEnd.Length && rangeStart.Length % 2 == 1 && rangeEnd.Length % 2 == 1)
                {
                    Console.WriteLine("No duplicates can be found in ranges with odd number of digits!");
                    continue;
                }
                var (sumOfIds, numberOfDuplicates) = FindNumberOfDuplicateIds(rangeStart, rangeEnd);
                Console.WriteLine($"Number of duplicates in range {rangeStart}-{rangeEnd}: {numberOfDuplicates}");
                totalSum += sumOfIds;
                Console.WriteLine();
            }
            return totalSum.ToString();

        }

        public override string SolvePart2(string input)
        {
            var lines = GetLines(input);
            var testString = "2121";
            Console.WriteLine($"Split: {testString.Split("21").Length}");

            return "";
        }

        public static (string, string) ParseCommand(string idRange)
        {
            //Console.WriteLine(dialCommand);
            var match = Regex.Match(idRange, Pattern);
            if (!match.Success)
            {
                throw new ArgumentException("Invalid id range!");
            }
            //Console.WriteLine($"Range start: {match.Groups[1].Value}, Range end: {match.Groups[2].Value}");


            var rangeStart = match.Groups[1].Value;
            var rangeEnd = match.Groups[2].Value;
            return (rangeStart, rangeEnd);
        }

        public static (long, long) FindNumberOfDuplicateIds(string rangeStart, string rangeEnd)
        {
            var currentId = long.Parse(rangeStart);
            var parsedRangeEnd = long.Parse(rangeEnd);
            var numberOfDuplicates = 0;
            long sumOfIds = 0;
            var potentialIdHalf = FindFirstEvenLengthId(rangeStart, rangeEnd);
            while (currentId < parsedRangeEnd)
            {
                var duplicateId = long.Parse($"{potentialIdHalf}{potentialIdHalf}");
                if (duplicateId > parsedRangeEnd || duplicateId < currentId)
                {
                    break;
                }
                numberOfDuplicates++;
                sumOfIds += duplicateId;
                potentialIdHalf++;

                currentId = duplicateId;
            }
            return (sumOfIds, numberOfDuplicates);
        }

        private static long FindFirstEvenLengthId(string rangeStart, string rangeEnd)
        {
            if (rangeStart.Length % 2 == 1)
            {
                var firstEvenLengthNumber = Math.Pow(10, rangeStart.Length).ToString();
                rangeStart = firstEvenLengthNumber;
            }

            var splitIndex = rangeStart.Length / 2;
            var splitId = long.Parse(rangeStart.Substring(0, splitIndex));
            var secondSplitId = long.Parse(rangeStart.Substring(splitIndex));

            if (splitId < secondSplitId)
            {
                splitId++;
            }
            return splitId;
        }
    }
}
