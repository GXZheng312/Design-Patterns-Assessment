using Logic.Grid;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public class JigsawValidateTests
{
    [Test]
    public void ValidJigsawBoard_ShouldReturnTrue()
    {
        int[,] grid =
        {
            { 2, 8, 9, 1, 3, 6, 7, 4, 5 },
            { 9, 7, 5, 4, 8, 3, 1, 2, 6 },
            { 3, 2, 8, 9, 7, 5, 4, 6, 1 },
            { 5, 4, 1, 6, 9, 2, 3, 8, 7 },
            { 6, 5, 3, 8, 4, 1, 9, 7, 2 },
            { 8, 1, 4, 5, 2, 7, 6, 9, 3 },
            { 4, 6, 7, 3, 5, 8, 2, 1, 9 },
            { 7, 9, 6, 2, 1, 4, 5, 3, 8 },
            { 1, 3, 2, 7, 6, 9, 8, 5, 4 }
        };

        List<Cell> cells = new();
        List<Group> rows = new();
        List<Group> columns = new();
        List<Group> groups = new();

        JigsawBoard board = new JigsawBoard(cells, groups, rows, columns);
        Assert.True(board.Validate());
    }
}