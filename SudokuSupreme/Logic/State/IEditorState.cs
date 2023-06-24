
using Logic.Grid;
using Logic.Model;
using Logic.Visitor;

namespace Logic;

public interface IEditorState
{
    void EnterNumber(Cell cell, int number);

    void SwitchDefinitive(Cell cell);

    void EnterHelpCell(Cell cell);
}