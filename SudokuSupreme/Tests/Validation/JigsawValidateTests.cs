using Logic.Grid;
using NUnit.Framework;

namespace Tests.Validation;

[TestFixture]
public class JigsawValidateTests
{
    [Test]
    public void ValidJigsawBoard_ShouldReturnTrue()
    {
        Dictionary<int, List<int[]>> grid = new()
        {
            
        };

        List<Cell> cells = new();
        List<Group> rows = new();
        List<Group> columns = new();
        List<Group> groups = new();

        JigsawBoard board = new JigsawBoard(cells, groups, rows, columns);
        Assert.True(board.Validate());
    }
}