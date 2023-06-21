namespace Logic.Grid;

public class VariantSixBoard : Board
{
    public VariantSixBoard(List<Cell> cells, List<Group> groups, List<Group> rows, List<Group> columns) : base(cells, groups, rows, columns)
    {
        base.Type = "six";
    }
}