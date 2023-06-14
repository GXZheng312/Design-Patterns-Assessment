using Logic.Observer;
using Logic.Serializer;
using Logic.Serializer.Serial;

namespace Logic;

public class Board : ISudokuSerializable
{
    public List<Cell> Cells { get; set; }
    public List<Group> Groups { get; set; }
    public string Type { get; set; }

    public Board(List<Cell> cells, List<Group> groups)
    {
        Cells = cells;
        Groups = groups;

        this.Type = "sudoku";
    }

    public char[] Serialize()
    {
        return new SerializeSudokuFactory().getSerializerType(this.Type).Serialize(this);
    }

}