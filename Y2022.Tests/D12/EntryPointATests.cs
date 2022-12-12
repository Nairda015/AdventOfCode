using Xunit;
using Y2022.D12;

namespace Y2022.Tests.D12;

public class EntryPointATests : IEntryPointTest
{
    [Fact]
    public void Calculate_ShouldReturnResultFromChallengerDescription()
    {
        // Arrange
        var input = new[]
        {
            "Sabqponm",
            "abcryxxl",
            "accszExk",
            "acctuvwj",
            "abdefghi",
        };
               
        // Act
        var result = ArrayEntryPointA.Solve(input);

        // Assert
        Assert.Equal("31", result);
    }
}

