using Xunit;
using Y2022.D02;

namespace Y2022.Tests.D02;

public class EntryPointBTests : IEntryPointTest
{
    [Fact]
    public void Calculate_ShouldReturnResultFromChallengerDescription()
    {
        // Arrange
        var input = new[]
        {
            "A Y",
            "B X",
            "C Z",
        };
        
        // Act
        var result = EntryPointB.Solve(input);

        // Assert
        Assert.Equal("12", result);
    }
}