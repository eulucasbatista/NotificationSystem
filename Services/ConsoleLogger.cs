using NotificationSystem.Interfaces;

namespace NotificationSystem.Services;

public class ConsoleLogger : IAppLogger
{
    public void LogInfo(string message)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"[INFO]  {message}");
        Console.ResetColor();
    }

    public void LogError(string message, Exception? ex = null)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"[ERROR] {message}");
        if (ex is not null) Console.WriteLine(ex);
        Console.ResetColor();
    }
}
