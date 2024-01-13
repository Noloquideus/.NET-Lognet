using lognet.Domain;

namespace lognet.Handlers;

public interface IHandler
{
    public void Emit(LogEntity logEntity, string logFormat);
}