namespace Utility;

public class ReferenceFinderUtility
{
    private List<string[]> References { get; set; }

    public ReferenceFinderUtility()
    {
        var data = File.ReadLines("SudokuTypeReferenceBook.csv")
            .Select(line => line.Split(','))
            .ToList();

        References = data;
    }

    public string[]? GetReferences(string context)
    {
        return References.FirstOrDefault(reference => reference.Contains(context));
    }
}