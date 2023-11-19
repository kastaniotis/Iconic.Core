namespace Iconic.EventDispatcher;

public interface IEventListener
{
    public void Handle(IEvent ev);
}