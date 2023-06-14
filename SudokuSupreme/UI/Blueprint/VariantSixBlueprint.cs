using Presentation.Draw;
using Presentation.Drawable.Board;
using Presentation.Drawable.Region;

namespace Presentation.Blueprint;

public class VariantSixBlueprint : IBlueprint
{
    private const int RowSize = 9;
    private const int GroupSize = 3;
    private const int CellSize = 81;
    private int CellIndex { get; set; }
    public IDrawable Generate(char[] cells)
    {
        throw new NotImplementedException();
    }



}