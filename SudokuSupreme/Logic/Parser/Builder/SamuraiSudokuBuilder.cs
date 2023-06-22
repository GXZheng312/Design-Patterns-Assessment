using Logic.Grid;

namespace Logic.Parser.Builder;

public class SamuraiSudokuBuilder : IBoardBuilder
{
    private List<Cell> Cells = new();
    private List<Group> Rows = new();
    private List<Group> Columns = new();
    private List<Group> Groups = new();

    private List<int> CellsRaw { get; set; }

    public SamuraiSudokuBuilder(List<int> cells)
    {
        this.CellsRaw = cells;
    }

    public IBoardBuilder BuildCells()
    {
        this.CellsRaw.ForEach(value => { Cells.Add(new Cell(value)); });

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
        return this;
    }

    public IBoard Generate<T>() where T : IBoard
    {
        return (T)Activator.CreateInstance(typeof(T), this.Cells, this.Groups, this.Rows, this.Columns);
    }
}