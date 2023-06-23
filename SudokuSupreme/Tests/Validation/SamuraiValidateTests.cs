using Logic.Grid;
using NUnit.Framework;
using Tests.Validation.Builders;

namespace Tests.Validation;

[TestFixture]
public class SamuraiValidateTests
{
    [Test]
    public void ValidSamuraiBoard_ShouldReturnTrue()
    {
        List<int[,]> grid = new()
        {
            new[,]
            {
                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                { 4, 5, 6, 7, 8, 9, 1, 2, 3 },
                { 7, 8, 9, 1, 2, 3, 4, 5, 6 },
                { 2, 3, 4, 5, 6, 7, 8, 9, 1 },
                { 5, 6, 7, 8, 9, 1, 2, 3, 4 },
                { 8, 9, 1, 2, 3, 4, 5, 6, 7 },
                { 9, 1, 2, 3, 4, 5, -1, -1, -1 },
                { 3, 4, 5, 6, 7, 8, -1, -1, -1 },
                { 6, 7, 8, 9, 1, 2, -1, -1, -1 }
            },
            new[,]
            {
                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                { 4, 5, 6, 7, 8, 9, 1, 2, 3 },
                { 7, 8, 9, 1, 2, 3, 4, 5, 6 },
                { 2, 3, 4, 5, 6, 7, 8, 9, 1 },
                { 5, 6, 7, 8, 9, 1, 2, 3, 4 },
                { 8, 9, 1, 2, 3, 4, 5, 6, 7 },
                { -1, -1, -1, 3, 4, 5, 6, 7, 8 },
                { -1, -1, -1, 6, 7, 8, 9, 1, 2 },
                { -1, -1, -1, 9, 1, 2, 3, 4, 5 }
            },
            new[,]
            {
                { 6, 7, 8, 9, 1, 2, 3, 4, 5 },
                { 9, 1, 2, 3, 4, 5, 6, 7, 8 },
                { 3, 4, 5, 6, 7, 8, 9, 1, 2 },
                { 7, 8, 9, 1, 2, 3, 4, 5, 6 },
                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                { 4, 5, 6, 7, 8, 9, 1, 2, 3 },
                { 8, 9, 1, 2, 3, 4, 5, 6, 7 },
                { 2, 3, 4, 5, 6, 7, 8, 9, 1 },
                { 5, 6, 7, 8, 9, 1, 2, 3, 4 }
            },
            new[,]
            {
                { 2, 3, 4, 5, 6, 7, -1, -1, -1 },
                { 5, 6, 7, 8, 9, 1, -1, -1, -1 },
                { 8, 9, 1, 2, 3, 4, -1, -1, -1 },
                { 9, 1, 2, 3, 4, 5, 6, 7, 8 },
                { 3, 4, 5, 6, 7, 8, 9, 1, 2 },
                { 6, 7, 8, 9, 1, 2, 3, 4, 5 },
                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                { 4, 5, 6, 7, 8, 9, 1, 2, 3 },
                { 7, 8, 9, 1, 2, 3, 4, 5, 6 }
            },
            new[,]
            {
                { -1, -1, -1, 8, 9, 1, 2, 3, 4 },
                { -1, -1, -1, 2, 3, 4, 5, 6, 7 },
                { -1, -1, -1, 5, 6, 7, 8, 9, 1 },
                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                { 4, 5, 6, 7, 8, 9, 1, 2, 3 },
                { 7, 8, 9, 1, 2, 3, 4, 5, 6 },
                { 9, 1, 2, 3, 4, 5, 6, 7, 8 },
                { 3, 4, 5, 6, 7, 8, 9, 1, 2 },
                { 6, 7, 8, 9, 1, 2, 3, 4, 5 }
            }
        };

        SamuraiBoard board = TestSamuraiSudokuBoardBuilder.Build(grid);
        Assert.True(board.Validate());
    }
}