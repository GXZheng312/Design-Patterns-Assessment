using Logic.Model;
using Logic.Visitor;

namespace Logic.Grid;

public class Cell : ICell, IGridValidate, IVisitable
{
    private List<IGridValidate> Validations = new List<IGridValidate>(); // max 3 groups
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

    public void AddValidations(IGridValidate child)
    {
        if (child == null) return;

        Validations.Add(child);
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
}