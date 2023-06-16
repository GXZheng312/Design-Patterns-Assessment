using Logic.Observer;
using Logic.Serializer;
using Logic.Serializer.Serial;

namespace Logic.Grid;

public class Board : ISudokuSerializable, IGridValidate
{
    public List<Cell> Cells { get; set; } = new List<Cell>();
    public List<Group> Sqaure { get; set; } = new List<Group>();
    public List<Group> Rows { get; set; } = new List<Group>();
    public List<Group> Columns { get; set; } = new List<Group>();
    public string Type { get; set; } = "samurai";

    public Board()
    {

    }

    public Board(List<Cell> cells, List<Group> groups)
    {
        Cells = cells;
        Sqaure = groups;
    }

    public string[] Serialize()
    {
        return new SerializeSudokuFactory().getSerializerType(Type).Serialize(this);
    }

    public bool Validate()
    {
        throw new NotImplementedException();
    }
}