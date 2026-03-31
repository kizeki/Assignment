using System.Text;

namespace TextFilter.Services;

public class FileReader
{
    public IEnumerable<string> ReadLines(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"The file '{filePath}' was not found.");

        using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        using var reader = new StreamReader(stream, Encoding.UTF8);

        while (!reader.EndOfStream)        {
            yield return reader.ReadLine() ?? string.Empty;
        }
    }
}
