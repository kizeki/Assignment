using TextFilter.Filters;

namespace TextFilter.Tests.Filters;

public class MiddleVowelFilterTest
{
    [Theory]
    [InlineData(" ", false)]
    [InlineData("a", true)]
    [InlineData("A", true)]
    [InlineData("HELLO", false)]
    [InlineData("world", false)]
    [InlineData("the", false)]
    [InlineData("what", true)]
    [InlineData("TEST", true)]
    [InlineData("rather", false)]
    [InlineData("Alice", true)]
    public void ShouldRemove_ReturnsExpectedResult(string word, bool expected)
    {
        // Arrange
        var filter = new MiddleVowelFilter();

        // Act
        var result = filter.ShouldRemove(word);

        // Assert
        Assert.Equal(expected, result);
    }
}
