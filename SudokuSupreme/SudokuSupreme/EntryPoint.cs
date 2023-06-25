using GameEngine;
using Presentation;

namespace SudokuSupreme;

public static class EntryPoint
{
    public static void Main()
    {
        new SudokuGameBuilder()
            .AddBoardRenderer(new BoardRenderer())
            .AddTextRenderer(new MessageRenderer())
            .Build()
            .Start();
    }
}