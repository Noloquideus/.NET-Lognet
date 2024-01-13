using lognet.Configuration;
using lognet.Domain;

namespace lognet.Formatters
{
// Provides a static class for formatting log messages.
    public static class LogFormatter
    {
        /**
         * Formats a log message using the specified log entity and logger configuration.
         * The formatted message includes the timestamp, log level, and log message.
         *
         * @param logEntity The log entity containing log information.
         * @param config The logger configuration specifying the log format.
         * @return The formatted log message.
         */
        public static string FormatMessage(LogEntity logEntity, LoggerConfig config)
        {
            return $"{logEntity.Timestamp:yyyy-MM-dd HH:mm:ss} - {logEntity.Level} - {logEntity.Message}";
        }
    }
}