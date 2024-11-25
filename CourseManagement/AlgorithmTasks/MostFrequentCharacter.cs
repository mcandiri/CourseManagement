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
            // TODO: Implement logic to find the most frequent character.
            // - Use a dictionary to count occurrences of each character.
            // - Identify the character with the maximum frequency.
            // - If there is a tie, choose the character that is alphabetically smallest.
            return (default(char), 0);
        }
    }

}
