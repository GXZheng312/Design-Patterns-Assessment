namespace Utility.FileReader;

public class FileReader
{
    public static string LoadFile(string fileName)
    {
        try
        {
            string? folderPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.Parent?.FullName;
            
            if (string.IsNullOrEmpty(folderPath)) throw new ArgumentException("File does not exist.");
            
            string filePath = Path.Combine(folderPath, "Files", fileName);
            
            return File.ReadAllText(filePath);

        }
        catch (IOException e)
        {
            throw new ArgumentException("File does not exist.");
        }
    }
}