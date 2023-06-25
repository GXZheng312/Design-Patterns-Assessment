using Logic;
using Presentation.Draw;

namespace Presentation.Drawable.Region;

public class CellRegion : IDrawable
{
    private readonly string _cellValue;
    private readonly bool? _definitive = null;
    private readonly bool? _isCorrect = null;
    private readonly bool _selected = false;

    private string EmptyDrawing() => ((char)DrawingCharacter.Empty).ToString();

    public CellRegion(string cellValue)
    {
        this._cellValue = cellValue;
    }

    public CellRegion(Cell cell, Cell? selectedCell)
    {
        this._cellValue = cell.Number.ToString();
        this._definitive = cell.IsDefinitive;
        this._isCorrect = cell.IsCorrect;

        if (selectedCell != null)
        {
            this._selected = ReferenceEquals(cell, selectedCell);
        }
    }

    public void Draw()
    {
        string content = IsEmptyCell() ? EmptyDrawing() : _cellValue;

        CheckFilled();
        CheckCorrect();
        CheckWrong();
        CheckSelected();

        Console.Write(content);

        Console.ResetColor();
    }

    private void CheckCorrect()
    {
        if (this._definitive is not false || this._isCorrect is not true || IsEmptyCell()) return;

        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Green;
    }

    private void CheckWrong()
    {
        if (this._definitive is not false || this._isCorrect is not false || IsEmptyCell()) return;

        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Red;
    }

    private void CheckFilled()
    {
        if (this._definitive is not false || IsEmptyCell()) return;

        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Yellow;
    }

    private void CheckSelected()
    {
        if (!this._selected) return;
        Console.BackgroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkCyan;
    }

    private bool IsEmptyCell()
    {
        return this._cellValue == ((char)DrawingCharacter.EmptyComparer).ToString();
    }
}