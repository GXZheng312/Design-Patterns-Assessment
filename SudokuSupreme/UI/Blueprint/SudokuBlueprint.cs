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
            if(IsFirstRow(row))
            {
                sudoku.Add(HorizontalDecoration());
            }

            sudoku.Add(GridRow(cells));

            if(IsEndGroup(row))
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

        for (int groupNr = 1; groupNr <= GroupSize; groupNr++)
        {
            if(IsFirstGroup(groupNr))
            {
                collection.Add(new Cell((char)DrawingCharacter.SplitWall));
            }

            collection.Add(new Cell((char)DrawingCharacter.HorizontalWall));
            collection.Add(new Cell((char)DrawingCharacter.HorizontalWall));
            collection.Add(new Cell((char)DrawingCharacter.HorizontalWall));

            collection.Add(new Cell((char)DrawingCharacter.SplitWall));
        }

        return collection;
    }
    private bool IsFirstGroup(int groupNr) => groupNr == 1;
    private bool IsFirstRow(int rowNumber) => rowNumber == 1;
    private bool IsEndGroup(int rowNumber) => rowNumber % GroupSize == 0;
}