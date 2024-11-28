using System;
using System.Collections.Generic;
using System.Linq;

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
			{
				return (default(char), 0);
			}

			// Karakter tekrarını sayar
			var charFrequency = input
				.GroupBy(c => c)
				.Select(group => new
				{
					Character = group.Key,
					Count = group.Count()
				})
				.ToList();

			// maximum karakter tekrarını sayar
			int maxFrequency = charFrequency.Max(x => x.Count);

			// en çok tekrar eden karakterleri alır
			var mostFrequentChars = charFrequency
				.Where(x => x.Count == maxFrequency)
				.OrderBy(x => x.Character)
				.First();

			// sonuç olarak bulduğumuz karakterleri verir
			return (mostFrequentChars.Character, mostFrequentChars.Count);
		}
	}
}