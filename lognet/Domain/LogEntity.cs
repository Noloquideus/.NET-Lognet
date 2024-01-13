namespace lognet.Domain
{
/// LogEntity represents a log entry with details such as log level, message, and timestamp.
    public class LogEntity
    {
        /**
         Initializes a new instance of the LogEntity class.

         @param level The log level of the entry.
         @param message The log message content.
         */
        public LogEntity(LogLevel level, string message)
        {
            Level = level;
            Message = message;
            Timestamp = DateTime.Now;
        }

        /// Gets the log level of the entry.
        public LogLevel Level { get; private set; }

        /// Gets the log message content.
        public string Message { get; private set; }

        /// Gets the timestamp when the log entry was created.
        public DateTime Timestamp { get; private set; }
    }
}