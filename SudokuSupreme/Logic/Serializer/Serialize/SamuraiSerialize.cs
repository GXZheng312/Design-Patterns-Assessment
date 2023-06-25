using Logic.Model;

namespace Logic.Serializer.Serialize;

public class SamuraiSerialize : ISerialize
{
    public string[] Serialize(Board sudoku)
    {
        return sudoku.Cells.Select(c => c.Number.ToString()).ToArray();
    }
}