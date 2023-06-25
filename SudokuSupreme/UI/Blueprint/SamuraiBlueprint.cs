using Logic;
using Presentation.Draw;
using Presentation.Drawable.Board;
using Presentation.Drawable.Region;

namespace Presentation.Blueprint
{
    public class SamuraiBlueprint : IBlueprint
    {
        private const int DefaultSudokuSize = 81;
        private const int CornerGridSize = 9 * 4;
        private const int SamuraiSudokuSize = DefaultSudokuSize * 5 - CornerGridSize;

        private int SudokuSize = 9;
        private int SamuraiSize = 21;
        private int OffsetMiddle = 6;

        private int YPos = 1;
        private int XPos = 1;

        private string EmptyDrawing => ((char)DrawingCharacter.Empty).ToString();
        private string HorizontalWall => ((char)DrawingCharacter.HorizontalWall).ToString();
        private string SplitWall => ((char)DrawingCharacter.SplitWall).ToString();

        private List<Cell> Cells { get; set; } = new List<Cell>();
        public Cell SelectedCell { get; set; }

        private void loadData(string[] rawCells, IBoard board, string? mode)
        {
            if (rawCells == null || rawCells.Length != SamuraiSudokuSize)
            {
                throw new ArgumentException("Invalid Sudoku amount");
            }

            this.Cells = board.Cells;
            this.SelectedCell = board.SelectedCell;
            this.XPos = 1;
            this.YPos = 1;
        }

        public IDrawable Generate(string[] rawCells, IBoard board, string? mode)
        {
            loadData(rawCells, board, mode);

            return new Samurai(new IDrawable[]
            {
                HorizontalWallsRow(),
                NormalSectionRows(),
                HorizontalWallsRow(),
                NormalSectionRows(),
                SamuraiWallsRow(),
                SamuraiSectionRows(),
                SamuraiWallsRow(),
                MiddleSectionRows(),
                SamuraiWallsRow(),
                SamuraiSectionRows(),
                SamuraiWallsRow(),
                NormalSectionRows(),
                HorizontalWallsRow(),
                NormalSectionRows(),
                HorizontalWallsRow()
            });
        }

        private IDrawable SamuraiSectionRows()
        {
            return new EmptyRegion(new IDrawable[]
            {
                SamuraiRow(),
                SamuraiRow(),
                SamuraiRow(),
            });
        }

        private IDrawable SamuraiRow()
        {
            return new RowRegion(new IDrawable[]
            {
                SudokuSizeGrid(),
                CenterSudokuGroup(),
                SudokuSizeGrid(),
            });
        }

        private IDrawable NormalSectionRows()
        {
            return new EmptyRegion(new IDrawable[]
            {
                NormalRow(),
                NormalRow(),
                NormalRow(),
            });
        }

        private IDrawable NormalRow()
        {
            return new RowRegion(new IDrawable[]
            {
                SudokuSizeGrid(),
                EmptyGroup(),
                SudokuSizeGrid(),
            });
        }

        private IDrawable MiddleRow()
        {
            return new RowRegion(new IDrawable[]
            {
                new CellRegion(EmptyDrawing),
                EmptyGroup(),
                new CellRegion(EmptyDrawing),
                EmptyGroup(),
                SudokuSizeGrid(),
                EmptyGroup(),
                new CellRegion(EmptyDrawing),
                EmptyGroup(),
                new CellRegion(EmptyDrawing),
            });
        }

        private IDrawable MiddleSectionRows()
        {
            return new EmptyRegion(new IDrawable[]
            {
                MiddleRow(),
                MiddleRow(),
                MiddleRow(),
            });
        }

        private IDrawable SamuraiWallsRow()
        {
            return new RowRegion(new IDrawable[]
            {
                SudokuSizeHorizontalWalls(),
                HorizontalWallGroup(),
                SudokuSizeHorizontalWalls(),
            });
        }

        private IDrawable HorizontalWallsRow()
        {
            return new RowRegion(new IDrawable[]
            {
                SudokuSizeHorizontalWalls(),
                EmptyGroup(),
                SudokuSizeHorizontalWalls(),
            });
        }

        private IDrawable SudokuSizeGrid()
        {
            return new GridRegion(new IDrawable[]
            {
                CreateGroup(),
                CreateGroup(),
                CreateGroup(),
            });
        }

        private IDrawable CenterSudokuGroup()
        {
            //index += 3;

            IDrawable group = new EmptyRegion(new IDrawable[]
            {
                new CellRegion(GetCellPosition(), this.SelectedCell),
                new CellRegion(GetCellPosition(), this.SelectedCell),
                new CellRegion(GetCellPosition(), this.SelectedCell),
            });

            // index += 3;

            return group;
        }

        private IDrawable SudokuSizeHorizontalWalls()
        {
            return new EmptyRegion(new IDrawable[]
            {
                new CellRegion(SplitWall),
                HorizontalWallGroup(),
                new CellRegion(SplitWall),
                HorizontalWallGroup(),
                new CellRegion(SplitWall),
                HorizontalWallGroup(),
                new CellRegion(SplitWall),
            });
        }

        private IDrawable EmptyGroup()
        {
            return new EmptyRegion(new IDrawable[]
            {
                new CellRegion(EmptyDrawing),
                new CellRegion(EmptyDrawing),
                new CellRegion(EmptyDrawing)
            });
        }

        private IDrawable HorizontalWallGroup()
        {
            return new EmptyRegion(new IDrawable[]
            {
                new CellRegion(HorizontalWall),
                new CellRegion(HorizontalWall),
                new CellRegion(HorizontalWall),
            });
        }

        private IDrawable CreateGroup()
        {
            return new GroupRegion(new IDrawable[]
            {
                new CellRegion(GetCellPosition(), this.SelectedCell),
                new CellRegion(GetCellPosition(), this.SelectedCell),
                new CellRegion(GetCellPosition(), this.SelectedCell)
            });
        }

        private Cell GetCellPosition()
        {
            int x = GetXPos();
            int y = GetYPos();

            Cell cell = Cells.Find(cell => cell.X == x && cell.Y == y);

            return cell;
        }

        private int GetXPos()
        {
            if (XPos > SamuraiSize) //end of the X, X > 21
            {
                YPos++; // go to new row
                XPos = 1; // start new X
            }

            if (YPos > SudokuSize && YPos <= SamuraiSize - SudokuSize) //is in between sudoku size rows 
            {
                if (XPos <= OffsetMiddle)
                {
                    XPos = OffsetMiddle + 1; //go to the center sudoku positions
                }
                else if (XPos > SamuraiSize - OffsetMiddle)
                {
                    if (YPos >= SamuraiSize - SudokuSize)
                    {
                        YPos++; // next row
                        XPos = 1;
                    }
                    else
                    {
                        YPos++; // next row
                        XPos = OffsetMiddle + 1;
                    }
                }
            }


            if (YPos <= OffsetMiddle || YPos > SamuraiSize - OffsetMiddle)
            {
                if (XPos > SudokuSize && XPos <= SamuraiSize - SudokuSize) //is in empty offset position
                {
                    XPos = SamuraiSize - SudokuSize + 1; //go out of the offset
                }
            }

            return XPos++;
        }

        private int GetYPos()
        {
            return YPos;
        }
    }
}