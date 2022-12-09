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
            "R 5",
            "U 8",
            "L 8",
            "D 3",
            "R 17",
            "D 10",
            "L 25",
            "U 20",
        };
        // Act
        var result = ArrayEntryPointB.Solve(input);

        // Assert
        Assert.Equal("36", result);
    }
}