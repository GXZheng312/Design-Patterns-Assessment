namespace Logic.Visitor;

public interface IVisitor
{
    void Visit(IVisitable visitor);
}