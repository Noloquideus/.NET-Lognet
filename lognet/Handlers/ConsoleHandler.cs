using lognet.Domain;

namespace lognet.Handlers;

// Represents a console log handler that emits log messages to the console.
public class ConsoleHandler : IHandler
{
    /**
     * Emits a log message to the console.
     *
     * @param logEntity The log entity containing log information.
     * @param logFormat The log format string for formatting the log message.
     */
    public void Emit(LogEntity logEntity, string logFormat)
    {
        string formattedMessage = string.Format(logFormat,
            logEntity.Level,
            logEntity.Message);

        Console.WriteLine(formattedMessage);
    }
}
