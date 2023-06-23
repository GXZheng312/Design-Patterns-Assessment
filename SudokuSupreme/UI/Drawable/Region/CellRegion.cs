using Logic.Grid;
using Presentation.Draw;

namespace Presentation.Drawable.Region;

public class CellRegion : IDrawable
{
    private string CellValue { get; set; }
    private bool Definitive { get; set; }
    private bool Wrong { get; set; }
    private bool Selected { get; set; } = false;

    public CellRegion(string cellValue)
    {
        this.CellValue = cellValue;
    }

    public CellRegion(Cell cell)
    {
        this.CellValue = cell.Number.ToString();
        this.Definitive = cell.IsDefinitive;
        //this.Wrong = cell.Validate();
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

        CheckSelected();

        Console.Write(cellContent);

        Console.ResetColor();
    }

    public void CheckSelected()
    {
        if(this.Selected)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
        }
    }

    private bool IsEmptyCell()
    {
        return this.CellValue == ((char)DrawingCharacter.EmptyComparer).ToString();
    }
}