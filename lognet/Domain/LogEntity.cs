namespace lognet.Domain
{
    public class LogEntity
    {
        public LogEntity(LogLevel level, string message)
        {
            Level = level;
            Message = message;
            Timestamp = DateTime.Now;
        }

        public LogLevel Level { get; private set; }
        public string Message { get; private set; }
        public DateTime Timestamp { get; private set; }
    }
}