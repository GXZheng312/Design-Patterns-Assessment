using Logic.Grid;

namespace Logic.Serializer.Serialize;

public class SudokuSerialize : ISerialize
{
    public string[] Serialize(Board sudoku)
    {
        return sudoku.Cells.Select(c => c.Number.ToString()).ToArray();
    }
}

