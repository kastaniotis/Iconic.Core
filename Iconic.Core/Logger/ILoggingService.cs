namespace Iconic.Logger;

public interface ILoggingService
{
    public bool Enabled { get; set; }
    public void Log(string message, object context);
}