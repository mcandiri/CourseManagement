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
        /// 
        public static (char character, int count) FindMostFrequentCharacter(string input)
        {
            if (string.IsNullOrEmpty(input))
                return ('\0', 0); // Eğer input boş veya null ise, '\0' ve 0 döner. '\0' 

            // LINQ metotları kullanılarak kısa yoldan sonuca gidebiliriz.
            var charFrequency = input.GroupBy(c => c) // GroupBy metodu input stringindeki her bir karakteri gruplayarak aynı karakterler bir araya getirilir.
                                    .Select(g => new { Character = g.Key, Count = g.Count() }) // bi önceki adımda gruplanan karakterler ve bu karakterden kaç adet olduğu alınır.
                                    .OrderByDescending(g => g.Count) // karakterleri, sayılarına göre çoktan aza olacak şekilde sırala işlemi yapılır.
                                    .ThenBy(g => input.IndexOf(g.Character)) // ThenBy ile ikinci sıralama ölçütü belirlenir ve IndexOf ile de karakterin ilk göründüğü indekse göre sıralama yapılması sağlanır.
                                    .FirstOrDefault(); // ilk geçerli eleman döndürülür, boşsa hata fırlatır.
                                    //.First(); eğer boşsa null döner

            //return (charFrequency.Character, charFrequency.Count); // null güvenliği yok
            return (charFrequency?.Character ?? '\0', charFrequency?.Count ?? 0); // null güvenliği sağlanmıştır, charFrequency null ise '\0' ve 0 döndürülür.
        }
    }

}
