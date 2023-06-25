using Logic.Model;
using Logic.Visitor;

namespace Logic.Grid;

public class Cell : ICell, IGridValidate, IVisitable, IPrototype
{
    public List<IGridValidate> Validations = new List<IGridValidate>();

    public List<Cell> HelpNumbers { get; set; } = new List<Cell>();
    public bool IsDefinitive { get; set; } = false;
    public bool? IsCorrect { get; set; } = null;
    public int Number { get; set; }
    public int X { get; set; }
    public int Y { get; set; }


    public Cell(int number)
    {
        Number = number;

        if (number != 0)
        {
            IsDefinitive = true;
        }
    }

    public Cell(int number, int x, int y)
    {
        Number = number;
        X = x;
        Y = y;

        if (number != 0)
        {
            IsDefinitive = true;
        }
    }

    public void AddValidations(params IGridValidate[] children)
    {
        foreach (IGridValidate child in children)
        {
            Validations.Add(child);
        }
    }

    public bool Validate()
    {
        if (Number == 0) return false;

        foreach (IGridValidate child in Validations)
        {
            if (!child.Validate())
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


    public IPrototype Clone()
    {
        Cell clone = new Cell(this.Number, this.X, this.Y);
        clone.AddValidations(this.Validations.ToArray());

        return clone;
    }
}