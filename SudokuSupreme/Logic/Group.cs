using Logic.Visitor;

namespace Logic;

public class Group : IGridValidate, IGroup, IVisitable, IPrototype
{
    public List<Cell> Cells { get; set; }

    public Group()
    {
        this.Cells = new List<Cell>();
    }

    public Group(List<Cell> cells)
    {
        Cells = cells;
    }

    public void AddCells(params Cell[] children)
    {
        foreach (Cell child in children)
        {
            Cells.Add(child);
        }
    }

    public bool Validate()
    {
        List<int> filledCells = Cells.Where(c => c.Number != 0).Select(c => c.Number).ToList();
        HashSet<int> uniqueCells = new HashSet<int>(filledCells);

        if (filledCells.Count != uniqueCells.Count)
        {
            return false;
        }

        return true;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    public IPrototype Clone()
    {
        return new Group();
    }
}