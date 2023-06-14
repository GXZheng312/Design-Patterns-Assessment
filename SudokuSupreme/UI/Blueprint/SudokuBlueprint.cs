using Presentation.Draw;
using Presentation.Drawable.Board;
using Presentation.Drawable.Region;

namespace Presentation.Blueprint;

public class SudokuBlueprint : IBlueprint
{
    private const int RowSize = 9;
    private const int GroupSize = 3;
    private const int CellSize = 81;
    private int CellIndex { get; set; }

    public IDrawable Generate(char[] cells)
    {
        if (cells == null || cells.Length != CellSize) throw new ArgumentException($"Sudoku amount is invalid");
        CellIndex = 0;
        Sudoku sudoku = new Sudoku();

        for (int row = 1; row <= RowSize; row++)
        {
            if(row == 1)
            {
                sudoku.Add(HorizontalDecoration());
            }

            sudoku.Add(GridRow(cells));

            if(row % GroupSize == 0)
            {
                sudoku.Add(HorizontalDecoration());
            }
        }

        return sudoku;
    }

    private IDrawable GridRow(char[] cells)
    {
        IDrawable[] group = new IDrawable[GroupSize];

        for (int groupColumn = 0; groupColumn < GroupSize; groupColumn++)
        {
            group[groupColumn] = new Group(new IDrawable[] {
                    new Cell(cells[CellIndex++]),
                    new Cell(cells[CellIndex++]),
                    new Cell(cells[CellIndex++])
                });
        }

        return new Row(new Grid(group));
    }

    private IDrawable HorizontalDecoration()
    {
        Row collection = new Row();

        for (int groupColumn = 0; groupColumn < GroupSize; groupColumn++)
        {
            if(groupColumn == 0)
            {
                collection.Add(new Cell((char)DrawingCharacter.SplitWall));
            }

            collection.Add(new Cell((char)DrawingCharacter.HorzitalWall));
            collection.Add(new Cell((char)DrawingCharacter.HorzitalWall));
            collection.Add(new Cell((char)DrawingCharacter.HorzitalWall));

            collection.Add(new Cell((char)DrawingCharacter.SplitWall));
        }

        return collection;
    }
}