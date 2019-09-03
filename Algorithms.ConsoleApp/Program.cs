using Algorithms.LevenshteinDistance;
using System;

namespace Algorithms.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string originalWord = "polite";
            string correctedWord = "p0l1t3";

            var results = StringDistance.Distance(originalWord, correctedWord);

            foreach (var mistake in results.Mistakes)
            {
                Console.WriteLine(mistake.ToString());
            }
            Console.WriteLine($"Total distance: {results.Distance}");
            Console.ReadKey();
        }
    }
}
