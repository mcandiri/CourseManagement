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
            if (string.IsNullOrEmpty(input))
                return ('\0', 0); // Eğer giriş boşsa, varsayılan bir sonuç döndür.

            var frequencyMap = new Dictionary<char, int>();

            // Her karakterin sıklığını hesapla.
            foreach (char c in input)
            {
                if (frequencyMap.ContainsKey(c))
                    frequencyMap[c]++;
                else
                    frequencyMap[c] = 1;
            }

            // En sık geçen karakteri bul.
            var mostFrequent = frequencyMap
                .OrderByDescending(kv => kv.Value) // Frekansa göre azalan sırala.
                .ThenBy(kv => kv.Key) // Frekans eşitse alfabetik sırala.
                .First();

            return (mostFrequent.Key, mostFrequent.Value);
        }
    }

}
