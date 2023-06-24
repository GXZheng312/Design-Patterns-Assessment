namespace Logic.Grid
{
    public interface IBoard
    {
        List<Cell> Cells { get; set; }
        List<Group> Boxes { get; set; }
        List<Group> Rows { get; set; }
        List<Group> Columns { get; set; }
        string Type { get; set; }
        Cell SelectedCell { get; set; }
    }
}
