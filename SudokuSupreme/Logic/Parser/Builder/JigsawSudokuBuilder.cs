using Logic.Grid;

namespace Logic.Parser.Builder;

public class JigsawSudokuBuilder : IBoardBuilder
{
    private Dictionary<int, int[]> Cells { get; set; }

    public JigsawSudokuBuilder(Dictionary<int, int[]> cells)
    {
        this.Cells = cells;
    }

    public IBoardBuilder BuildCells()
    {
        throw new NotImplementedException();
    }

    public IBoardBuilder BuildRows()
    {
        throw new NotImplementedException();
    }

    public IBoardBuilder BuildColumns()
    {
        throw new NotImplementedException();
    }

    public IBoardBuilder BuildGroups()
    {
        throw new NotImplementedException();
    }

    public IBoardBuilder AssignGroups()
    {
        throw new NotImplementedException();
    }

    public IBoard? Generate<T>() where T : IBoard
    {
        throw new NotImplementedException();
    }
}