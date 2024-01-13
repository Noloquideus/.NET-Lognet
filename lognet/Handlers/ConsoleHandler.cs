using lognet.Domain;

namespace lognet.Handlers;

public class ConsoleHandler : IHandler
{
    public void Emit(LogEntity logEntity, string logFormat)
    {
        string formattedMessage = string.Format(logFormat,
            logEntity.Level,
            logEntity.Message);

        Console.WriteLine(formattedMessage);
    }
}