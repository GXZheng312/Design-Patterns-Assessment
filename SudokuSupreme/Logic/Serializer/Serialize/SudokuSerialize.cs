namespace Logic.Serializer.Serialize;

public class SudokuSerialize : ISerialize
{
    public string[] Serialize(Board sudoku)
    {
        string testData = "700509001000000000150070063003904100000050000002106400390040076000000000600201004";
        return testData.Select(c => c.ToString()).ToArray();
    }
}

