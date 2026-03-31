namespace TextFilter.Services;

public interface IFileReader
{
    IEnumerable<string> ReadLines(string filePath);
}
