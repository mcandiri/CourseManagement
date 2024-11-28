namespace CourseManagement.AlgorithmTasks
{
    public static class LongestIncreasingSubarray
    {
        /// <summary>
        /// Finds the longest subarray of consecutive increasing numbers in the given list.
        /// The sequence must maintain the original order of the list.
        /// </summary>
        /// <param name="numbers">The input list of integers.</param>
        /// <returns>The longest increasing subarray as a list.</returns>
        /// <example>
        /// Example 1:
        /// Input: [10, 22, 9, 33, 21, 50, 70, 41, 60]
        /// Output: [21, 50, 70]
        ///
        /// Example 2:
        /// Input: [20, 25, 3, 9, 12, 7, 5, 9]
        /// Output: [3, 9, 12]
        /// </example>
        /// <remarks>
        /// If the input list is null or empty, the function will return an empty list.
        /// </remarks>
        /// <note>
        /// The sequence must maintain the original order of the input list.
        /// Only strictly increasing values will be considered part of the subarray.
        /// </note>
        public static List<int> FindLongestIncreasingSubarray(List<int> numbers)
        {        
            var longestSubarray = new List<int>(); // en uzun artan diziyi takip edip saklamak için bir liste tanımlanmıştır.
            int start = 0; //  artan dizinin başlangıç değeri için bir değişken oluşturup indeksini belirtiyoruz.

            for (int i = 1; i < numbers.Count; i++)  // başlangıçta verilen liste elemanlarını sırayla dolaşmak için for döngüsü kullanılmıştır, listenin elaman sayısı "number.Count" ile belirlenmektedir.
            {
                if (numbers[i] > numbers[i - 1]) // listenin i=1 indeksli elemanından başlanarak bir önceki elemanla i-1 kıyas yapılır ve i birer birer artacağı için sırayla devam eder.
                {
                    // En uzun alt diziyi güncelle diziye gelen 
                    if (i - start + 1 > longestSubarray.Count) // ardışık artan alt diziye gelen elemanların sayısı, tespit edilen yeni ardışık artan elemanların sayısından büyük olduğu sürece mevcut liste devam eder ancak tersi durumda ise GetRange ile yeni değerler listeye alınır ve aynı mantık ile devam eder.
                    {
                        longestSubarray = numbers.GetRange(start, i - start + 1);
                        // GetRange metodu, bir liste üzerinde belirli aralıktaki değerleri alır. Listenin start değerindeki indeksinden başlar ve i - start + 1 kadar eleman alır.
                        // "i - start + 1" ifadesi, artan alt dizinin uzunluğunu hesaplamak için kullanılır. + 1, aralıktaki eleman sayısını doğru bir şekilde belirtmek için eklenir.
                        // Örneğin Start=2, i=4 ise elemanlar sırasıyla numbers[2], numbers[3], numbers[4] olacaktır yani aradaki farkın +1 fazlası kadar eleman olacaktır.
                    }
                }
                else
                {
                    // Yeni bir artan alt diziyi başlatmak için başlangıç noktası güncellenir.
                    start = i;
                }
            }
      
            return longestSubarray; 
        

        // TODO: Implement the logic to find the longest increasing subarray.
        // - Use a loop to iterate through the list while keeping track of the current increasing subarray.
        // - When the sequence breaks, compare the current subarray's length to the longest found so far.
        // - If there are multiple subarrays with the same length, return any one of them.
        // - At the end of the loop, return the longest subarray found.
        //return [];

        }

    }
}
