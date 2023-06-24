using Logic.Grid;
using Presentation.Draw;

namespace Presentation.Drawable.Region;

public class CellRegion : IDrawable
{
    private string CellValue { get; set; }
    private bool? Definitive { get; set; } = null;
    private bool? Wrong { get; set; } = null;
    private bool Selected { get; set; } = false;

    public CellRegion(string cellValue)
    {
        this.CellValue = cellValue;
    }

    public CellRegion(Cell cell, Cell? selectedCell)
    {
        this.CellValue = cell.Number.ToString();
        this.Definitive = cell.IsDefinitive;
        //this.Wrong = cell.Validate();
        if(selectedCell != null)
        {
            this.Selected = ReferenceEquals(cell, selectedCell);
        }

    }

    public void Draw()
    {
        string cellContent = IsEmptyCell() ? ((char)DrawingCharacter.Empty).ToString() : CellValue;

        CheckFilled();
        CheckWrong();
        CheckSelected();

        Console.Write(cellContent);

        Console.ResetColor();
    }

    private void CheckWrong()
    {
        if (this.Wrong is not true) return;

        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Red;
    }

    private void CheckFilled()
    {
        if (this.Definitive is not true || IsEmptyCell()) return;

        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Yellow;
    }

    private void CheckSelected()
    {
        if (!this.Selected) return;
        Console.BackgroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkCyan;
    }

    private bool IsEmptyCell()
    {
        return this.CellValue == ((char)DrawingCharacter.EmptyComparer).ToString();
    }
}