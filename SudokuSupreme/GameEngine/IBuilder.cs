using GameEngine.Observer;

namespace GameEngine;

public interface IBuilder<T>
{
    IBuilder<T> AddBoardRenderer(ISubscriber observer);

    IBuilder<T> AddTextRenderer(ISubscriber observer);

    IBuilder<T> AddInputReader(ISubscriber observer);

    T Build();
}