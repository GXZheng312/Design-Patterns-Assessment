using Logic.Grid;
using NUnit.Framework;

namespace Tests.Validation;

[TestFixture]
public class SamuraiValidateTests
{
    [Test]
    public void ValidSamuraiBoard_ShouldReturnTrue()
    {
        List<int[,]> grid = new()
        {
            new int[,]
            {
            },
            new int[,]
            {
            },
            new int[,]
            {
            },
            new int[,]
            {
            },
            new int[,]
            {
            }
        };

        List<Cell> cells = new();
        List<Group> rows = new();
        List<Group> columns = new();
        List<Group> groups = new();

        SamuraiBoard board = new SamuraiBoard(cells, groups, rows, columns);
        Assert.True(board.Validate());
    }
}