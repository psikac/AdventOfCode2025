using System.Text.RegularExpressions;

namespace Solution.Day01
{
    public class Dial
    {
        private const string Left = "L";
        private const string Pattern = "(L|R)(\\d+)";
        private const int MinDialValue = 0;
        private const int MaxDialValue = 100;
        public int DialPointer { get; private set; } = 50;
        public int NumberOfZeroes { get; set; } = 0;

        public void MoveDial(int direction, int value)
        {
            var fullRotations = value / MaxDialValue;

            var restOfRotation = value % MaxDialValue;
            var newPosition = DialPointer + (direction * restOfRotation);

            if (newPosition < MinDialValue)
            {
                DialPointer = newPosition + MaxDialValue;
            }
            else if (newPosition > MaxDialValue)
            {
                DialPointer = newPosition - MaxDialValue;
            }
            else { DialPointer = newPosition; }


            if (DialPointer == 0)
            {
                NumberOfZeroes++;
            }
            Console.WriteLine($"DialPointer: {DialPointer}");
            Console.WriteLine();
        }

        public void MoveDialPart2(int direction, int value)
        {
            Console.WriteLine($"Value: {value}");
            var fullRotations = value / MaxDialValue;
            NumberOfZeroes += fullRotations;
            Console.WriteLine($"Full rotations: {fullRotations}");


            var restOfRotation = value % MaxDialValue;

            if (fullRotations != 0 && restOfRotation == 0)
            {
                NumberOfZeroes++;
                Console.WriteLine($"Right at zero, number of zeroes: {NumberOfZeroes}");
                Console.WriteLine($"DialPointer: {DialPointer}");
                Console.WriteLine();
                return;
            }

            Console.WriteLine($"restOfRotation: {restOfRotation}");
            var newPosition = DialPointer + (direction * restOfRotation);
            if (newPosition < MinDialValue)
            {
                if (DialPointer != 0)
                {
                    NumberOfZeroes++;
                }
                DialPointer = newPosition + MaxDialValue;
                Console.WriteLine($"Going left, number of zeroes: {NumberOfZeroes}");
                if (DialPointer == 0)
                {
                    return;
                }
            }
            else if (newPosition >= MaxDialValue)
            {
                if (DialPointer != 0)
                {
                    NumberOfZeroes++;
                }
                DialPointer = newPosition - MaxDialValue;
                Console.WriteLine($"Going right, number of zeroes: {NumberOfZeroes}");
                if (DialPointer == 0)
                {
                    return;
                }
            }
            else
            {
                DialPointer = newPosition;

            }


            if (DialPointer == 0)
            {
                NumberOfZeroes++;
                Console.WriteLine($"Right at zero, number of zeroes: {NumberOfZeroes}");
            }
            Console.WriteLine($"DialPointer: {DialPointer}");
            Console.WriteLine();
        }


        public static (int, int) ParseCommand(string dialCommand)
        {
            //Console.WriteLine(dialCommand);
            var match = Regex.Match(dialCommand, Pattern);
            if (!match.Success)
            {
                throw new ArgumentException("Invalid dial command!");
            }
            Console.WriteLine($"Direction: {match.Groups[1].Value}, Value: {match.Groups[2].Value}");


            var direction = GetDirection(match.Groups[1].Value);
            var directionValue = int.Parse(match.Groups[2].Value);
            return (direction, directionValue);
        }

        private static int GetDirection(string direction)
        {
            if (direction == Left) { return -1; } else { return 1; }
        }
    }
}
