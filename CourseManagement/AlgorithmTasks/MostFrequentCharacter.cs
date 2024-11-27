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
            // If input is null or empty, return a default value.
            if (string.IsNullOrEmpty(input))
            {
                // If input is null or empty, return a default value.
                return (default(char), 0);
            }

            //We separate the input value into chars.
            List<char> charList = input.ToList();

            //Here we could have done this job using a loop, but I wanted to solve the problem by grouping.
            //Grouping and sorting is done with GroupBy.
            var groupedResult = charList
                .GroupBy(c => c) 
                .Select(g => new { Char = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count) 
                .ThenBy(x => x.Char)
                .FirstOrDefault(); 

            if (groupedResult != null)
            {
                return (groupedResult.Char, groupedResult.Count);
            }

            return (default(char), 0);

        }

    }
}
