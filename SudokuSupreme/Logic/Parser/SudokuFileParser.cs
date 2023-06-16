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

    public static Dictionary<int, int[]>? ParseJigsawContent(string s)
    {
        const int jigsawSize = 81;

        int index = s.IndexOf('=');
        if (index != -1)
        {
            s = s.Substring(index + 1);
        }

        Dictionary<int, int[]> numbers = new Dictionary<int, int[]>();
        string[] cells = s.Split('=');

        for (var i = 0; i < cells.Length; i++)
        {
            var cell = cells[i];
            if (cell.Length == 3)
            {
                int value = int.Parse(cell.Substring(0, 1));
                int subIndex = int.Parse(cell.Substring(2, 1));
                numbers[i] = new [] { value, subIndex };
            }
        }

        if (numbers.Count != jigsawSize)
        {
            return null;
        }

        return numbers;
    }
}