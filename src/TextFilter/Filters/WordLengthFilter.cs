namespace TextFilter.Filters;

public class WordLengthFilter : ITextFilter
{
    private readonly int _minLength;

    public WordLengthFilter(int minLength)
    {
        _minLength = minLength;
    }

    public bool ShouldRemove(string word)
    {
        return word.Length < _minLength;
    }
}
