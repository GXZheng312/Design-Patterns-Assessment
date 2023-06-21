namespace Logic.Grid;

public class Cell : IGridValidate
{
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

    public bool Validate()
    {
        return Number != 0;
    }
}