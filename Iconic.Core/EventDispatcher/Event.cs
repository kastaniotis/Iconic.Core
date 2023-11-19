namespace Iconic.EventDispatcher;

public record Event(string Name, object Data) : IEvent;