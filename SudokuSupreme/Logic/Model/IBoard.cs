namespace Logic.Grid
{
    public interface IBoard
    {
        string Type { get; set; }
        List<Cell> Cells { get; set; }
    }
}
