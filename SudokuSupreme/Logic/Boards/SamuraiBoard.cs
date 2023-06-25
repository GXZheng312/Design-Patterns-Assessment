namespace Logic.Boards;

public class SamuraiBoard : Board
{
    public SamuraiBoard(List<Cell> cells, List<Group> groups, List<Group> rows, List<Group> columns) : base(cells,
        groups, rows, columns)
    {
        Type = "samurai";
    }
}