namespace lognet.Domain;

public class LogEntity
{
    public LogEntity(LogLevel level, string message)
    {
        Level = level;
        Message = message;
    }

    public LogLevel Level { get; set; }
    public string Message { get; set; }
}