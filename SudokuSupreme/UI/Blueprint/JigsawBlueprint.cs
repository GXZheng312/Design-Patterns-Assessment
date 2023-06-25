using Logic.Model;
using Presentation.Draw;
using Presentation.Drawable.Board;
using Presentation.Drawable.Region;

namespace Presentation.Blueprint;

public class JigsawBlueprint : IBlueprint
{
    private const int RowSize = 9;
    private const int ColumnSize = 9;
    private const int CellSize = RowSize * ColumnSize;

    private string EmptyDrawing = ((char)DrawingCharacter.Empty).ToString();
    private string VerticalWall = ((char)DrawingCharacter.VerticalWall).ToString();
    private string HorizontalWall = ((char)DrawingCharacter.HorizontalWall).ToString();
    private string SplitWall = ((char)DrawingCharacter.SplitWall).ToString();

    private string[,] RawCells2D { get; set; }
    private Cell[,] cells2D { get; set; }
    public Cell SelectedCell { get; set; }

    private void loadData(string[] rawCells, IBoard board, string? mode)
    {
        if (rawCells == null || rawCells.Length != CellSize) throw new ArgumentException($"Sudoku amount is invalid");

        this.RawCells2D = ConvertRaw2DArray(rawCells);
        this.cells2D = Convert2DArray(board.Cells.ToArray());
        this.SelectedCell = board.SelectedCell;
    }

    public IDrawable Generate(string[] rawCells, IBoard board, string? mode)
    {
        loadData(rawCells, board, mode);

        Jigsaw jigsaw = new Jigsaw();

        jigsaw.Add(DefaultHorizontalWalls(false));

        for (int y = 0; y < RowSize; y++)
        {
            jigsaw.Add(JigsawRow(y));

            if (!IsLastIteration(RowSize, y + 1))
            {
                jigsaw.Add(JigsawHorizontalWalls(y));
            }
        }

        jigsaw.Add(DefaultHorizontalWalls(true));

        return jigsaw;
    }


    private IDrawable JigsawRow(int y)
    {
        EmptyRegion jigsawGroup = new EmptyRegion();

        jigsawGroup.Add(new CellRegion(VerticalWall));

        for (int x = 0; x < ColumnSize; x++)
        {
            Cell value = cells2D[y, x];

            jigsawGroup.Add(new CellRegion(value, this.SelectedCell));

            if (!IsLastIteration(ColumnSize, x + 1))
            {
                jigsawGroup.Add(VerticalSeparationDrawing(y, x));
            }
            else
            {
                jigsawGroup.Add(new CellRegion(VerticalWall));
            }
        }

        return new RowRegion(jigsawGroup);
    }

    private IDrawable JigsawHorizontalWalls(int y)
    {
        EmptyRegion jigsawGroup = new EmptyRegion();

        string topLeftGroupNr = RawCells2D[y, 0][2].ToString();
        string bottomLeftGroupNr = RawCells2D[y + 1, 0][2].ToString();

        if (topLeftGroupNr == bottomLeftGroupNr)
        {
            jigsawGroup.Add(new CellRegion(VerticalWall));
        }
        else
        {
            jigsawGroup.Add(new CellRegion(SplitWall));
        }


        for (int x = 0; x < ColumnSize; x++)
        {
            jigsawGroup.Add(HorizontalSeparationDrawing(y, x));

            if (!IsLastIteration(ColumnSize, x + 1))
            {
                jigsawGroup.Add(SplitSeparationDrawing(y, x));
            }
            else
            {
                topLeftGroupNr = RawCells2D[y, x][2].ToString();
                bottomLeftGroupNr = RawCells2D[y + 1, x][2].ToString();

                if (topLeftGroupNr == bottomLeftGroupNr)
                {
                    jigsawGroup.Add(new CellRegion(VerticalWall));
                }
                else
                {
                    jigsawGroup.Add(new CellRegion(SplitWall));
                }
            }
        }

        return new RowRegion(jigsawGroup);
    }

    private IDrawable SplitSeparationDrawing(int y, int x)
    {
        if (x >= ColumnSize) throw new ArgumentException($"Sudoku size is invalid");

        string topLeftGroupNr = RawCells2D[y, x][2].ToString();
        string bottomLeftGroupNr = RawCells2D[y + 1, x][2].ToString();

        string topRightGroupNr = RawCells2D[y, x + 1][2].ToString();
        string bottomRightGroupNr = RawCells2D[y + 1, x + 1][2].ToString();

        IDrawable drawable = new CellRegion(SplitWall);

        if (topLeftGroupNr != topRightGroupNr &&
            bottomLeftGroupNr != bottomRightGroupNr &&
            topLeftGroupNr == bottomLeftGroupNr &&
            topRightGroupNr == bottomRightGroupNr)
        {
            return new CellRegion(VerticalWall);
        }

        if (topLeftGroupNr == topRightGroupNr &&
            bottomLeftGroupNr == bottomRightGroupNr &&
            topLeftGroupNr != bottomLeftGroupNr &&
            topRightGroupNr != bottomRightGroupNr)
        {
            return new CellRegion(HorizontalWall);
        }

        if (topLeftGroupNr == bottomRightGroupNr &&
            topRightGroupNr == bottomLeftGroupNr)
        {
            return new CellRegion(EmptyDrawing);
        }

        return drawable;
    }

    private IDrawable VerticalSeparationDrawing(int y, int x)
    {
        if (x >= ColumnSize) throw new ArgumentException($"Sudoku size is invalid");

        string leftGroupNr = RawCells2D[y, x][2].ToString();
        string rightGroupNr = RawCells2D[y, x + 1][2].ToString();

        if (leftGroupNr != rightGroupNr)
        {
            return new CellRegion(VerticalWall);
        }

        return new CellRegion(EmptyDrawing);
    }

    private IDrawable HorizontalSeparationDrawing(int y, int x)
    {
        if (x >= ColumnSize) throw new ArgumentException($"Sudoku size is invalid");

        string topGroupNr = RawCells2D[y, x][2].ToString();
        string bottomGroupNr = RawCells2D[y + 1, x][2].ToString();

        if (topGroupNr != bottomGroupNr)
        {
            return new CellRegion(HorizontalWall);
        }

        return new CellRegion(EmptyDrawing);
    }

    private IDrawable DefaultHorizontalWalls(bool isLast)
    {
        EmptyRegion jigsawGroup = new EmptyRegion();

        jigsawGroup.Add(new CellRegion(SplitWall));

        for (int x = 0; x < ColumnSize; x++)
        {
            jigsawGroup.Add(new CellRegion(HorizontalWall));

            if (x != ColumnSize - 1)
            {
                int y = isLast ? RowSize - 1 : 0;

                string topLeftGroupNr = RawCells2D[y, x][2].ToString();
                string topRightGroupNr = RawCells2D[y, x + 1][2].ToString();

                if (topLeftGroupNr == topRightGroupNr)
                {
                    jigsawGroup.Add(new CellRegion(HorizontalWall));
                }
                else
                {
                    jigsawGroup.Add(new CellRegion(SplitWall));
                }
            }
        }

        jigsawGroup.Add(new CellRegion(SplitWall));

        return new RowRegion(jigsawGroup);
    }


    private string[,] ConvertRaw2DArray(string[] cells)
    {
        string[,] RawCells2D = new string[RowSize, ColumnSize];

        for (int i = 0; i < CellSize; i++)
        {
            string value = cells[i];
            int row = i / RowSize;
            int col = i % ColumnSize;

            RawCells2D[row, col] = value;
        }

        return RawCells2D;
    }

    private Cell[,] Convert2DArray(Cell[] cells)
    {
        Cell[,] RawCells2D = new Cell[RowSize, ColumnSize];

        for (int i = 0; i < CellSize; i++)
        {
            Cell value = cells[i];
            int row = i / RowSize;
            int col = i % ColumnSize;

            RawCells2D[row, col] = value;
        }

        return RawCells2D;
    }

    private bool IsLastIteration(int size, int iteration) => size == iteration;
}