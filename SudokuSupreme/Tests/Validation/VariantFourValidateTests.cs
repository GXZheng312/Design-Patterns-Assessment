using Logic.Grid.board;
using NUnit.Framework;
using Tests.Validation.Builders;

namespace Tests.Validation;

[TestFixture]
public class VariantFourValidateTests
{
    [Test]
    public void ValidVariantFourBoard_ShouldReturnTrue()
    {
        int[,] grid =
        {
            { 1, 2, 3, 4 },
            { 3, 4, 1, 2 },
            { 4, 1, 2, 3 },
            { 2, 3, 4, 1 }
        };

        VariantFourBoard? board = TestNormalSudokuBoardBuilder.Build<VariantFourBoard>(grid, 4, 4, 2, 2);
        Assert.True(board?.Validate());
    }
    
    [Test]
    public void InvalidVariantFourBoard_ShouldReturnFalse()
    {
        int[,] grid =
        {
            { 1, 2, 3, 4 },
            { 2, 3, 4, 1 },
            { 3, 4, 1, 2 },
            { 4, 1, 2, 3 }
        };

        VariantFourBoard? board = TestNormalSudokuBoardBuilder.Build<VariantFourBoard>(grid, 4, 4, 2, 2);
        Assert.False(board?.Validate());
    }
    
    [Test]
    public void EmptyVariantFourBoard_ShouldReturnFalse()
    {
        int[,] grid =
        {
            { 0, 2, 0, 3 },
            { 1, 0, 4, 2 },
            { 3, 0, 1, 0 },
            { 0, 1, 2, 0 }
        };

        VariantFourBoard? board = TestNormalSudokuBoardBuilder.Build<VariantFourBoard>(grid, 4, 4, 2, 2);
        Assert.False(board?.Validate());
    }
}