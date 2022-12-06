using Xunit;
using Y2022.D06;

namespace Y2022.Tests.D06;

public class EntryPointATests
{
    [Theory]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", "5")]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", "6")]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", "10")]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", "11")]
    public void Calculate_ShouldReturnResultFromChallengerDescription(string input, string expected)
    {
        // Arrange
        
        // Act
        var result = ArrayEntryPointA.Solve(input);

        // Assert
        Assert.Equal(expected, result);
    }
}