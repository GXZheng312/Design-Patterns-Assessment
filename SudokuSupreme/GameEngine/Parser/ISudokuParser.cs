using Logic.Model;

namespace GameEngine.Parser;

public interface ISudokuParser
{
    public IBoard? LoadSudoku(string s);
}