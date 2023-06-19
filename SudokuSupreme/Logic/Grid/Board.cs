using Logic.Serializer;
using Logic.Serializer.Serial;

namespace Logic.Grid;

public class Board : ISudokuSerializable, IGridValidate, IBoard
{
    public List<Cell> Cells { get; set; } = new List<Cell>();
    public List<Group> Boxes { get; set; } = new List<Group>();
    public List<Group> Rows { get; set; } = new List<Group>();
    public List<Group> Columns { get; set; } = new List<Group>();
    public string Type { get; set; }

    public Board()
    {
    }

    public Board(List<Cell> cells, List<Group> groups, List<Group> rows, List<Group> columns)
    {
        Cells = cells;
        Boxes = groups;
        Rows = rows;
        Columns = columns;
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