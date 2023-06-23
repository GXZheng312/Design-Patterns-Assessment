namespace Logic.Grid
{
    public interface IBoard
    {
        string Type { get; set; }

        List<Cell> Cells { get; set; }

        public void MoveUp();
        public void MoveDown();
        public void MoveLeft();
        public void MoveRight();
    }
}
