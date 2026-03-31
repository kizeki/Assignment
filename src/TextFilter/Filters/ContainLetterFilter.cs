namespace TextFilter.Filters;

public class ContainLetterFilter : ITextFilter
{
    private readonly HashSet<char> _letters;

    public ContainLetterFilter(params char[] letters)
    {
        _letters = new HashSet<char>(letters);
    }

    public bool ShouldRemove(string word)
    {
        return word.Any(c => _letters.Contains(c));
    }
}
