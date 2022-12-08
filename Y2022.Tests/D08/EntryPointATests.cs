using Xunit;
using Y2022.D08;

namespace Y2022.Tests.D08;

public class EntryPointATests : IEntryPointTest
{
    [Fact]
    public void Calculate_ShouldReturnResultFromChallengerDescription()
    {
        // Arrange
        var input = new[]
        {
            "30373",
            "25512",
            "65332",
            "33549",
            "35390",
        };
        // Act
        var result = ArrayEntryPointA.Solve(input);

        // Assert
        Assert.Equal("21", result);
    }
}