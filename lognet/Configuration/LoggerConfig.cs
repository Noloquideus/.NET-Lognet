using lognet.Domain;
using lognet.Handlers;

namespace lognet.Configuration;

public class LoggerConfig
{

    public LoggerConfig(string logFormat, LogLevel minimumLevel, IHandler? consoleHandler = null)
    {

        LogFormat = logFormat;
        MinimumLevel = minimumLevel;
        ConsoleHandler = consoleHandler;
    }

    public LogLevel MinimumLevel { get; private set; }
    public IHandler? ConsoleHandler { get;  set; }
    public string LogFormat { get; private set; }
}