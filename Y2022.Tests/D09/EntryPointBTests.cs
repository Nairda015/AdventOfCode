using Xunit;
using Y2022.D09;

namespace Y2022.Tests.D09;

public class EntryPointBTests : IEntryPointTest
{
    [Fact]
    public void Calculate_ShouldReturnResultFromChallengerDescription()
    {
        // Arrange
        var input = new[]
        {
            "R 4",
            "U 4",
            "L 3",
            "D 1",
            "R 4",
            "D 1",
            "L 5",
            "R 2",
        };
        // Act
        var result = ArrayEntryPointB.Solve(input);

        // Assert
        Assert.Equal("8", result);
    }
}