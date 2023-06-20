using Logic.Grid;

namespace Logic.Parser.Builder;

public class SamuraiSudokuBuilder : IBoardBuilder
{
    private List<string> Cells { get; set; }

    public SamuraiSudokuBuilder(List<string> cells)
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

    public IBoard Generate<T>() where T : Board
    {
        throw new NotImplementedException();
    }
}