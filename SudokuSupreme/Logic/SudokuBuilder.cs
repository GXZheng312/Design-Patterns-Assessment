using Logic.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic;

public class SudokuBuilder : IBuilder<IGame>
{
    private Sudoku Game { get; set; }

    public SudokuBuilder()
    {
        this.Game = new Sudoku();
    }

    public IBuilder<IGame> AddBoardRenderer(IObserver observer)
    {
        Game.Board.Attach(observer);

        return this;
    }

    public IBuilder<IGame> AddInputReader(IObserver observer)
    {
        return this;
    }

    public IBuilder<IGame> AddTextRenderer(IObserver observer)
    {
        Game.Attach(observer);

        return this;
    }

    public IGame Build()
    {
        return Game;
    }
}
