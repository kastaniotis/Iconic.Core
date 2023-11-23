namespace Iconic.Logger;

public interface ILoggingService
{
    public void Log(string message, object context);
}