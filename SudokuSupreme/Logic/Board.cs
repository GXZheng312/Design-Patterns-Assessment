namespace Logic;

public class Board
{
    public List<Cell> Cells { get; set; }
    public List<Group> Groups { get; set; }

    public Board()
    {
        Cells = new List<Cell>();
        Groups = new List<Group>();
    }
}