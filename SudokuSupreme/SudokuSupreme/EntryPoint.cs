using Logic;
using Presentation;

namespace SudokuSupreme;

public static class EntryPoint
{
    public static void Main(string[] args)
    {
        new SudokuBuilder()
            .AddBoardRenderer(new BoardRenderer())
            .AddTextRenderer(new MessageRenderer())
            //.AddInputReader()
            .Build()
            .Start();
    }
}