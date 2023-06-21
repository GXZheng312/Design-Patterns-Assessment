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

    public IDrawable Generate(string[] cells)
    {
        if (cells == null || cells.Length != Size) throw new ArgumentException($"Sudoku amount is invalid");
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

    private IDrawable CreateRow(string[] cells)
    {
        return new Row(
            new Grid(new IDrawable[]
            {
                CreateGroup(cells),
                CreateGroup(cells),
            })
        );
    }

    private IDrawable CreateGroup(string[] cells)
    {
        return new Group(new IDrawable[]
        {
            new Cell(cells[CellIndex++]),
            new Cell(cells[CellIndex++])
        });
    }

    private Row RowHorizontalWalls()
    {
        return new Row(new IDrawable[]
        {
            new Cell(SplitWall),
            new Cell(HorizontalWall),
            new Cell(HorizontalWall),
            new Cell(SplitWall),
            new Cell(HorizontalWall),
            new Cell(HorizontalWall),
            new Cell(SplitWall),
        });
    }
}