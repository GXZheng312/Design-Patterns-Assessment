using Logic.Grid;
using Presentation.Draw;
using Presentation.Drawable.Board;
using Presentation.Drawable.Region;

namespace Presentation.Blueprint;

public class SudokuBlueprint : IBlueprint
{
    private const int GroupColumnSize = 3;
    private const int GroupRowSize = 3;

    private const int GridColumnSize = 3;
    private const int GridRowSize = 3;

    private const int TotalRowCellAmount = GridColumnSize * GroupColumnSize;
    private const int Size = TotalRowCellAmount * GroupRowSize * GridRowSize;

    private int CellIndex { get; set; } = 0;

    private string HorizontalWall = ((char)DrawingCharacter.HorizontalWall).ToString();
    private string SplitWall = ((char)DrawingCharacter.SplitWall).ToString();

    public IDrawable Generate(string[] rawCells, List<Cell> cells, string? mode, Cell? selectedCell)
    {
        if (cells == null || rawCells.Length != Size) throw new ArgumentException($"Sudoku amount is invalid");
        this.CellIndex = 0;

        return new VariantSix(new IDrawable[] {
            RowHorizontalWalls(),
            CreateRow(cells, selectedCell),
            CreateRow(cells, selectedCell),
            CreateRow(cells, selectedCell),
            RowHorizontalWalls(),
            CreateRow(cells, selectedCell),
            CreateRow(cells, selectedCell),
            CreateRow(cells, selectedCell),
            RowHorizontalWalls(),
            CreateRow(cells, selectedCell),
            CreateRow(cells, selectedCell),
            CreateRow(cells, selectedCell),
            RowHorizontalWalls(),
        });
    }

    private IDrawable CreateRow(List<Cell> cells, Cell? selectedCell)
    {
        return new RowRegion(
            new GridRegion(new IDrawable[]
            {
                CreateGroup(cells, selectedCell),
                CreateGroup(cells, selectedCell),
                CreateGroup(cells, selectedCell),
            })
        );
    }

    private IDrawable CreateGroup(List<Cell> cells, Cell? selectedCell)
    {
        return new GroupRegion(new IDrawable[]
        {
            new CellRegion(cells[CellIndex++], selectedCell),
            new CellRegion(cells[CellIndex++], selectedCell),
            new CellRegion(cells[CellIndex++], selectedCell)
        });
    }

    private IDrawable RowHorizontalWalls()
    {
        return new RowRegion(new IDrawable[]
        {
            new CellRegion(SplitWall),
            new CellRegion(HorizontalWall),
            new CellRegion(HorizontalWall),
            new CellRegion(HorizontalWall),
            new CellRegion(SplitWall),
            new CellRegion(HorizontalWall),
            new CellRegion(HorizontalWall),
            new CellRegion(HorizontalWall),
            new CellRegion(SplitWall),
            new CellRegion(HorizontalWall),
            new CellRegion(HorizontalWall),
            new CellRegion(HorizontalWall),
            new CellRegion(SplitWall),
        });
    }
}