using Logic.Grid;

namespace Logic.Serializer.Serialize;

public class JigsawSerialize : ISerialize
{
    public string[] Serialize(Board sudoku)
    {
        string testData = "SumoCueV1=1J0=1J0=1J0=1J1=1J2=1J2=1J2=1J2=1J2=2J3=2J0=2J1=2J1=2J2=2J2=2J4=2J4=2J4=3J3=3J0=3J1=3J1=3J2=3J2=3J5=3J6=3J4=4J3=4J0=4J1=4J1=4J5=4J5=4J5=4J6=4J4=5J3=5J0=5J1=5J1=5J5=5J7=5J7=5J6=5J4=6J3=6J0=6J5=6J5=6J5=6J7=6J7=6J6=6J4=7J3=7J0=7J5=7J8=7J8=7J7=7J7=7J6=7J4=8J3=8J3=8J3=8J8=8J8=8J7=8J7=8J6=8J4=9J8=9J8=9J8=9J8=9J8=9J7=9J6=9J6=9J6";

        testData = testData.Substring(testData.IndexOf('=') + 1);

        return testData.Split('=');
    }
}

