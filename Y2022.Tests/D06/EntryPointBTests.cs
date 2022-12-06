using Xunit;
using Y2022.D06;

namespace Y2022.Tests.D06;

public class EntryPointBTests
{
    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", "19")]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", "23")]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", "23")]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", "29")]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", "26")]
    public void Calculate_ShouldReturnResultFromChallengerDescription(string input, string expected)
    {
        // Arrange
        
        // Act
        var result = ArrayEntryPointB.Solve(input);

        // Assert
        Assert.Equal(expected, result);
    }
}