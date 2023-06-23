using Logic.Grid;
using NUnit.Framework;
using Tests.Validation.Builders;

namespace Tests.Validation;

[TestFixture]
public class VariantSixValidateTests
{
    [Test]
    public void ValidVariantSixBoard_ShouldReturnTrue()
    {
        int[,] grid =
        {
            { 1, 2, 3, 4, 5, 6 },
            { 4, 5, 6, 1, 2, 3 },
            { 2, 3, 4, 5, 6, 1 },
            { 5, 6, 1, 2, 3, 4 },
            { 3, 4, 5, 6, 1, 2 },
            { 6, 1, 2, 3, 4, 5 }
        };

        VariantSixBoard? board = TestNormalSudokuBoardBuilder.Build<VariantSixBoard>(grid, 6, 6, 3, 2);
        Assert.True(board?.Validate());
    }
    
    [Test]
    public void InvalidVariantSixBoard_ShouldReturnFalse()
    {
        int[,] grid =
        {
            { 1, 2, 3, 4, 5, 6 },
            { 2, 3, 4, 5, 6, 1 },
            { 3, 4, 5, 6, 1, 2 },
            { 4, 5, 6, 1, 2, 3 },
            { 5, 6, 1, 2, 3, 4 },
            { 6, 1, 2, 3, 4, 5 }
        };

        VariantSixBoard? board = TestNormalSudokuBoardBuilder.Build<VariantSixBoard>(grid, 6, 6, 3, 2);
        Assert.False(board?.Validate());
    }
    
    [Test]
    public void EmptyVariantSixBoard_ShouldReturnFalse()
    {
        int[,] grid =
        {
            { 0, 2, 0, 4, 0, 6 },
            { 4, 0, 0, 0, 0, 3 },
            { 0, 3, 0, 5, 0, 0 },
            { 5, 0, 1, 0, 0, 0 },
            { 0, 4, 0, 0, 1, 0 },
            { 6, 0, 2, 0, 4, 0 }
        };

        VariantSixBoard? board = TestNormalSudokuBoardBuilder.Build<VariantSixBoard>(grid, 6, 6, 3, 2);
        Assert.False(board?.Validate());
    }
}