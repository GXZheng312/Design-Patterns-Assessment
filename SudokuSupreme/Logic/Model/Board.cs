using Logic.Model;
using Logic.Serializer;
using Logic.Serializer.Serial;
using Logic.Visitor;

namespace Logic.Grid;

public abstract class Board : ISudokuSerializable, IGridValidate, IBoard, IVisitable
{
    public List<Cell> Cells { get; set; } = new List<Cell>();
    public List<Group> Boxes { get; set; } = new List<Group>();
    public List<Group> Rows { get; set; } = new List<Group>();
    public List<Group> Columns { get; set; } = new List<Group>();
    public string Type { get; set; }
    public Cell SelectedCell { get; set; }

    public Board()
    {
    }

    public Board(List<Cell> cells, List<Group> groups, List<Group> rows, List<Group> columns)
    {
        Cells = cells;
        Boxes = groups;
        Rows = rows;
        Columns = columns;

        SelectedCell = Cells[0];
    }

    public string[] Serialize()
    {
        if (string.IsNullOrEmpty(Type)) return new string[] { };

        return new SerializeSudokuFactory().GetSerializerType(Type).Serialize(this);
    }

    public bool Validate()
    {
        foreach (Cell cell in this.Cells)
        {
            if (!cell.Validate())
            {
                return false;
            }
        }

        return true;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}