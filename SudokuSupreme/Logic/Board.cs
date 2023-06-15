using Logic.Observer;
using Logic.Serializer;
using Logic.Serializer.Serial;

namespace Logic;

public class Board : ISudokuSerializable
{
    public List<Cell> Cells { get; set; } = new List<Cell>();
    public List<Group> Groups { get; set; } = new List<Group>();
    public string Type { get; set; } = "samurai";

    public Board()
    {

    }

    public Board(List<Cell> cells, List<Group> groups)
    {
        Cells = cells;
        Groups = groups;
    }

    public string[] Serialize()
    {
        return new SerializeSudokuFactory().getSerializerType(this.Type).Serialize(this);
    }

}