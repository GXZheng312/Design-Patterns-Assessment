using Microsoft.VisualBasic.FileIO;


namespace Utility;

public class ReferenceFinderUtility
{
    List<string[]> References { get; set; } = new List<string[]>();


    public ReferenceFinderUtility() 
    {
        var data = File.ReadLines("SudokuTypeReferenceBook.csv")
            .Select(line => line.Split(','))
            .ToList();

        References = data;

    }


    public string[]? GetReferences(string context)
    {
        foreach (string[] reference in References)
        {
            if (reference.Contains(context))
            {
                return reference;
            }
        }

        return null;
    }
}
