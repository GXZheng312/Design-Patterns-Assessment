using Logic.Grid.board;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public class VariantNineValidateTests
{
    [Test]
    public void ValidVariantNineBoard_ShouldReturnTrue()
    {
        int[,] grid =
        {
            { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
            { 4, 5, 6, 7, 8, 9, 1, 2, 3 },
            { 7, 8, 9, 1, 2, 3, 4, 5, 6 },
            { 2, 3, 4, 5, 6, 7, 8, 9, 1 },
            { 5, 6, 7, 8, 9, 1, 2, 3, 4 },
            { 8, 9, 1, 2, 3, 4, 5, 6, 7 },
            { 9, 1, 2, 3, 4, 5, 6, 7, 8 },
            { 3, 4, 5, 6, 7, 8, 9, 1, 2 },
            { 6, 7, 8, 9, 1, 2, 3, 4, 5 }
        };

        VariantNineBoard? board = NormalTestSudokuBuilder.BuildBoard<VariantNineBoard>(grid, 9, 9, 3, 3);
        Assert.True(board?.Validate());
    }
    
    [Test]
    public void InvalidVariantNineBoard_ShouldReturnFalse()
    {
        int[,] grid =
        {
            { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
            { 2, 3, 4, 5, 6, 7, 8, 9, 1 },
            { 3, 4, 5, 6, 7, 8, 9, 1, 2 },
            { 4, 5, 6, 7, 8, 9, 1, 2, 3 },
            { 5, 6, 7, 8, 9, 1, 2, 3, 4 },
            { 6, 7, 8, 9, 1, 2, 3, 4, 5 },
            { 7, 8, 9, 1, 2, 3, 4, 5, 6 },
            { 8, 9, 1, 2, 3, 4, 5, 6, 7 },
            { 9, 1, 2, 3, 4, 5, 6, 7, 8 }
        };

        VariantNineBoard? board = NormalTestSudokuBuilder.BuildBoard<VariantNineBoard>(grid, 9, 9, 3, 3);
        Assert.False(board?.Validate());
    }
    
    [Test]
    public void EmptyVariantNineBoard_ShouldReturnFalse()
    {
        int[,] grid =
        {
            { 0, 2, 0, 0, 5, 6, 0, 8, 0 },
            { 0, 0, 4, 0, 6, 7, 0, 0, 0 },
            { 3, 0, 0, 0, 7, 8, 0, 0, 0 },
            { 0, 5, 0, 7, 0, 0, 1, 0, 0 },
            { 0, 0, 7, 8, 0, 0, 2, 0, 0 },
            { 6, 0, 0, 9, 0, 0, 0, 0, 0 },
            { 0, 8, 0, 0, 2, 0, 4, 0, 0 },
            { 0, 0, 1, 0, 3, 0, 0, 0, 0 },
            { 9, 0, 0, 0, 0, 5, 6, 7, 0 }
        };

        VariantNineBoard? board = NormalTestSudokuBuilder.BuildBoard<VariantNineBoard>(grid, 9, 9, 3, 3);
        Assert.False(board?.Validate());
    }
}