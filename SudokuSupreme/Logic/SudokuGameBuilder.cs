using Logic.Observer;

namespace Logic;

public class SudokuGameBuilder : IBuilder<IGame>
{
    private SudokuGame Game { get; set; }

    public SudokuGameBuilder()
    {
        this.Game = new SudokuGame();
    }

    public IBuilder<IGame> AddBoardRenderer(ISubscriber observer)
    {
        (Game.BoardObserver).Subscribe(observer);

        return this;
    }

    public IBuilder<IGame> AddInputReader(ISubscriber observer)
    {
        return this;
    }

    public IBuilder<IGame> AddTextRenderer(ISubscriber observer)
    {
        ((Messager)Game.Messager).Subscribe(observer);

        return this;
    }

    public IGame Build()
    {
        return Game;
    }
}