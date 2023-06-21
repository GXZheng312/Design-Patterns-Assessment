using Presentation.Draw;

namespace Presentation.Drawable.Region;

public class Cell : IDrawable
{
    private string CellValue { get; set; }
    private bool Definitive { get; set; }
    private bool Wrong { get; set; }
    private bool Selected { get; set; }

    public Cell(string cellValue)
    {
        this.CellValue = cellValue;
    }

    public void Draw()
    {
        string cellContent = IsEmptyCell() ? ((char)DrawingCharacter.Empty).ToString() : CellValue;

        Console.Write(cellContent);
    }

    private bool IsEmptyCell()
    {
        return this.CellValue == ((char)DrawingCharacter.EmptyComparer).ToString();
    }
}