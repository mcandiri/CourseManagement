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
            // TODO: Implement the logic to find the longest increasing subarray.
            // - Use a loop to iterate through the list while keeping track of the current increasing subarray.
            // - When the sequence breaks, compare the current subarray's length to the longest found so far.
            // - If there are multiple subarrays with the same length, return any one of them.
            // - At the end of the loop, return the longest subarray found.
            return [];
        }

    }
}
