namespace CourseManagement.AlgorithmTasks
{
    public static class MostFrequentCharacter
    {
        public static (char character, int count) FindMostFrequentCharacter(string input)
        {
            if (string.IsNullOrEmpty(input))
                return (default(char), 0);

            var counts = new Dictionary<char, int>();

            foreach (var c in input)
            {
                if (counts.ContainsKey(c))
                    counts[c]++;
                else
                    counts[c] = 1;
            }

            char mostFrequent = input[0];
            int maxCount = 0;

            foreach (var c in counts)
            {
                if (c.Value > maxCount || (c.Value == maxCount && c.Key < mostFrequent))
                {
                    mostFrequent = c.Key;
                    maxCount = c.Value;
                }
            }

            return (mostFrequent, maxCount);
        }
    }
}
