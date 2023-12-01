namespace AdventOfCode2023
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("\n\t --- Code of Advent 2023 --- ");
            var p1 = new Program();
            p1.Day01(false);
            p1.Day01(true);
            Console.ReadKey();
        }

        private void Day01(bool part2)
        {
            var lines = File.ReadAllLines("..\\..\\..\\input.txt");
            var candidates = new List<(string key, int value)> { ("1", 1), ("2", 2), ("3", 3), ("4", 4), ("5", 5), ("6", 6), ("7", 7), ("8", 8), ("9", 9), ("0", 0), };
            if (part2)
            {
                candidates.AddRange(new List<(string, int)> { ("one", 1), ("two", 2), ("three", 3), ("four", 4), ("five", 5), ("six", 6), ("seven", 7), ("eight", 8), ("nine", 9) });
            }

            var nums = new List<int>();

            foreach (var line in lines)
            {
                // this gets every number, into an array/collection, and index is -1 when not found and index of place found when found
                // then we do a where to only get ones where it is found
                // then we get first and last

                int firstDigit = candidates.Select(candidate => new { Index = line.IndexOf(candidate.key), Value = candidate.value }).Where(x => x.Index >= 0).OrderBy(x => x.Index).First().Value;
                int lastDigit = candidates.Select(candidate => new { Index = line.LastIndexOf(candidate.key), Value = candidate.value }).Where(x => x.Index >= 0).OrderBy(x => x.Index).Last().Value;
                var finalNumber = int.Parse(firstDigit.ToString() + lastDigit.ToString());
                // Console.WriteLine("Line: " + line + "\n\t First Digit: " + firstDigit + "\t Last Digit: " + lastDigit);
                nums.Add(finalNumber);
            }

            var sum = nums.Sum();

            Console.WriteLine("\nDay 01 - " + (part2 ? "Part 2:" : "Part 1:"));
            Console.WriteLine("Sum of digits: " + sum);
        }
    }
}
