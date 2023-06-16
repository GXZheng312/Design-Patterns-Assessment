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
            if (!cell.Validate())
            {
                return false;
            }

            if (results[cell.Number]) 
            {
                return false;
            }

            results[cell.Number] = true;
        }

        return true;
    }


}

