namespace Logic.State;

public interface IEditorState
{
    void EnterNumber(Cell cell, int number);

    void SwitchDefinitive(Cell cell);

    void EnterHelpCell(Cell cell, int size);
}