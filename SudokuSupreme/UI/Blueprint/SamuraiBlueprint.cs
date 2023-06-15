using Presentation.Draw;
using Presentation.Drawable.Board;
using Presentation.Drawable.Region;

namespace Presentation.Blueprint;

public class SamuraiBlueprint : IBlueprint
{
    private const int DefaultSudokuRowSize  = 9;
    private const int MiddleRowSize = 3;
    private const int TotalRowAmount = (DefaultSudokuRowSize  * 2) + MiddleRowSize;

    private const int TotalGridGroups = 7;
    private const int TotalPopulateSudokuGridGroups = 3;
    private const int CenterGridOffset = 2;

    private const int GroupSize = 3;
    private const int DefaultSudokuSize = 81;
    private const int SamuraiSudokuSize = DefaultSudokuSize * 5;
    private int CellIndex { get; set; }
    private char[] Cells { get; set; }

    public SamuraiBlueprint()
    {
        CellIndex = 0;
        Cells = new char[DefaultSudokuSize];
    }

    public IDrawable Generate(char[] cells)
    {
        if (!CheckInitValues(cells)) throw new ArgumentException($"Sudoku amount is invalid");

        Samurai samurai = new Samurai();

        samurai.Add(HorizontalWalls(false));

        for (int row = 1; row <= TotalRowAmount; row++)
        {
            samurai.Add(GenerateRow(row));

            if (IsGroupRowEnd(row))
            {
                bool isOverlay = IsOverlayRow(row);
                samurai.Add(HorizontalWalls(isOverlay));
            }

        }

        return samurai;
    }

    private IDrawable GenerateRow(int rowNumber)
    {
        Row collection = new Row();

        ProcessSideSudoku(rowNumber, collection, isLeftSide: true);
        ProcessMiddleSudoku(rowNumber, collection);
        ProcessSideSudoku(rowNumber, collection, isLeftSide: false);

        return collection;
    }

    private bool CheckInitValues(char[] cells)
    {
        if (cells == null || cells.Length != SamuraiSudokuSize) return false;

        CellIndex = 0;
        Cells = cells;

        return true;
    }

    private void ProcessSideSudoku(int rowNumber, Row collection, bool isLeftSide)
    {
        int sideOffset = isLeftSide ? 0 : DefaultSudokuSize;

        if (IsTopSide(rowNumber))
        {
            int offset = sideOffset;
            CellIndex = (rowNumber - 1) * 9;

            PopulateSudokuGrid(collection, offset);
            return;
        }

        if (IsBottomSide(rowNumber))
        {
            int offset = DefaultSudokuSize * 3 + sideOffset;
            CellIndex = (rowNumber - DefaultSudokuRowSize - MiddleRowSize - 1) * 9;

            PopulateSudokuGrid(collection, offset);
            return;
        }
    }

    private void ProcessMiddleSudoku(int rowNumber, Row collection)
    {
        CellIndex = (rowNumber - (DefaultSudokuRowSize - MiddleRowSize) - 1) * 9;
        int offset = DefaultSudokuSize * 2;

        if (IsCenter(rowNumber))
        {
            PopulateCenterGrid(collection, offset);
        }
        else if (IsOuterCenter(rowNumber))
        {
            PopulateOuterCenterGrid(collection, offset);
        }
        else
        {
            collection.Add(EmptyGroup());
        }
    }

    private void PopulateCenterGrid(Row collection, int offset)
    {   
        for (int grid = 1; CenterGridOffset >= grid; grid++)
        {
            collection.Add(new Cell((char)DrawingCharacter.Empty));
            collection.Add(EmptyGroup());
        }

        PopulateSudokuGrid(collection, offset);
    }

    private void PopulateOuterCenterGrid(Row collection, int offset)
    {
        CellIndex += GroupSize;
        collection.Add(CreateGroup(offset));
    }

    private void PopulateSudokuGrid(Row collection, int offset)
    {
        collection.Add(new Cell((char)DrawingCharacter.VerticalWall));
        for (int grid = 1; grid <= GroupSize; grid++)
        {
            collection.Add(CreateGroup(offset));
            collection.Add(new Cell((char)DrawingCharacter.VerticalWall));
        }
    }

    private IDrawable HorizontalWalls(bool overlay)
    {
        Row collection = new Row();
        collection.Add(new Cell((char)DrawingCharacter.SplitWall));

        for (int grid = 1; grid <= TotalGridGroups; grid++)
        {
            if (!overlay && grid == TotalGridGroups - TotalPopulateSudokuGridGroups)
            {
                collection.Add(EmptyGroup());
            }
            else
            {
                collection.Add(HorizontalGroup());
            }

            collection.Add(new Cell((char)DrawingCharacter.SplitWall));
        }

        return collection;
    }

    private IDrawable[] CreateGroup(int offset)
    {
        return new IDrawable[] {
            new Cell(Cells[offset + CellIndex++]),
            new Cell(Cells[offset + CellIndex++]),
            new Cell(Cells[offset + CellIndex++])
        };
    }

    private IDrawable[] EmptyGroup()
    {
        return new IDrawable[] {
            new Cell((char)DrawingCharacter.Empty),
            new Cell((char)DrawingCharacter.Empty),
            new Cell((char)DrawingCharacter.Empty)
        };
    }

    private IDrawable[] HorizontalGroup()
    {
        return new IDrawable[] {
            new Cell((char)DrawingCharacter.HorizontalWall),
            new Cell((char)DrawingCharacter.HorizontalWall),
            new Cell((char)DrawingCharacter.HorizontalWall)
        };
    }
    private bool IsOverlayRow(int rowNumber) => rowNumber >= DefaultSudokuRowSize - MiddleRowSize && rowNumber <= TotalRowAmount - (DefaultSudokuRowSize - MiddleRowSize);
    private bool IsGroupRowEnd(int rowNumber) => rowNumber % GroupSize == 0;
    private bool IsCenter(int rowNumber) => rowNumber > DefaultSudokuRowSize && rowNumber <= TotalRowAmount - DefaultSudokuRowSize;
    private bool IsOuterCenter(int rowNumber) => (rowNumber > DefaultSudokuRowSize - MiddleRowSize && rowNumber <= TotalRowAmount - (DefaultSudokuRowSize - MiddleRowSize));
    private bool IsTopSide(int rowNumber) => rowNumber <= DefaultSudokuRowSize;
    private bool IsBottomSide(int rowNumber) => rowNumber > (DefaultSudokuRowSize + MiddleRowSize);

}