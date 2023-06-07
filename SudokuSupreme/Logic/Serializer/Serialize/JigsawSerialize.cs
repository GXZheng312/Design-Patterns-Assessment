namespace Logic.Serializer.Serialize;

public class JigsawSerialize : ISerialize
{
    public string Serialize(Sudoku sudoku)
    {
        return "jigsaw";
    }
}

