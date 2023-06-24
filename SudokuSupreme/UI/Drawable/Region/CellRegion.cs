using Logic.Grid;
using Presentation.Draw;

namespace Presentation.Drawable.Region;

public class CellRegion : IDrawable
{
    private string CellValue { get; set; }
    private string CellContent { get; set; }
    private bool? Definitive { get; set; } = null;
    private bool? IsCorrect { get; set; } = null;
    private bool Selected { get; set; } = false;

    private string EmptyDrawing() => ((char)DrawingCharacter.Empty).ToString();

    public CellRegion(string cellValue)
    {
        this.CellValue = cellValue;
    }

    public CellRegion(Cell cell, Cell? selectedCell)
    {
        this.CellValue = cell.Number.ToString();
        this.Definitive = cell.IsDefinitive;
        this.IsCorrect = cell.Validate();

        if(selectedCell != null)
        {
            this.Selected = ReferenceEquals(cell, selectedCell);
        }

    }

    public void Draw()
    {
        this.CellContent = IsEmptyCell() ? EmptyDrawing() : CellValue;

        CheckFilled();
        CheckWrong();
        CheckSelected();

        Console.Write(this.CellContent);

        Console.ResetColor();
    }

    private void CheckWrong()
    {
        if (this.Definitive is not false || IsEmptyCell()) return;

        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Red;
    }

    private void CheckFilled()
    {
        if (this.Definitive is not false || IsEmptyCell()) return;

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