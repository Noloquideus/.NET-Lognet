using lognet.Domain;
using lognet.Handlers;

namespace lognet.Configuration
{ 
    /**
 LoggerConfig represents the configuration for the Logger class.
 It includes settings such as log format, minimum log level, and optional handlers.
 */
    public class LoggerConfig
    {
        /**
        Initializes a new instance of the LoggerConfig class.
         
         @param logFormat The format for log messages.
         @param minimumLevel The minimum log level to consider for logging.
         @param consoleHandler (Optional) The console log handler.
         @param fileHandler (Optional) The file log handler.
         */
        public LoggerConfig(string logFormat, LogLevel minimumLevel, IHandler? consoleHandler = null, IHandler? fileHandler = null)
        {
            LogFormat = logFormat;
            MinimumLevel = minimumLevel;
            ConsoleHandler = consoleHandler;
            FileHandler = fileHandler;
        }

        /// Gets the minimum log level.
        public LogLevel MinimumLevel { get; private set; }

        /// Gets or sets the console log handler.
        public IHandler? ConsoleHandler { get; set; }

        /// Gets or sets the file log handler.
        public IHandler? FileHandler { get; set; }

        /// Gets the log format.
        public string LogFormat { get; private set; }
    }
}