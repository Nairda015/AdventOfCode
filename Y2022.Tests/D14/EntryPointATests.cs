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
            "",
        };

        // Act
        var result = ArrayEntryPointA.Solve(input);

        // Assert
        Assert.Equal("0", result);
    }
}