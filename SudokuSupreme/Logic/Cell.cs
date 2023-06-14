namespace Logic;

public class Cell
{
    public bool IsDefinitive { get; set; } = false;
    public int Number { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public Cell(int number, int x, int y)
    {
        Number = number;
        X = x;
        Y = y;
    }
}