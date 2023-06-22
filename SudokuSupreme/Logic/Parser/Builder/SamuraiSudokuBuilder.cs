using Logic.Grid;

namespace Logic.Parser.Builder;

public class SamuraiSudokuBuilder : IBoardBuilder
{
    private List<Cell> Cells = new();
    private List<Group> Rows = new();
    private List<Group> Columns = new();
    private List<Group> Groups = new();

    private List<int> Raw { get; set; }
    private Dictionary<int[], Cell> _cellsRaw = new();

    private int GroupAmount = 9;
    private int CellsPerGroup = 9;
    private int RowColAmount = 9;
    private int TotalRowColAmount = 21;
    private int SubSudokuAmount = 5;

    public SamuraiSudokuBuilder(List<int> cells)
    {
        this.Raw = cells;
    }

    public IBoardBuilder BuildCells()
    {
        int index = 0;
        for (int subSudoku = 0; subSudoku < SubSudokuAmount; subSudoku++)
        {
            for (int row = 0; row < GroupAmount; row++)
            {
                for (int col = 0; col < CellsPerGroup; col++)
                {
                    int absoluteRow = (subSudoku * 3) + row + 1;
                    int absoluteCol = (subSudoku * 3) + col + 1;

                    Cell cell = new Cell(Raw[index], absoluteCol, absoluteRow);
                    Cells.Add(cell);
                    _cellsRaw.Add(new[] { absoluteCol, absoluteRow }, cell);

                    index++;
                }
            }
        }

        return this;
    }

    public IBoardBuilder BuildRows()
    {
        return this;
    }

    public IBoardBuilder BuildColumns()
    {
        return this;
    }

    public IBoardBuilder BuildGroups()
    {
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

    public IBoard Generate<T>() where T : IBoard
    {
        return (T)Activator.CreateInstance(typeof(T), this.Cells, this.Groups, this.Rows, this.Columns);
    }
}