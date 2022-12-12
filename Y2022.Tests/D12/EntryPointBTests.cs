using Xunit;
using Y2022.D12;

namespace Y2022.Tests.D12;

public class EntryPointBTests : IEntryPointTest
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
        var result = ArrayEntryPointB.Solve(input);

        // Assert
        Assert.Equal("2713310158", result);
    }
}