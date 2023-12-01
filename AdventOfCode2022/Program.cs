namespace AdventOfCode2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\t --- Code of Advent 2022 --- ");
            var p1 = new Program();
            p1.Day01();
            p1.Day01Alternate();
            Console.ReadKey();
        }

        private void Day01()
        {
            var text = File.ReadAllText("..\\..\\..\\input.txt");
            var splitSections = text.Split("\n\n");
            var calories = new List<int>();

            foreach (var section in splitSections)
            {
                var currentCalorie = 0;
                var individualItem = section.Split("\n");

                foreach (var item in individualItem)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        currentCalorie += int.Parse(item);
                    }
                }

                calories.Add(currentCalorie);
            }

            var top3Sum = calories.OrderDescending().Take(3).Sum();
            Console.WriteLine("\nDay 01 - Part 1 and 2 - Solution 1:");
            Console.WriteLine("Top calorie count: " + calories.Max());
            Console.WriteLine("Top 3 calories sum: " + top3Sum);
        }

        private void Day01Alternate()
        {
            var lines = File.ReadAllLines("..\\..\\..\\input.txt");
            var currentCalorie = 0;
            var calories = new List<int>();

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line)) // we know new section starts here
                {
                    calories.Add(currentCalorie);
                    currentCalorie = 0;
                }
                else
                {
                    currentCalorie += int.Parse(line);
                }
            }

            var top3Sum = calories.OrderDescending().Take(3).Sum();
            Console.WriteLine("\nDay 01 - Part 1 and 2 - Solution 2:");
            Console.WriteLine("Top calorie count: " + calories.Max());
            Console.WriteLine("Top 3 calories sum: " + top3Sum);
        }
    }
}
