namespace Iconic.EventDispatcher;

public interface IEvent
{
    public string Name { get; }
    public object Data { get; }
}