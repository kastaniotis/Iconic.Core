namespace Iconic.Logger;

public class ConsoleLoggingService : ILoggingService
{
    public bool Enabled { get; set; }

    public ConsoleLoggingService(bool enabled)
    {
        Enabled = enabled;
    }

    public void Log(string message, object? context)
    {
        if (!Enabled) return;
        System.Console.WriteLine(message);
        if (null == context) return;
        System.Console.WriteLine(context.GetType().IsArray ? string.Join(", ", context) : context);
    }
}