using Common;
using Common.Utils;
using System.Reflection;

namespace Runner;

public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: Runner [example]");
            Console.WriteLine("Example: Runner 2025 1");
            Console.WriteLine("Example: Runner 2025 1 example");
            return;
        }

        var year = int.Parse(args[0]);
        var day = int.Parse(args[1]);
        var useExample = args.Length > 2 && args[2] == "example";

        try
        {
            var assembly = Assembly.Load($"_{year}");
            var typeName = $"_{year}.Day{day:D2}.Day{day:D2}";
            var type = assembly.GetType(typeName);

            if (type == null)
            {
                Console.WriteLine($"Could not find solution for Year {year}, Day {day}");
                return;
            }

            var solution = (ISolution)Activator.CreateInstance(type)!;
            var input = useExample ? InputReader.ReadExample(year, day) : InputReader.ReadInput(year, day);

            Console.WriteLine($"=== Advent of Code {year} - Day {day} ===");
            Console.WriteLine($"Using {(useExample ? "example" : "actual")} input\n");

            var part1 = solution.SolvePart1(input);
            Console.WriteLine($"Part 1: {part1}");

            var part2 = solution.SolvePart2(input);
            Console.WriteLine($"Part 2: {part2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}