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

    public Cell? SelectedCell { get; set; }

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
        throw new NotImplementedException();
    }

    public void MoveUp()
    {
        if (SelectedCell == null) return;

        Cell? newCell = Cells.FirstOrDefault(c => c.X == SelectedCell.X && c.Y == SelectedCell.Y - 1);
        if (newCell != null)
        {
            SelectedCell = newCell;
        }
    }

    public void MoveDown()
    {
        if (SelectedCell == null) return;

        Cell? newCell = Cells.FirstOrDefault(c => c.X == SelectedCell.X && c.Y == SelectedCell.Y + 1);
        if (newCell != null)
        {
            SelectedCell = newCell;
        }
    }

    public void MoveLeft()
    {
        if (SelectedCell == null) return;

        Cell? newCell = Cells.FirstOrDefault(c => c.X == SelectedCell.X - 1 && c.Y == SelectedCell.Y);
        if (newCell != null)
        {
            SelectedCell = newCell;
        }
    }

    public void MoveRight()
    {
        if (SelectedCell == null) return;

        Cell? newCell = Cells.FirstOrDefault(c => c.X == SelectedCell.X + 1 && c.Y == SelectedCell.Y);
        if (newCell != null)
        {
            SelectedCell = newCell;
        }
    }

    public void SetCurrentCell(int number, bool isDefinitive)
    {
        if (SelectedCell == null) return;

        SelectedCell.Number = number;
        SelectedCell.IsDefinitive = isDefinitive;
    }
}