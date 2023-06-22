using Logic.Grid;
using Presentation.Draw;
using Presentation.Drawable.Board;
using Presentation.Drawable.Region;
using System.Drawing;
using System.Runtime.CompilerServices;

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

    private string[,] Cells2D { get; set; }

    public IDrawable Generate(string[] rawCells, List<Cell> cells, string? mode, Cell? selectedCell)
    {
        if (rawCells == null || rawCells.Length != CellSize) throw new ArgumentException($"Sudoku amount is invalid");

        Cells2D = Convert2DArray(rawCells);
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
            string value = Cells2D[y, x][0].ToString();

            jigsawGroup.Add(new CellRegion(value));

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

        string topLeftGroupNr = Cells2D[y, 0][2].ToString();
        string bottomLeftGroupNr = Cells2D[y + 1, 0][2].ToString();

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
                topLeftGroupNr = Cells2D[y, x][2].ToString();
                bottomLeftGroupNr = Cells2D[y + 1, x][2].ToString();

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

        string topLeftGroupNr = Cells2D[y, x][2].ToString();
        string bottomLeftGroupNr = Cells2D[y + 1, x][2].ToString();

        string topRightGroupNr = Cells2D[y, x + 1][2].ToString();
        string bottomRightGroupNr = Cells2D[y + 1, x + 1][2].ToString();

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

        string leftGroupNr = Cells2D[y, x][2].ToString();
        string rightGroupNr = Cells2D[y, x + 1][2].ToString();

        if (leftGroupNr != rightGroupNr)
        {
            return new CellRegion(VerticalWall);
        }

        return new CellRegion(EmptyDrawing);
    }

    private IDrawable HorizontalSeparationDrawing(int y, int x)
    {
        if (x >= ColumnSize) throw new ArgumentException($"Sudoku size is invalid");

        string topGroupNr = Cells2D[y, x][2].ToString();
        string bottomGroupNr = Cells2D[y + 1, x][2].ToString();

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

            if(x != ColumnSize - 1)
            {
                int y = isLast ? RowSize - 1 : 0;

                string topLeftGroupNr = Cells2D[y, x][2].ToString();
                string topRightGroupNr = Cells2D[y, x + 1][2].ToString();

                if(topLeftGroupNr == topRightGroupNr)
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


    private string[,] Convert2DArray(string[] cells)
    {
        string[,] cells2D = new string[RowSize,ColumnSize];

        for (int i = 0; i < CellSize; i++)
        {
            string value = cells[i];
            int row = i / RowSize;
            int col = i % ColumnSize;

            cells2D[row, col] = value;
        }

        return cells2D;
    }

    private bool IsLastIteration(int size, int iteration) => size == iteration;


}