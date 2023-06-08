namespace Logic;

public class Board
{
    public List<Cell> Cells { get; set; }
    public List<Group> Groups { get; set; }

    public Board(List<Cell> cells, List<Group> groups)
    {
        Cells = cells;
        Groups = groups;
    }
}