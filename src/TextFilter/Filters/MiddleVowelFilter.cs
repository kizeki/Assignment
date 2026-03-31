namespace TextFilter.Filters;

public class MiddleVowelFilter : ITextFilter
{
    private static readonly HashSet<char> Vowels = new() { 'a', 'e', 'i', 'o', 'u' };

    public bool ShouldRemove(string word)
    {
        string middle = GetMiddle(word);

        // Check if any of the middle characters are vowels
        return middle.Any(c => Vowels.Contains(char.ToLower(c)));
    }

    private static string GetMiddle(string word)
    {
        int mid = word.Length / 2;

        // For odd length, return the single middle character
        if (word.Length % 2 == 1)
            return word[mid].ToString();

        // For even length, return the two middle characters
        return word.Substring(mid - 1, 2);
    }
}
