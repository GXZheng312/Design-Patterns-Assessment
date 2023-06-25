namespace Logic.Boards;

public class JigsawBoard : Board
{
    public JigsawBoard(List<Cell> cells, List<Group> groups, List<Group> rows, List<Group> columns) : base(cells,
        groups, rows, columns)
    {
        Type = "jigsaw";
    }
}