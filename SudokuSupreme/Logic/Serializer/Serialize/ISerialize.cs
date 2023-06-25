using Logic.Model;

namespace Logic.Serializer.Serialize;

public interface ISerialize
{
    public string[] Serialize(Board board);
}