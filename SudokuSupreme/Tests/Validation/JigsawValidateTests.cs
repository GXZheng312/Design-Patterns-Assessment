using Logic.Grid;
using NUnit.Framework;

namespace Tests.Validation;

[TestFixture]
public class JigsawValidateTests
{
    [Test]
    public void ValidJigsawBoard_ShouldReturnTrue()
    {
        string celNumbers = "289136745975483126328975461541692387653841972814527693467358219796214538132769854";
        string grpNumbers = "000000011220033331222333341222355641255556641756666641755776441777784441788888888";

        List<Cell> cells = new();
        List<Group> rows = new();
        List<Group> columns = new();
        List<Group> groups = new();

        for (int i = 0; i < celNumbers.Length; i++)
        {
            int value = celNumbers[i];
            int groupNumber = grpNumbers[i];
            int x = i % 9;
            int y = i / 9;
            
            Cell cell = new Cell(value, x, y);
        }

        JigsawBoard board = new JigsawBoard(cells, groups, rows, columns);
        Assert.True(board.Validate());
    }
}