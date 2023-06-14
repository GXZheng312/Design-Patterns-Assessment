using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Observer
{
    public class BoardObserver : IPublisher
    {
        private List<ISubscriber> Subscribers { get; set; } = new List<ISubscriber>();
        public Board Board { get; set; } = new Board();

        public void Notify()
        {
            if (Subscribers.Count < 0) return;

            foreach (ISubscriber subscriber in Subscribers)
            {
                subscriber.Update(this);
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
}
