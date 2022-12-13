using Xunit;
using Y2022.D20;

namespace Y2022.Tests.D20;

public class EntryPointBTests : IEntryPointTest
{
    [Fact]
    public void Calculate_ShouldReturnResultFromChallengerDescription()
    {
        // Arrange
        var input = new[]
        {
            "",
        };

        // Act
        var result = ArrayEntryPointB.Solve(input);

        // Assert
        Assert.Equal("0", result);
    }
}