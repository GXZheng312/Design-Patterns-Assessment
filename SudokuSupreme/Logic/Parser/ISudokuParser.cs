using Logic.Grid;

namespace Logic.Parser;

public interface ISudokuParser
{
    public IBoard? LoadSudoku(string s);
}