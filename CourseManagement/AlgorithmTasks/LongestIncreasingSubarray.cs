namespace CourseManagement.AlgorithmTasks
{


public static class LongestIncreasingSubarray
    {
        public static List<int> FindLongestIncreasingSubarray(List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
                return new List<int>();

            List<int> longestSubarray = new List<int>();
            List<int> currentSubarray = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (currentSubarray.Count == 0 || numbers[i] > numbers[i - 1])
                {
                    currentSubarray.Add(numbers[i]);
                }
                else
                {
                    if (currentSubarray.Count > longestSubarray.Count)
                    {
                        longestSubarray = new List<int>(currentSubarray);
                    }
                    currentSubarray.Clear();
                    currentSubarray.Add(numbers[i]);
                }
            }

            if (currentSubarray.Count > longestSubarray.Count)
            {
                longestSubarray = new List<int>(currentSubarray);
            }

            return longestSubarray;
        }
    public static void Main(string[] args)
{
    var numbers = new List<int> { 10, 22, 9, 33, 21, 50, 70, 41, 60 };
    var result = LongestIncreasingSubarray.FindLongestIncreasingSubarray(numbers);

    Console.WriteLine("Longest Increasing Subarray: " + string.Join(", ", result));
}
    }
}
