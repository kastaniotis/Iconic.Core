using System.Diagnostics;

namespace Iconic.Logger;

public class ConsoleLoggingService : ILoggingService
{
    public ConsoleLoggingService(bool enabled)
    {
        if (enabled)
        {
            Trace.Listeners.Add(new ConsoleTraceListener());
        }
    }
    
    public void Log(string message, object? context)
    {
        System.Console.ForegroundColor = ConsoleColor.Blue;
        
        Trace.Write($"{message}: ");
        System.Console.ResetColor();
        System.Console.ForegroundColor = ConsoleColor.Green;
        Trace.WriteLineIf(null != context, context?.ToString());
        System.Console.ResetColor();
    }
}
