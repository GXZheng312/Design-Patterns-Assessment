using Logic.Grid;
using Logic.Model;
using Presentation.Draw;
using Presentation.Drawable.Board;
using Presentation.Drawable.Region;
using System.Runtime.CompilerServices;

namespace Presentation.Blueprint
{
    public class SamuraiBlueprint : IBlueprint
    {
        private const int DefaultSudokuSize = 81;
        private const int SamuraiSudokuSize = DefaultSudokuSize * 5;

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

        }

        public IDrawable Generate(string[] rawCells, IBoard board, string? mode)
        {
            loadData(rawCells, board, mode);

            int firstGroupIndex = DefaultSudokuSize * 0;
            int secondGroupIndex = DefaultSudokuSize * 1;
            int thirdGroupIndex = DefaultSudokuSize * 2;
            int fourthGroupIndex = DefaultSudokuSize * 3;
            int fifthGroupIndex = DefaultSudokuSize * 4;

            return new Samurai(new IDrawable[]
            {
                HorizontalWallsRow(),
                NormalSectionRows(ref firstGroupIndex, ref secondGroupIndex),
                HorizontalWallsRow(),
                NormalSectionRows(ref firstGroupIndex, ref secondGroupIndex),
                SamuraiWallsRow(),
                SamuraiSectionRows(ref firstGroupIndex, ref thirdGroupIndex, ref secondGroupIndex),
                SamuraiWallsRow(),
                MiddleSectionRows(ref thirdGroupIndex),
                SamuraiWallsRow(),
                SamuraiSectionRows(ref fourthGroupIndex, ref thirdGroupIndex, ref fifthGroupIndex),
                SamuraiWallsRow(),
                NormalSectionRows(ref fourthGroupIndex, ref fifthGroupIndex),
                HorizontalWallsRow(),
                NormalSectionRows(ref fourthGroupIndex, ref fifthGroupIndex),
                HorizontalWallsRow()
            });
        }

        private IDrawable SamuraiSectionRows(ref int leftIndex, ref int middleIndex, ref int rightIndex)
        {
            return new EmptyRegion(new IDrawable[]
            {
                SamuraiRow(ref leftIndex, ref middleIndex, ref rightIndex),
                SamuraiRow(ref leftIndex, ref middleIndex, ref rightIndex),
                SamuraiRow(ref leftIndex, ref middleIndex, ref rightIndex),
            });
        }

        private IDrawable SamuraiRow(ref int leftIndex, ref int middleIndex, ref int rightIndex)
        {
            return new RowRegion(new IDrawable[]
            {
                SudokuSizeGrid(ref leftIndex),
                CenterSudokuGroup(ref middleIndex),
                SudokuSizeGrid(ref rightIndex),
            });
        }

        private IDrawable NormalSectionRows(ref int leftIndex, ref int rightIndex)
        {
            return new EmptyRegion(new IDrawable[]
            {
                NormalRow(ref leftIndex, ref rightIndex),
                NormalRow(ref leftIndex, ref rightIndex),
                NormalRow(ref leftIndex, ref rightIndex),
            });
        }

        private IDrawable NormalRow(ref int leftIndex, ref int rightIndex)
        {
            return new RowRegion(new IDrawable[]
            {
                SudokuSizeGrid(ref leftIndex),
                EmptyGroup(),
                SudokuSizeGrid(ref rightIndex),
            });
        }

        private IDrawable MiddleRow(ref int thirdGroupIndex)
        {
            return new RowRegion(new IDrawable[]
            {
                new CellRegion(EmptyDrawing),
                EmptyGroup(),
                new CellRegion(EmptyDrawing),
                EmptyGroup(),
                SudokuSizeGrid(ref thirdGroupIndex),
                EmptyGroup(),
                new CellRegion(EmptyDrawing),
                EmptyGroup(),
                new CellRegion(EmptyDrawing),
            });
        }

        private IDrawable MiddleSectionRows(ref int thirdGroupIndex)
        {
            return new EmptyRegion(new IDrawable[]
            {
                MiddleRow(ref thirdGroupIndex),
                MiddleRow(ref thirdGroupIndex),
                MiddleRow(ref thirdGroupIndex),
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

        private IDrawable SudokuSizeGrid(ref int index)
        {
            return new GridRegion(new IDrawable[]
            {
                CreateGroup(ref index),
                CreateGroup(ref index),
                CreateGroup(ref index),
            });
        }

        private IDrawable CenterSudokuGroup(ref int index)
        {
            index += 3;

            IDrawable group = new EmptyRegion(new IDrawable[]
            {
                new CellRegion(Cells[index++], this.SelectedCell),
                new CellRegion(Cells[index++], this.SelectedCell),
                new CellRegion(Cells[index++], this.SelectedCell)
            });

            index += 3;

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

        private IDrawable CreateGroup(ref int index)
        {
            return new GroupRegion(new IDrawable[]
            {
                new CellRegion(Cells[index++], this.SelectedCell),
                new CellRegion(Cells[index++], this.SelectedCell),
                new CellRegion(Cells[index++], this.SelectedCell)
            });
        }
    }
}
