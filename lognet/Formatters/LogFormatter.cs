using lognet.Configuration;
using lognet.Domain;

namespace lognet.Formatters
{
    public static class LogFormatter
    {
        public static string FormatMessage(LogEntity logEntity, LoggerConfig config)
        {
            return $"{logEntity.Level} - {logEntity.Message}";
        }
    }
}