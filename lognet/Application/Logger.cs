using lognet.Configuration;
using lognet.Domain;
using lognet.Formatters;
using lognet.Handlers;

namespace lognet.Application
{
    /// <summary>
    /// Represents a logger that logs messages based on the provided configuration.
    /// </summary>
    public class Logger
    {
        private readonly LoggerConfig _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class with the specified configuration.
        /// </summary>
        /// <param name="config">The logger configuration.</param>
        public Logger(LoggerConfig config)
        {
            _config = config;
        }

        /// <summary>
        /// Logs a message with the specified log level and message.
        /// </summary>
        /// <param name="logLevel">The log level of the message.</param>
        /// <param name="message">The message to be logged.</param>
        public void Log(LogLevel logLevel, string message)
        {
            LogEntity logEntity = new LogEntity(level: logLevel, message: message);

            if (logEntity.Level >= _config.MinimumLevel)
            {
                IHandler? consoleHandler = _config.ConsoleHandler;
                IHandler? fileHandler = _config.FileHandler;

                consoleHandler?.Emit(logEntity, LogFormatter.FormatMessage(logEntity, _config));
                fileHandler?.Emit(logEntity, LogFormatter.FormatMessage(logEntity, _config));
            }
        }
    }
}