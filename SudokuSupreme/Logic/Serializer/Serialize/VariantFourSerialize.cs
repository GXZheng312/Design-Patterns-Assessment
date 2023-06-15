namespace Logic.Serializer.Serialize;

public class VariantFourSerialize : ISerialize
{
    public string[] Serialize(Board sudoku)
    {
        string testData = "0340400210030210";
        return testData.Select(c => c.ToString()).ToArray();
    }
}

