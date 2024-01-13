using lognet.Domain;

namespace lognet.Handlers;

// Represents an interface for log handlers.
public interface IHandler
{
    /**
     * Emits a log message based on the provided log entity and log format.
     *
     * @param logEntity The log entity containing log information.
     * @param logFormat The log format string for formatting the log message.
     */
    void Emit(LogEntity logEntity, string logFormat);
}
