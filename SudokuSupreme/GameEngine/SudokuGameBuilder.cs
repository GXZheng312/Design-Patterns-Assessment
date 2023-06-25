using GameEngine.Observer;
using Logic;

namespace GameEngine;

public class SudokuGameBuilder : IBuilder<IGame>
{
    private SudokuGame Game { get; set; }

    public SudokuGameBuilder()
    {
        this.Game = new SudokuGame();
    }

    public IBuilder<IGame> AddBoardRenderer(ISubscriber observer)
    {
        Game.SudokuObserver.Subscribe(observer);

        return this;
    }

    public IBuilder<IGame> AddTextRenderer(ISubscriber observer)
    {
        ((Messenger)Game.Messager).Subscribe(observer);

        return this;
    }

    public IGame Build()
    {
        return Game;
    }
}