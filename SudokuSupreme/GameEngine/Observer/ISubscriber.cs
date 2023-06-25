namespace GameEngine.Observer;

public interface ISubscriber
{
    void Update(IPublisher publisher);
}