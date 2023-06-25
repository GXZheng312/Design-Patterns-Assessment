using GameEngine;
using Presentation;

namespace SudokuSupreme;

public static class EntryPoint
{
    public static void Main(string[] args)
    {
        new SudokuGameBuilder()
            .AddBoardRenderer(new BoardRenderer())
            .AddTextRenderer(new MessageRenderer())
            //.AddInputReader()
            .Build()
            .Start();
    }
}