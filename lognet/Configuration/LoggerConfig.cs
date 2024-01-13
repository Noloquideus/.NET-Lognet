using lognet.Domain;
using lognet.Handlers;

namespace lognet.Configuration
{
    public class LoggerConfig
    {
        public LoggerConfig(string logFormat, LogLevel minimumLevel, IHandler? consoleHandler = null, IHandler? fileHandler = null)
        {
            LogFormat = logFormat;
            MinimumLevel = minimumLevel;
            ConsoleHandler = consoleHandler;
            FileHandler = fileHandler;
        }

        public LogLevel MinimumLevel { get; private set; }
        public IHandler? ConsoleHandler { get; set; }
        public IHandler? FileHandler { get; set; }
        public string LogFormat { get; private set; }
    }
}