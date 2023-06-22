using Logic.Grid;
using Presentation.Draw;
using Presentation.Drawable.Board;
using Presentation.Drawable.Region;

namespace Presentation.Blueprint;

public class VariantFourBlueprint : IBlueprint
{
    private const int GroupSize = 2;
    private const int TotalRowAmount = GroupSize * GroupSize;
    private const int Size = TotalRowAmount * TotalRowAmount;

    private int CellIndex { get; set; } = 0;

    private string HorizontalWall = ((char)DrawingCharacter.HorizontalWall).ToString();
    private string SplitWall = ((char)DrawingCharacter.SplitWall).ToString();

    public IDrawable Generate(string[] rawCells, List<Cell> cells, string? mode, Cell? selectedCell)
    {
        if (rawCells == null || rawCells.Length != Size) throw new ArgumentException($"Sudoku amount is invalid");
        this.CellIndex = 0;

        return new VariantFour(new IDrawable[] {
            RowHorizontalWalls(),
            CreateRow(cells),
            CreateRow(cells),
            RowHorizontalWalls(),
            CreateRow(cells),
            CreateRow(cells),
            RowHorizontalWalls(),
        });
    }

    private IDrawable CreateRow(List<Cell> cells)
    {
        return new RowRegion(
            new GridRegion(new IDrawable[]
            {
                CreateGroup(cells),
                CreateGroup(cells),
            })
        );
    }

    private IDrawable CreateGroup(List<Cell> cells)
    {
        return new GroupRegion(new IDrawable[]
        {
            new CellRegion(cells[CellIndex++]),
            new CellRegion(cells[CellIndex++])
        });
    }

    private RowRegion RowHorizontalWalls()
    {
        return new RowRegion(new IDrawable[]
        {
            new CellRegion(SplitWall),
            new CellRegion(HorizontalWall),
            new CellRegion(HorizontalWall),
            new CellRegion(SplitWall),
            new CellRegion(HorizontalWall),
            new CellRegion(HorizontalWall),
            new CellRegion(SplitWall),
        });
    }
}