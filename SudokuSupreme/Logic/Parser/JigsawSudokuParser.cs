namespace Logic.Parser;

public class JigsawSudokuParser : ISudokuParser
{
    public JigsawSudokuParser()
    {
    }
    
    public Board? LoadSudoku(string s)
    {
        Dictionary<int, int[]>? numbers = SudokuFileParser.ParseJigsawContent(s);

        if (numbers == null)
        {
            return null;
        }

        return CreateBoard(numbers);
    }

    private Board? CreateBoard(Dictionary<int, int[]> numbers)
    {
        List<Cell> cells = new List<Cell>();
        List<Group> groups = new List<Group>();

        int index = 0;
        foreach (var values in numbers.Values)
        {
            int value = values[0];
            int subIndex = values[1];

            Cell cell = new Cell(value, index % 9, index / 9);
            cells.Add(cell);

            if (subIndex == 0)
            {
                Group group = new Group(new List<Cell> { cell });
                groups.Add(group);
            }
            else
            {
                Group group = groups.Last();
                group.Cells.Add(cell);
            }

            index++;
        }

        return new Board(cells, groups);
    }
}