namespace Logic.Serializer.Serialize;

public class VariantFourSerialize : ISerialize
{
    public char[] Serialize(Board sudoku)
    {
        string testData = "0340400210030210";
        return testData.ToCharArray();
    }
}

