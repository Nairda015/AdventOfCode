using Xunit;
using Y2022.D04;

namespace Y2022.Tests.D04;

public class EntryPointATests : IEntryPointTest
{
    [Fact]
    public void Calculate_ShouldReturnResultFromChallengerDescription()
    {
        // Arrange
        var input = new[]
        {
            "2-4,6-8",
            "2-3,4-5",
            "5-7,7-9",
            "2-8,3-7",
            "6-6,4-6",
            "2-6,4-8",
        };
        // Act
        var result = EntryPointA.Solve(input);

        // Assert
        Assert.Equal("2", result);
    }
}