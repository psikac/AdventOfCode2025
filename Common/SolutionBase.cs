namespace Common
{
    public abstract class SolutionBase : ISolution
    {
        public abstract string SolvePart1(string input);
        public abstract string SolvePart2(string input);

        protected string[] GetLines(string input) =>
            input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        protected int[] GetIntegers(string input) =>
            [.. GetLines(input).Select(int.Parse)];
    }
}
