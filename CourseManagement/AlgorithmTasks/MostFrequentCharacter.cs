namespace CourseManagement.AlgorithmTasks
{
    public static class MostFrequentCharacter
    {
        /// <summary>
        /// Finds the most frequent character in the given string.
        /// If multiple characters have the same frequency, returns the smallest one alphabetically.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>A tuple containing the most frequent character and its frequency.</returns>
        /// <example>
        /// Example 1:
        /// Input: "character"
        /// Output: ('c', 2)
        ///
        /// Example 2:
        /// Input: "mississippi"
        /// Output: ('i', 4)
        /// </example>
        /// <remarks>
        /// If the input string is null or empty, the function will return (default(char), 0).
        /// </remarks>
        public static (char character, int count) FindMostFrequentCharacter(string input)
        {
            if(string.IsNullOrEmpty(input))
            { 
                return (default(char), 0);
            }

            var repetition = new Dictionary<char, int>();

            foreach (var character in input)
            {
                if(repetition.ContainsKey(character))
                {
                    repetition[character]++;
                }
                else
                {
                    repetition[character] = 1;
                }
            }

            char mostRepeatChar = default(char);
            int maxCount = 0;

            foreach (var c in repetition)
            {
                if (c.Value > maxCount || (c.Value == maxCount && c.Key < mostRepeatChar))
                {
                    mostRepeatChar = c.Key;
                    maxCount = c.Value;
                }
            }
            return (mostRepeatChar, maxCount);

        }
    }

}
