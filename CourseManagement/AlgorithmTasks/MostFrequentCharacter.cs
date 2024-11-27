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
        /// Output: ('c', 2)   //burda output olarak ('a', 2 ) olarak vermesi lazim 
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

            if (string.IsNullOrEmpty(input))                            //girdinin boş olup olmadıgını kontrol ediyoruz
                return (default(char), 0);                              //boş ise default karakter ile 0 değerlerini döndürüyoruz

            var frequencyMap = new Dictionary<char, int>();             //verilen kelimelerdeki harfleri tutmak için key olarak char tipinde karakteri , value olarak da int tipinde tekrar sayısını tutuyoruz

            foreach (var ch in input)                                   //kelimelerin uzunluğu değişebileceğinden dolayı foreach ile kelimenin harflerini gezmeye başlıyorum
            {
                if (frequencyMap.ContainsKey(ch))                       //eğer oluşturduğumuz sözlükte bu harf varsa 
                    frequencyMap[ch]++;                                //value yani key değerini 1 arttırıyoruz
                else
                    frequencyMap[ch] = 1;                              //böyle bir harfe denk gelmediyse değerini 1 olarak set ediyoruz
            }

            char mostFrequent = default(char);                          //en çok tekrar eden karakteri tutmak için bir nesne oluşturdum
            int maxFrequency = 0;                                       //tekrar değerini tutmak için bir nesne oluşturdum 

            foreach (var kvp in frequencyMap)                           
            {
                if (kvp.Value > maxFrequency || (kvp.Value == maxFrequency && kvp.Key < mostFrequent)) //kvp(key value pair) 
                    /*bır karakterin frekansı mevcut maksimum frekanstan büyükse 
                     * ve alfabetik olarak daha küçükse , o karakterin en sık tekrar eden olarak seçilmesi gerekir*/
                {
                    mostFrequent = kvp.Key;
                    maxFrequency = kvp.Value;
                }
            }

            return (mostFrequent, maxFrequency);
        }
    }

}
