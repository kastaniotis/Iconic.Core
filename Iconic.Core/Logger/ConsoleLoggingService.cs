using Iconic.Console;

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
        Terminal.WriteInBlue($"{message}: ");
        if (null == context) return;
        Terminal.WriteLineInGreen((context.GetType().IsArray ? string.Join(", ", context) : context).ToString());
    }
}
