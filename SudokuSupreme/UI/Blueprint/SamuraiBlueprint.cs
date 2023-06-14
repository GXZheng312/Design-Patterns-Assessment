using Presentation.Draw;
using Presentation.Drawable.Board;
using Presentation.Drawable.Region;

namespace Presentation.Blueprint;

public class SamuraiBlueprint : IBlueprint
{
    private const int sudokuRowSize = 9;
    private const int MiddleRowSize = 3;
    private const int AmountRow = (sudokuRowSize * 2) + MiddleRowSize;
    private const int AmountGroupsPerGrid = 7;
    private const int GroupSize = 3;
    private const int SudokuSize = 81;
    private const int CellSize = SudokuSize * 5;
    private int CellIndex { get; set; }

    public IDrawable Generate(char[] cells)
    {
        if (cells == null || cells.Length != CellSize) throw new ArgumentException($"Sudoku amount is invalid");
        CellIndex = 0;
        Samurai samurai = new Samurai();

        for(int row = 1; row <= AmountRow; row++)
        {
            Row collection = new Row();

            LeftSudoku(row, collection);
            MiddleSudoku(row, collection);
            RightSudoku(row, collection);

            samurai.Add(collection);
        }

        return samurai;
    }

    private void LeftSudoku(int rowNumber, Row collection)
    {
        if (rowNumber <= sudokuRowSize)
        {
            collection.Add(new Cell('L'));
        }

        if(rowNumber >= (sudokuRowSize + MiddleRowSize))
        {
            collection.Add(new Cell('L'));
        }
    }

    private void MiddleSudoku(int rowNumber, Row collection)
    {
        collection.Add(new Cell('M'));
    }

    private void RightSudoku(int rowNumber, Row collection)
    {
        if (rowNumber <= sudokuRowSize)
        {
            collection.Add(new Cell('R'));
        }

        if (rowNumber >= (sudokuRowSize + MiddleRowSize))
        {
            collection.Add(new Cell('R'));
        }
    }

    private IDrawable CenterHorizontalWalls()
    {
        return null;
    }

    private IDrawable OuterHorizontalWalls()
    {
        return null;
    }


}