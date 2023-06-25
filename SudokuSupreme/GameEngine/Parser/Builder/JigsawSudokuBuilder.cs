using Logic.Model;

namespace GameEngine.Parser.Builder;

public class JigsawSudokuBuilder : IBoardBuilder
{
    private List<Cell> Cells = new();
    private List<Group> Rows = new();
    private List<Group> Columns = new();
    private List<Group> Groups = new();

    private Dictionary<int, int[]> Raw { get; set; }
    private Dictionary<int, Cell> _cellsRaw = new();

    private int CellsPerGroup = 9;
    private int RowAmount = 9;
    private int ColumnAmount = 9;
    private int GroupAmount = 9;

    public JigsawSudokuBuilder(Dictionary<int, int[]> raw)
    {
        this.Raw = raw;
    }

    public IBoardBuilder BuildCells()
    {
        foreach (var (key, value) in Raw)
        {
            int number = value[0];
            int x = (key % 9) + 1;
            int y = (key / 9) + 1;

            Cell cell = new Cell(number, x, y);
            Cells.Add(cell);
            _cellsRaw[key] = cell;
        }

        return this;
    }

    public IBoardBuilder BuildRows()
    {
        for (int row = 1; row <= this.RowAmount; row++)
        {
            this.Rows.Add(new Group(this.Cells.Where(cell => cell.Y == row).ToList()));
        }

        return this;
    }

    public IBoardBuilder BuildColumns()
    {
        for (int column = 1; column <= this.ColumnAmount; column++)
        {
            this.Columns.Add(new Group(this.Cells.Where(cell => cell.X == column).ToList()));
        }

        return this;
    }

    public IBoardBuilder BuildGroups()
    {
        Dictionary<int, List<Cell>> groupCells = new();

        foreach (var (key, value) in Raw)
        {
            int groupNumber = value[1];

            if (!groupCells.ContainsKey(groupNumber))
            {
                groupCells[groupNumber] = new List<Cell>();
            }

            groupCells[groupNumber].Add(_cellsRaw[key]);
        }

        foreach (var groupCellPair in groupCells)
        {
            Groups.Add(new Group(groupCellPair.Value));
        }

        return this;
    }

    public IBoardBuilder AssignGroups()
    {
        foreach (var row in Rows)
        {
            row.Cells.ForEach(c => c.AddValidations(row));
        }

        foreach (var column in Columns)
        {
            column.Cells.ForEach(c => c.AddValidations(column));
        }

        foreach (var group in Groups)
        {
            group.Cells.ForEach(c => c.AddValidations(group));
        }

        return this;
    }

    public IBoard? Generate<T>() where T : IBoard
    {
        return (T)Activator.CreateInstance(typeof(T), this.Cells, this.Groups, this.Rows, this.Columns);
    }
}