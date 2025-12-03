using Common;

namespace Solution.Day01
{
    public class Day02 : SolutionBase
    {
        public override string SolvePart1(string input)
        {
            return "";
            var lines = GetLines(input);
            var dial = new Dial();
            foreach (var line in lines)
            {
                var (direction, value) = Dial.ParseCommand(line);
                dial.MoveDial(direction, value);
            }

            return dial.NumberOfZeroes.ToString();
        }

        public override string SolvePart2(string input)
        {
            var lines = GetLines(input);
            var dial = new Dial();
            foreach (var line in lines)
            {
                var (direction, value) = Dial.ParseCommand(line);
                dial.MoveDialPart2(direction, value);
            }

            return dial.NumberOfZeroes.ToString();
        }
    }
}
