namespace Logic.Parser;

public class SudokuParserFactory
{
    public static ISudokuParser CreateSudokuParser(string sudokuType)
    {
        return sudokuType.ToLower() switch
        {
            "4x4" => new FourSudokuParser(),
            "6x6" => new SixSudokuParser(),
            "9x9" => new NineSudokuParser(),
            "jigsaw" => new JigsawSudokuParser(),
            "samurai" => new SamuraiSudokuParser(),
            _ => throw new ArgumentException("Invalid sudoku type.")
        };
    }
}