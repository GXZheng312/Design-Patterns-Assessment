using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Command.Game;

public class ChangeGameStateCommand : ICommand
{
    public void Execute(IGame game)
    {
        SudokuGame sudokuGame = game as SudokuGame;

        if (sudokuGame != null)
        {
            if (sudokuGame.SudokuObject.State is DefinitiveState)
            {
                sudokuGame.SudokuObject.State = new HelpState();
                sudokuGame.Messager.AddMessage("Current state: Help state");
            }
            else
            {
                sudokuGame.SudokuObject.State = new DefinitiveState();
                sudokuGame.Messager.AddMessage("Current state: Definitive state");
            }

        }
    }
}
