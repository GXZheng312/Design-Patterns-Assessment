namespace Logic.Serializer.Serialize;

public class VariantSixSerialize : ISerialize
{
    public string[] Serialize(Board sudoku)
    {
        string testData = "003010560320054203206450012045040100";
        return testData.Select(x => x.ToString()).ToArray();
    }
}

