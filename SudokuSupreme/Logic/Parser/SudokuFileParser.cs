namespace Logic.Parser;

public class SudokuFileParser
{
    public static List<int>? ParseContents(string s, int size)
    {
        if (s.Length != size)
        {
            return null;
        }

        List<int> numbers = new List<int>();
        foreach (char c in s)
        {
            if (!char.IsDigit(c))
            {
                return null;
            }

            numbers.Add(int.Parse(c.ToString()));
        }

        return numbers;
    }
}