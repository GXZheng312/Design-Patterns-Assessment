using Logic.Grid;

namespace Logic.Parser;

public class JigsawSudokuParser : ISudokuParser
{
    public JigsawSudokuParser()
    {
    }

    public IBoard LoadSudoku(string s)
    {
        Dictionary<int, int[]>? numbers = SudokuFileParser.ParseJigsawContent(s);

        if (numbers == null)
        {
            return null;
        }

        return CreateBoard(numbers);
    }

    private IBoard CreateBoard(Dictionary<int, int[]> numbers)
    {
        List<Cell> cells = new List<Cell>();
        List<Group> groups = new List<Group>();
        List<Group> rows = new List<Group>();
        List<Group> columns = new List<Group>();

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

        return new JigsawBoard(cells, groups, rows, columns);
    }
}