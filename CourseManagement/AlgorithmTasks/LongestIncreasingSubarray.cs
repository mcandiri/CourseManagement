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

            //Checks if the list is null or empty.
            if (numbers == null || numbers.Count == 0)
            {
                return new List<int>();
            }

            //A substring and a long substring are created.
            List<int> subarray = new();
            List<int> longSubarray = new();

            //The variable to which we give the number at the index in the foreach loop.
            int previousNumber = 0;

            //We created a loop inside the list.
            foreach (var number in numbers)
            {
                //We check if the incoming number is greater than the previous number.
                if (number > previousNumber)
                {
                    subarray.Add(number);
                }
                else
                {
                    //If the increase stops, we check if the current list is larger than the long list.
                    if (subarray.Count > longSubarray.Count)
                    {
                        longSubarray = new List<int>(subarray);
                    }
                    //If subarray is not greater than longSubarray, we delete the subarray list.
                    //We add the new number
                    subarray.Clear();
                    subarray.Add(number);
                }
                //The number is added as the old number.
                previousNumber = number;

            }

            //After the loop we check if the remaining subarray is greater than longSubarray.
            if (subarray.Count > longSubarray.Count)
            {
                longSubarray = new List<int>(subarray);
            }
            return longSubarray;
        }
    }
}
