namespace TextFilter.Filters;

public interface ITextFilter
{
    bool ShouldRemove(string word);
}
