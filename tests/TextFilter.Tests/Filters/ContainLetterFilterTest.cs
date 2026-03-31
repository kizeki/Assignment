using TextFilter.Filters;

namespace TextFilter.Tests.Filters;

public class ContainLetterFilterTest
{
    [Theory]
    [InlineData("", new char[] { ' ' }, false)]
    [InlineData("the", new char[] { }, false)]
    [InlineData("hello", new char[] { 't' }, false)]
    [InlineData("test", new char[] { 't' }, true)]
    [InlineData("example", new char[] { 'x', 'z' }, true)]
    [InlineData("CLean", new char[] { 'L', 'o' }, true)]
    [InlineData("สวัสดี", new char[] { 'x' }, false)]
    public void ShouldRemove_ReturnsExpectedResult(string word, char[] letters, bool expected)
    {
        // Arrange
        var filter = new ContainLetterFilter(letters);

        // Act
        var result = filter.ShouldRemove(word);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ShouldRemove_MultipleLetters_IsCaseSensitive()
    {
        // Arrange
        var letters = new char[] { 't', 'A', 'ส' };

        // Act
        var filter = new ContainLetterFilter(letters);

        // Assert
        Assert.True(filter.ShouldRemove("started"));
        Assert.True(filter.ShouldRemove("ORANGE"));
        Assert.True(filter.ShouldRemove("สวัสดี"));
    }
}
