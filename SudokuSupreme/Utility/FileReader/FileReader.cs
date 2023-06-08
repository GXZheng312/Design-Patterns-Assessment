namespace Utility.FileReader;

public class FileReader
{
    public static string LoadFile(string fileName)
    {
        try
        {
            return File.ReadAllText(fileName);
        }
        catch (IOException e)
        {
            throw new ArgumentException("File does not exist.");
        }
    }
}