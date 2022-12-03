using Xunit;
using Y2022.D01;

namespace Y2022.Tests.D01;

public class EntryPointBTests : IEntryPointTest
{
    [Fact]
    public void Calculate_ShouldReturnResultFromChallengerDescription()
    {
        // Arrange
        var input = new[]
        {
            "1000",
            "2000",
            "3000",
            "",
            "4000",
            "",
            "5000",
            "6000",
            "",
            "7000",
            "8000",
            "9000",
            "",
            "10000",
        };
        // Act
        var result = EntryPointB.Solve(input);

        // Assert
        Assert.Equal("45000", result);
    }
}