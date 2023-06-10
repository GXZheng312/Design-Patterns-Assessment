namespace Logic.Serializer.Serialize;

public class JigsawSerialize : ISerialize
{
    public char[] Serialize(Board sudoku)
    {
        string testData = "SumoCueV1=0J0=0J1=8J1=0J1=3J1=0J2=4J3=0J3=0J3=0J0=0J0=1J1=4J1=0J1=7J2=2J2=0J3=0J3=4J0=0J0=0J0=0J1=7J1=0J2=0J3=0J3=1J3=0J0=3J4=0J0=0J0=0J2=0J2=0J2=9J5=0J3=0J4=0J4=0J4=0J6=0J6=0J2=0J2=0J5=0J5=0J4=1J4=0J4=0J6=0J6=0J7=0J7=4J7=0J5=7J4=0J4=0J8=0J6=9J6=0J7=0J7=0J7=5J5=0J8=0J8=9J8=1J8=0J6=4J6=5J7=0J5=0J5=0J8=0J8=4J8=0J8=2J6=0J7=6J7=0J5=0J5";

        return testData.ToCharArray();
    }
}

