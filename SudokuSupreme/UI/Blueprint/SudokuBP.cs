using Presentation.Draw;
using Presentation.Drawable.Board;
using Presentation.Drawable.Region;

namespace Presentation.Blueprint;

public class SudokuBP : IBlueprint
{
    private const int RowSize = 9;
    private const int GroupSize = 3;
    private const int CellSize = 81;

    public IDrawable Generate(char[] cells)
    {
        if (cells == null || cells.Length != CellSize) throw new ArgumentException($"Sudoku amount is invalid");

        Row[] rows = new Row[RowSize];
        int cellIndex = 0;

        for (int row = 0; row < RowSize; row++)
        {
            Group[] group = new Group[GroupSize];

            for (int groupColumn = 0; groupColumn < GroupSize; groupColumn++)
            {
                group[groupColumn] = new Group(new IDrawable[] {
                    new Cell(cells[cellIndex++]),
                    new Cell(cells[cellIndex++]),
                    new Cell(cells[cellIndex++])
                });
            }

            Grid grid = new Grid(group);
            rows[row] = new Row(grid);

        }

        return new Sudoku(rows);
    }
}