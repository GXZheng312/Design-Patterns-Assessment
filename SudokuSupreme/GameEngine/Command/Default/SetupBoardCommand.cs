﻿using GameEngine.Parser;
using Logic;
using Utility;
using Utility.FileReader;

namespace GameEngine.Command.Default;

public class SetupBoardCommand : ICommand
{
    public void Execute(IGame game)
    {
        if (game is not SudokuGame sudokuGame) return;

        bool setup = false;

        while (!setup)
        {
            ISudokuParser? parser = null;
            string? fileName = null;

            while (parser == null || fileName == null)
            {
                fileName = ReadFile(sudokuGame);
                parser = GetSudokuParser(sudokuGame, fileName);
            }

            setup = SetupBoard(sudokuGame, fileName, parser);
        }
    }

    private string ReadFile(SudokuGame sudokuGame)
    {
        IMessager messager = sudokuGame.Messager;
        string fileName;

        while (true)
        {
            messager.AddMessage("\nEnter file name: (e.g. puzzle.4x4)");

            fileName = sudokuGame.Reader.ReadInput();

            if (FileUtilities.IsValidFilename(fileName)) break;

            messager.AddMessage("Could not parse file: Invalid filename.");
        }

        return fileName;
    }

    private ISudokuParser? GetSudokuParser(SudokuGame sudokuGame, string fileName)
    {
        try
        {
            string fileExtension = Path.GetExtension(fileName).TrimStart('.');
            ISudokuParser sudokuParser = new SudokuParserFactory().Create(fileExtension);
            return sudokuParser;
        }
        catch (ArgumentException e)
        {
            sudokuGame.Messager.AddMessage($"Could not create sudoku: {e.Message}");
        }

        return null;
    }

    private bool SetupBoard(SudokuGame sudokuGame, string fileName, ISudokuParser sudokuParser)
    {
        try
        {
            string fileContents = FileReader.LoadFile(fileName);

            if (sudokuParser.LoadSudoku(fileContents) is Board board)
            {
                sudokuGame.SudokuObject.Board = board;
                return true;
            }

            sudokuGame.Messager.AddMessage("Could not create board: Invalid file contents.");
        }
        catch (ArgumentException e)
        {
            sudokuGame.Messager.AddMessage($"Could not create sudoku: {e.Message}");
        }

        return false;
    }
}