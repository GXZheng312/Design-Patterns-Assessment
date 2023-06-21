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

    public Cell? CurrentCell { get; set; }

    public Board()
    {
    }

    public Board(List<Cell> cells, List<Group> groups, List<Group> rows, List<Group> columns)
    {
        Cells = cells;
        Boxes = groups;
        Rows = rows;
        Columns = columns;

        CurrentCell = Cells[0];
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
        if (CurrentCell == null) return;
        
        Cell? newCell = Cells.FirstOrDefault(c => c.X == CurrentCell.X && c.Y == CurrentCell.Y - 1);
        if (newCell != null)
        {
            CurrentCell = newCell;
        }
    }
    
    public void MoveDown()
    {
        if (CurrentCell == null) return;
        
        Cell? newCell = Cells.FirstOrDefault(c => c.X == CurrentCell.X && c.Y == CurrentCell.Y + 1);
        if (newCell != null)
        {
            CurrentCell = newCell;
        }
    }
    
    public void MoveLeft()
    {
        if (CurrentCell == null) return;
        
        Cell? newCell = Cells.FirstOrDefault(c => c.X == CurrentCell.X - 1 && c.Y == CurrentCell.Y);
        if (newCell != null)
        {
            CurrentCell = newCell;
        }
    }
    
    public void MoveRight()
    {
        if (CurrentCell == null) return;
        
        Cell? newCell = Cells.FirstOrDefault(c => c.X == CurrentCell.X + 1 && c.Y == CurrentCell.Y);
        if (newCell != null)
        {
            CurrentCell = newCell;
        }
    }

    public void SetCurrentCell(int number)
    {
        if (CurrentCell == null) return;
        
        CurrentCell.Number = number;
    }
}