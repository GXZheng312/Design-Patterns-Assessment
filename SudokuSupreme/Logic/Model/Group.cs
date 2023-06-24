using Logic.Model;

namespace Logic.Grid;

public class Group : IGridValidate, IGroup
{
    public List<Cell> Cells { get; set; }

    public Group(List<Cell> cells)
    {
        Cells = cells;
    }

    public bool Validate()
    {
        List<int> filledCells = Cells.Where(c => c.Number != 0).Select(c => c.Number).ToList();
        HashSet<int> uniqueCells = new HashSet<int>(filledCells);

        if (filledCells.Count != uniqueCells.Count)
        {
            return false;
        }
        
        return true;
    }
}