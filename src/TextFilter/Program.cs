using System.Text;
using TextFilter.Filters;
using TextFilter.Services;

namespace TextFilter;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide the path to the text file as an argument.");
            return;
        }

        string filePath = args[0];
        var reader = new FileReader();
        var filters = new ITextFilter[]
        {
            new WordLengthFilter(3),
            new ContainLetterFilter('t'),
            new MiddleVowelFilter()
        };

        try
        {
            foreach (var line in reader.ReadLines(filePath))
            {
                var words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                words = words.Select(word => new string(word.Where(c => char.IsLetter(c) || char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.NonSpacingMark).ToArray())).ToArray();

                var filteredWords = words.Where(word => !filters.Any(filter => filter.ShouldRemove(word)));

                // Write with unicode support
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine(string.Join(' ', filteredWords));
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
