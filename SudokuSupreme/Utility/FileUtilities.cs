using System.Text.RegularExpressions;

namespace Utility;

public class FileUtilities
{
    public static bool IsValidFilename(string filename)
    {
        const string pattern = @"^[a-zA-Z0-9_]+\.[a-zA-Z0-9]{1,}$";
        return Regex.IsMatch(filename, pattern);
    }
}