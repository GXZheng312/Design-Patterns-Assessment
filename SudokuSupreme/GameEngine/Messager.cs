using GameEngine.Observer;

namespace GameEngine;

public class Messager : IPublisher, IMessager
{
    private Queue<string> MessageQueue { get; set; } = new();
    private List<ISubscriber> Subscribers { get; set; } = new();

    public string Message { get; set; }

    public void AddMessage(string message)
    {
        MessageQueue.Enqueue(message);
        Notify();
    }

    public void Notify()
    {
        if (Subscribers.Count < 0) return;
        if (MessageQueue.Count < 0) return;

        Message = MessageQueue.Dequeue();

        foreach (ISubscriber observer in Subscribers)
        {
            observer.Update(this);
        }
    }

    public void Subscribe(ISubscriber subscriber)
    {
        Subscribers.Add(subscriber);
    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        Subscribers.Remove(subscriber);
    }
}