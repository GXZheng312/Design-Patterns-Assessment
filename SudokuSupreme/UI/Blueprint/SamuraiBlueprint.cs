using Presentation.Draw;
using Presentation.Drawable.Board;
using Presentation.Drawable.Region;

namespace Presentation.Blueprint
{
    public class SamuraiBlueprint : IBlueprint
    {
        private const int DefaultSudokuSize = 81;
        private const int SamuraiSudokuSize = DefaultSudokuSize * 5;

        private string[] Cells { get; set; } = new string[SamuraiSudokuSize];

        private string EmptyDrawing => ((char)DrawingCharacter.Empty).ToString();
        private string HorizontalWall => ((char)DrawingCharacter.HorizontalWall).ToString();
        private string SplitWall => ((char)DrawingCharacter.SplitWall).ToString();

        public IDrawable Generate(string[] cells)
        {
            if (cells == null || cells.Length != SamuraiSudokuSize)
            {
                throw new ArgumentException("Invalid Sudoku amount");
            }

            Cells = cells;

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
            return new EmptyGrid(new IDrawable[]
            {
                SamuraiRow(ref leftIndex, ref middleIndex, ref rightIndex),
                SamuraiRow(ref leftIndex, ref middleIndex, ref rightIndex),
                SamuraiRow(ref leftIndex, ref middleIndex, ref rightIndex),
            });
        }

        private IDrawable SamuraiRow(ref int leftIndex, ref int middleIndex, ref int rightIndex)
        {
            return new Row(new IDrawable[]
            {
                SudokuSizeGrid(ref leftIndex),
                CenterSudokuGroup(ref middleIndex),
                SudokuSizeGrid(ref rightIndex),
            });
        }

        private IDrawable NormalSectionRows(ref int leftIndex, ref int rightIndex)
        {
            return new EmptyGrid(new IDrawable[]
            {
                NormalRow(ref leftIndex, ref rightIndex),
                NormalRow(ref leftIndex, ref rightIndex),
                NormalRow(ref leftIndex, ref rightIndex),
            });
        }

        private IDrawable NormalRow(ref int leftIndex, ref int rightIndex)
        {
            return new Row(new IDrawable[]
            {
                SudokuSizeGrid(ref leftIndex),
                EmptyGroup(),
                SudokuSizeGrid(ref rightIndex),
            });
        }

        private IDrawable MiddleRow(ref int thirdGroupIndex)
        {
            return new Row(new IDrawable[]
            {
                new Cell(EmptyDrawing),
                EmptyGroup(),
                new Cell(EmptyDrawing),
                EmptyGroup(),
                SudokuSizeGrid(ref thirdGroupIndex),
                EmptyGroup(),
                new Cell(EmptyDrawing),
                EmptyGroup(),
                new Cell(EmptyDrawing),
            });
        }

        private IDrawable MiddleSectionRows(ref int thirdGroupIndex)
        {
            return new EmptyGrid(new IDrawable[]
            {
                MiddleRow(ref thirdGroupIndex),
                MiddleRow(ref thirdGroupIndex),
                MiddleRow(ref thirdGroupIndex),
            });
        }

        private IDrawable SamuraiWallsRow()
        {
            return new Row(new IDrawable[]
            {
                SudokuSizeHorizontalWalls(),
                HorizontalWallGroup(),
                SudokuSizeHorizontalWalls(),
            });
        }

        private IDrawable HorizontalWallsRow()
        {
            return new Row(new IDrawable[]
            {
                SudokuSizeHorizontalWalls(),
                EmptyGroup(),
                SudokuSizeHorizontalWalls(),
            });
        }

        private IDrawable SudokuSizeGrid(ref int index)
        {
            return new Grid(new IDrawable[]
            {
                CreateGroup(ref index),
                CreateGroup(ref index),
                CreateGroup(ref index),
            });
        }

        private IDrawable CenterSudokuGroup(ref int index)
        {
            index += 3;

            IDrawable group = new EmptyGrid(new IDrawable[]
            {
                new Cell(Cells[index++]),
                new Cell(Cells[index++]),
                new Cell(Cells[index++])
            });

            index += 3;

            return group;
        }

        private IDrawable SudokuSizeHorizontalWalls()
        {
            return new EmptyGrid(new IDrawable[]
            {
                new Cell(SplitWall),
                HorizontalWallGroup(),
                new Cell(SplitWall),
                HorizontalWallGroup(),
                new Cell(SplitWall),
                HorizontalWallGroup(),
                new Cell(SplitWall),
            });
        }

        private IDrawable EmptyGroup()
        {
            return new EmptyGrid(new IDrawable[]
            {
                new Cell(EmptyDrawing),
                new Cell(EmptyDrawing),
                new Cell(EmptyDrawing)
            });
        }

        private IDrawable HorizontalWallGroup()
        {
            return new EmptyGrid(new IDrawable[]
            {
                new Cell(HorizontalWall),
                new Cell(HorizontalWall),
                new Cell(HorizontalWall),
            });
        }

        private IDrawable CreateGroup(ref int index)
        {
            return new Group(new IDrawable[]
            {
                new Cell(Cells[index++]),
                new Cell(Cells[index++]),
                new Cell(Cells[index++])
            });
        }
    }
}
