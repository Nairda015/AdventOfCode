using Xunit;
using Y2022.D18;

namespace Y2022.Tests.D18;

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