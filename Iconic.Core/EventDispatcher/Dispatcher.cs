using Iconic.Logger;

namespace Iconic.EventDispatcher;

public class Dispatcher
{
    private ILoggingService Logger { get; set; }
    public Dispatcher(ILoggingService logger){
        Logger = logger;
    }

    public List<IEventListener> Listeners { get; } = new List<IEventListener>();

    public void Dispatch(Event ev){
        Logger.Log("Event Dispatching", ev);
        foreach(var listener in Listeners){
            listener.Handle(ev);
        }
    }
}