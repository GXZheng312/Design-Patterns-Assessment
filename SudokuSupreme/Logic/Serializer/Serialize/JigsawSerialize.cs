using Logic.Grid;

namespace Logic.Serializer.Serialize;

public class JigsawSerialize : ISerialize
{
    public string[] Serialize(Board sudoku)
    {
        string testData = "umoCueV1=1J0=1J0=1J0=2J1=3J2=3J2=3J2=3J2=3J2=4J3=1J0=2J1=2J1=3J2=3J2=5J4=5J4=5J4=4J3=1J0=2J1=2J1=3J2=3J2=6J5=7J6=5J4=4J3=1J0=2J1=2J1=6J5=6J5=6J5=7J6=5J4=4J3=1J0=2J1=2J1=6J5=8J7=8J7=7J6=5J4=4J3=1J0=6J5=6J5=6J5=8J7=8J7=7J6=5J4=4J3=1J0=6J5=9J8=9J8=8J7=8J7=7J6=5J4=4J3=4J3=4J3=9J8=9J8=8J7=8J7=7J6=5J4=9J8=9J8=9J8=9J8=9J8=8J7=7J6=7J6=7J6";

        testData = testData.Substring(testData.IndexOf('=') + 1);

        return testData.Split('=');
    }
}

