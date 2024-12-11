using AdventOfCode.Kit.Client.Models;

namespace AdventOfCode.Puzzles
{
    public class HistorianHysteria : Puzzle
    {
        private const int ExpectedTokenCount = 2;

        private static long ParseLocationId(string token)
        {
            if (!long.TryParse(token, out var locationId))
            {
                throw new ArgumentException("Invalid location ID.");
            }
            return locationId;
        }

        public static (long Left, long Right) ParseLine(string line)
        {
            var tokens = line.Trim().Split().Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();

            if (tokens.Length != ExpectedTokenCount)
            {
                throw new ArgumentException("Invalid input.");
            }

            return (ParseLocationId(tokens[0]), ParseLocationId(tokens[1]));
        }

        private static long CalculateDistance(long left, long right)
        {
            return Math.Abs(left - right);
        }

        public static long CalculateDistanceBetweenLists(string[] lines)
        { 
            var leftQueue = new PriorityQueue<long, long>();
            var rightQueue = new PriorityQueue<long, long>();

            var totalDistance = 0L;

            foreach (var line in lines)
            {
                var (left, right) = ParseLine(line);
                
                leftQueue.Enqueue(left, left);
                rightQueue.Enqueue(right, right);
            }

            while (leftQueue.Count > 0 && rightQueue.Count > 0)
            {
                var left = leftQueue.Dequeue();
                var right = rightQueue.Dequeue();

                totalDistance += CalculateDistance(left, right);
            }

            return totalDistance;
        }

        public static long CalculateSimilarityScore(string[] lines)
        {
            var leftHistory = new List<long>();
            var rightOccurrences = new Dictionary<long, long>();
            var similarityScore = 0L;

            foreach (var line in lines)
            {
                var (left, right) = ParseLine(line);

                if (rightOccurrences.ContainsKey(right))
                {
                    rightOccurrences[right]++;
                }
                else
                {
                    rightOccurrences[right] = 1;
                }

                leftHistory.Add(left);
            }

            foreach (var location in leftHistory)
            {
                if (!rightOccurrences.ContainsKey(location))
                {
                    continue;
                }

                similarityScore += location * rightOccurrences[location];
            }

            return similarityScore;
        }

        public override (Answer First, Answer Second) Run(string[] lines)
        {
            return (
                new Answer
                {
                    Value = CalculateDistanceBetweenLists(lines),
                    Description = "The total distance between the two lists."

                },
                new Answer
                {
                    Value = CalculateSimilarityScore(lines),
                    Description = "The similarity score between the two lists."
                }
            );
        }
    }
}
