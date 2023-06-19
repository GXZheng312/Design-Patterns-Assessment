namespace Logic.Grid;

public class VariantFourBoard : Board
{
    public VariantFourBoard(List<Cell> cells, List<Group> groups, List<Group> rows, List<Group> columns) : base(cells, groups, rows, columns)
    {
        base.Type = "four";
    }
}