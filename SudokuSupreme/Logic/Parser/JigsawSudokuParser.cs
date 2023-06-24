using Logic.Grid;
using Logic.Grid.board;
using Logic.Parser.Builder;

namespace Logic.Parser;

public class JigsawSudokuParser : ISudokuParser
{
    public JigsawSudokuParser()
    {
    }

    public IBoard? LoadSudoku(string s)
    {
        Dictionary<int, int[]>? numbers = SudokuFileParser.ParseJigsawContent(s);

        if (numbers == null)
        {
            return null;
        }

        return new JigsawSudokuBuilder(numbers)
            .BuildCells().BuildRows().BuildColumns().BuildGroups().AssignGroups().Generate<JigsawBoard>();
    }
}