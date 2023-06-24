using Logic.Grid.board;
using NUnit.Framework;
using Tests.Validation.Builders;

namespace Tests.Validation;

[TestFixture]
public class JigsawValidateTests
{
    [Test]
    public void ValidJigsawBoard_ShouldReturnTrue()
    {
        string cells = "289136745975483126328975461541692387653841972814527693467358219796214538132769854";
        string groups = "000000011220033331222333341222355641255556641756666641755776441777784441788888888";

        int[] values = cells.Select(c => int.Parse(c.ToString())).ToArray();
        int[] groupNumbers = groups.Select(c => int.Parse(c.ToString())).ToArray();

        JigsawBoard board = TestJigsawSudokuBoardBuilder.Build(values, groupNumbers);
        Assert.True(board?.Validate());
    }
    
    [Test]
    public void InvalidJigsawBoard_ShouldReturnFalse()
    {
        string cells = "299936745977783126322275461511692387663841972814527693466358219796214558152765855";
        string groups = "000000011220033331222333341222355641255556641756666641755776441777784441788888888";

        int[] values = cells.Select(c => int.Parse(c.ToString())).ToArray();
        int[] groupNumbers = groups.Select(c => int.Parse(c.ToString())).ToArray();

        JigsawBoard board = TestJigsawSudokuBoardBuilder.Build(values, groupNumbers);
        Assert.False(board.Validate());
    }
    
    [Test]
    public void EmptyJigsawBoard_ShouldReturnFalse()
    {
        string cells = "209136045905400126328975400041600087653000972000027693060308010706000038132700000";
        string groups = "000000011220033331222333341222355641255556641756666641755776441777784441788888888";

        int[] values = cells.Select(c => int.Parse(c.ToString())).ToArray();
        int[] groupNumbers = groups.Select(c => int.Parse(c.ToString())).ToArray();

        JigsawBoard board = TestJigsawSudokuBoardBuilder.Build(values, groupNumbers);
        Assert.False(board.Validate());
    }
}