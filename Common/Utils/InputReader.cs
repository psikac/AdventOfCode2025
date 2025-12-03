using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils
{
    public static class InputReader
    {
        public static string ReadInput(int day)
        {
            var path = Path.Combine("2025",$"Day{day:D2}", "input.txt");
            return File.ReadAllText(path).Trim();
        }

        public static string ReadExample(int day)
        {
            var path = Path.Combine("2025",$"Day{day:D2}", "example.txt");
            return File.ReadAllText(path).Trim();
        }
    }
}
