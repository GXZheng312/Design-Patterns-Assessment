using Logic.Grid;

namespace Logic.Parser;

public interface ISudokuParser
{
    public Board? LoadSudoku(string s);
}