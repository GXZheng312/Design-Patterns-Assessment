using Logic.Model;

namespace Logic.Serializer.Serialize;

public class VariantFourSerialize : ISerialize
{
    public string[] Serialize(Board sudoku)
    {
        return sudoku.Cells.Select(c => c.Number.ToString()).ToArray();
    }
}