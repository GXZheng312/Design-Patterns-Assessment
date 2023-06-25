using GameEngine.Observer;

namespace GameEngine;

public class Messenger : IPublisher, IMessager
{
    private readonly Queue<string> _messageQueue;
    private readonly List<ISubscriber> _subscribers;
    public string Message { get; set; }

    public Messenger()
    {
        _messageQueue = new Queue<string>();
        _subscribers = new List<ISubscriber>();
        Message = string.Empty;
    }

    public void AddMessage(string message)
    {
        _messageQueue.Enqueue(message);
        Notify();
    }

    public void Notify()
    {
        if (_subscribers.Count < 0) return;
        if (_messageQueue.Count < 0) return;

        Message = _messageQueue.Dequeue();

        foreach (ISubscriber observer in _subscribers)
        {
            observer.Update(this);
        }
    }

    public void Subscribe(ISubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        _subscribers.Remove(subscriber);
    }
}