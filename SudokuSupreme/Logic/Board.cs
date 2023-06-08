using Logic.Observer;
using Logic.Serializer;
using Logic.Serializer.Serial;

namespace Logic;

public class Board : ISudokuSerializable
{
    public List<Cell> Cells { get; set; }
    public List<Group> Groups { get; set; }
    public string Type { get; set; }

    public Board()
    {
        Cells = new List<Cell>();
        Groups = new List<Group>();

        this.Type = "samurai";
    }

    public string[] Serialize()
    {
        return new SerializeSudokuFactory().getSerializerType(this.Type).Serialize(this);
    }

}