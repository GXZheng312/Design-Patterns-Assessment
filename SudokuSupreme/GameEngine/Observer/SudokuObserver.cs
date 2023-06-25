using Logic;

namespace GameEngine.Observer
{
    public class SudokuObserver : IPublisher
    {
        private List<ISubscriber> Subscribers { get; set; }
        public Sudoku SudokuObject { get; set; }

        public SudokuObserver(Sudoku sudokuObject)
        {
            Subscribers = new List<ISubscriber>();
            this.SudokuObject = sudokuObject;
        }

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