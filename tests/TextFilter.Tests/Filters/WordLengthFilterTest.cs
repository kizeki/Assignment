using TextFilter.Filters;

namespace TextFilter.Tests.Filters;

public class WordLengthFilterTest
{
    [Theory]
    [InlineData("", 1, true)]
    [InlineData(" ", 3, true)]
    [InlineData("is", 3, true)]
    [InlineData("THE", 4, true)]
    [InlineData("world", 5, false)]    
    [InlineData("example", 7, false)]
    public void ShouldRemove_ReturnsExpectedResult(string word, int maxLength, bool expected)
    {
        // Arrange
        var filter = new WordLengthFilter(maxLength);

        // Act
        var result = filter.ShouldRemove(word);

        // Assert
        Assert.Equal(expected, result);
    }
}
