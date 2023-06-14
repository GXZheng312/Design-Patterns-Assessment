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
