namespace Logic.Serializer.Serialize;

public class VariantFourSerialize : ISerialize
{
    public string Serialize(Sudoku sudoku)
    {
        return "4x4";
    }
}

