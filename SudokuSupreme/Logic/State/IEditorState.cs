
using Logic.Grid;
using Logic.Model;
using Logic.Visitor;

namespace Logic;

public interface IEditorState
{
    void EnterNumber(Cell cell, int number);

    void EnterDefinitive(Cell cell, bool definitive);

    void EnterHelpCell(Cell cell);
}