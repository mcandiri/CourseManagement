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
            /// Input: "mississippi"
            char mostRepeatsCharacter = '\0';
            int repeatCount = 0;

            if (string.IsNullOrEmpty(input))
                return ('\0', 0);

            Dictionary<char, int> charactersAndRepeats = new Dictionary<char, int>();

            foreach (var ch in input)
            {
                if (charactersAndRepeats.ContainsKey(ch))
                {
                    charactersAndRepeats[ch]++;
                }
                else
                {
                    charactersAndRepeats.Add(ch, 1);
                }
            }

            foreach (var couples in charactersAndRepeats)
            {
                if (couples.Value > repeatCount || (couples.Value == repeatCount && couples.Key < mostRepeatsCharacter))
                {
                    mostRepeatsCharacter = couples.Key;
                    repeatCount = couples.Value;
                }
            }
            return (mostRepeatsCharacter, repeatCount);
        }
    }

}
