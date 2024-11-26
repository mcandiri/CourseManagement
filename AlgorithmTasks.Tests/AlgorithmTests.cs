using Xunit; 
using AlgorithmTasks; 
using System.Collections.Generic;
using CourseManagement.AlgorithmTasks;

namespace AlgorithmTasks.Tests
{
    /// <summary>
    /// Tests for AlgorithmTasks, including LongestIncreasingSubarray and MostFrequentCharacter.
    /// </summary>
    public class AlgorithmTests
    {
        /// <summary>
        /// Test case for finding the longest increasing subarray in a valid list.
        /// </summary>
        [Fact]
        public void FindLongestIncreasingSubarray_WhenListIsValid_ShouldReturnLongestSubarray()
        {
            // Arrange
            var numbers = new List<int> { 10, 22, 9, 33, 21, 50, 70, 41, 60 };

            // Act
            var result = LongestIncreasingSubarray.FindLongestIncreasingSubarray(numbers);

            // Assert
            Assert.Equal(new List<int> { 21, 50, 70 }, result);
        }

        /// <summary>
        /// Test case for handling an empty list in LongestIncreasingSubarray.
        /// </summary>
        [Fact]
        public void FindLongestIncreasingSubarray_WhenListIsEmpty_ShouldReturnEmptyList()
        {
            // Arrange
            var numbers = new List<int>();

            // Act
            var result = LongestIncreasingSubarray.FindLongestIncreasingSubarray(numbers);

            // Assert
            Assert.Empty(result);
        }

        /// <summary>
        /// Test case for finding the most frequent character in a valid string.
        /// </summary>
        [Fact]
        public void FindMostFrequentCharacter_WhenStringIsValid_ShouldReturnMostFrequentCharacter()
        {
            // Arrange
            var input = "mississippi";

            // Act
            var result = MostFrequentCharacter.FindMostFrequentCharacter(input);

            // Assert
            Assert.Equal(('i', 4), result);
        }

        /// <summary>
        /// Test case for handling an empty string in MostFrequentCharacter.
        /// </summary>
        [Fact]
        public void FindMostFrequentCharacter_WhenStringIsEmpty_ShouldReturnDefault()
        {
            // Arrange
            var input = string.Empty;

            // Act
            var result = MostFrequentCharacter.FindMostFrequentCharacter(input);

            // Assert
            Assert.Equal((default(char), 0), result); // No characters in the string
        }

        /// <summary>
        /// Test case for handling a string with multiple characters having the same frequency.
        /// Should return the lexicographically smallest character.
        /// </summary>
        [Fact]
        public void FindMostFrequentCharacter_WhenMultipleCharactersHaveSameFrequency_ShouldReturnSmallestCharacter()
        {
            // Arrange
            var input = "abababab";

            // Act
            var result = MostFrequentCharacter.FindMostFrequentCharacter(input);

            // Assert
            Assert.Equal(('a', 4), result); // 'a' and 'b' both have frequency 4, but 'a' is smaller
        }
    }
}
