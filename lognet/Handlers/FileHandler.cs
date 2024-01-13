using System.IO;
using lognet.Domain;

namespace lognet.Handlers
{
    public class FileHandler : IHandler
    {
        private readonly string _filePath;

        public FileHandler(string filePath)
        {
            _filePath = filePath;
        }

        public void Emit(LogEntity logEntity, string logFormat)
        {
            using (StreamWriter writer = File.AppendText(_filePath))
            {
                writer.WriteLine(string.Format(logFormat, logEntity.Level, logEntity.Message));
            }
        }
    }
}