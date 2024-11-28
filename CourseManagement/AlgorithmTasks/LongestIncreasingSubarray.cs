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
		public static List<int> FindLongestIncreasingSubarray(List<int> numbers)
		{
			//null or empty input
			if (numbers == null || numbers.Count == 0)
			{
				return new List<int>();
			}

			
			List<int> longestSubarray = new List<int>();
			List<int> currentSubarray = new List<int> { numbers[0] };

			for (int i = 1; i < numbers.Count; i++)
			{
				// şimdiki numara önceki numaradan büyükse aşama devam eder 
				if (numbers[i] > currentSubarray[currentSubarray.Count - 1])
				{
					currentSubarray.Add(numbers[i]);
				}
				else
				{
					// şimdiki aşama daha uzunsa günceller
					if (currentSubarray.Count > longestSubarray.Count)
					{
						longestSubarray = new List<int>(currentSubarray);
					}

					// yeni süreci başlatmak için şimdikini resetler
					currentSubarray = new List<int> { numbers[i] };
				}
			}

			//en uzun olduğunu doğrulamak için son kontrolü yapar
			if (currentSubarray.Count > longestSubarray.Count)
			{
				longestSubarray = new List<int>(currentSubarray);
			}

			return longestSubarray;
		}
	}
}