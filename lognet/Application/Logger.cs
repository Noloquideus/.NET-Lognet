using lognet.Configuration;
using lognet.Domain;
using lognet.Formatters;
using lognet.Handlers;

namespace lognet.Application
{
    public class Logger
    {
        private readonly LoggerConfig _config;

        public Logger(LoggerConfig config)
        {
            _config = config;
        }

        public void Log(LogLevel logLevel, string message)
        {
            LogEntity logEntity = new LogEntity(level: logLevel, message: message);

            if (logEntity.Level >= _config.MinimumLevel)
            {
                IHandler? consoleHandler = _config.ConsoleHandler;

                consoleHandler?.Emit(logEntity, LogFormatter.FormatMessage(logEntity, _config));
            }
        }
    }
}