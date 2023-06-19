using Logic.Grid;

namespace Logic.Parser;

public interface ISudokuParser<T> where T : Board
{
    public T? LoadSudoku(string s);
}