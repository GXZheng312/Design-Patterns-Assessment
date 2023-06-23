namespace Logic.Grid;

public class Group : IGridValidate
{
    public List<Cell> Cells { get; set; }

    public Group(List<Cell> cells)
    {
        Cells = cells;
    }

    public bool Validate()
    {
        bool[] results = new bool[Cells.Count];

        foreach (Cell cell in Cells)
        {
            if (cell.Number == 0)
            {
                continue;
            }
            
            if (cell.Number >= Cells.Count)
            {
                return false;
            }

            if (results[cell.Number - 1])
            {
                return false;
            }

            results[cell.Number] = true;
        }

        return true;
    }
}