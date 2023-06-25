namespace Logic.Model.Boards;

public class VariantNineBoard : Board
{
    public VariantNineBoard(List<Cell> cells, List<Group> groups, List<Group> rows, List<Group> columns) : base(cells,
        groups, rows, columns)
    {
        Type = "nine";
    }
}