namespace Logic.Serializer.Serialize;

public class VariantSixSerialize : ISerialize
{
    public char[] Serialize(Board sudoku)
    {
        string testData = "003010560320054203206450012045040100";
        return testData.ToCharArray();
    }
}

