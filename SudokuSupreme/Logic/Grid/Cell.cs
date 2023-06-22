namespace Logic.Grid;

public class Cell : IGridValidate
{
    private List<IGridValidate> Validations = new List<IGridValidate>(); // max 3 groups
    public bool IsDefinitive { get; set; } = false;
    public int Number { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public Cell(int number)
    {
        Number = number;
    }

    public Cell(int number, int x, int y)
    {
        Number = number;
        X = x;
        Y = y;
    }

    public void AddValidations(IGridValidate child)
    {
        if (child == null) return;

        Validations.Add(child);
    }

    public bool Validate()
    {
        foreach (IGridValidate child in Validations)
        {
            if (!child.Validate())
            {
                return false;
            }
        }

        return true;
    }
}