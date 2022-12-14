using Xunit;
using Y2022.D14;

namespace Y2022.Tests.D14;

public class EntryPointATests : IEntryPointTest
{
    [Fact]
    public void Calculate_ShouldReturnResultFromChallengerDescription()
    {
        // Arrange
        var input = new[]
        {
            "498,4 -> 498,6 -> 496,6",
            "503,4 -> 502,4 -> 502,9 -> 494,9",
        };

        // Act
        var result = ArrayEntryPointA.Solve(input);

        // Assert
        Assert.Equal("24", result);
    }
}