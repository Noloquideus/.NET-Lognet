using lognet.Domain;

namespace lognet.Handlers
{ 
    //Represents a file log handler that emits log messages to a specified file.
    public class FileHandler : IHandler
    {
        private readonly string _filePath;

        /**
         * Initializes a new instance of the FileHandler class with the specified file path.
         *
         * @param filePath The path to the file where log messages will be written.
         */
        public FileHandler(string filePath)
        {
            _filePath = filePath;
        }

        /**
         * Emits a log message to the specified file.
         *
         * @param logEntity The log entity containing log information.
         * @param logFormat The log format string for formatting the log message.
         */
        public void Emit(LogEntity logEntity, string logFormat)
        {
            using (StreamWriter writer = File.AppendText(_filePath))
            {
                writer.WriteLine(logFormat, logEntity.Level, logEntity.Message);
            }
        }
    }

}