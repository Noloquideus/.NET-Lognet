using lognet.Application;
using lognet.Configuration;
using lognet.Domain;
using lognet.Handlers;
using Moq;

namespace TestLognet
{
    public class LoggerTests
    {
        [Fact]
        public void Log_WithValidConfig_CallsEmitOnce()
        {
            var mockHandler = new Mock<IHandler>();
            var config = new LoggerConfig("Default Log Format", LogLevel.Info, mockHandler.Object);
            var logger = new Logger(config);
            
            logger.Log(LogLevel.Info, "Test message");
            
            mockHandler.Verify(h => h.Emit(It.IsAny<LogEntity>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Log_WithInvalidConfig_DoesNotCallEmit()
        {
            var mockHandler = new Mock<IHandler>();
            var config = new LoggerConfig("Default Log Format", LogLevel.Debug, null);
            var logger = new Logger(config);
            
            logger.Log(LogLevel.Info, "Test message");
            
            mockHandler.Verify(h => h.Emit(It.IsAny<LogEntity>(), It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void Log_WithConsoleHandler_CallsConsoleWriteLine()
        {
            var mockConsoleHandler = new Mock<IHandler>();
            var config = new LoggerConfig("Default Log Format", LogLevel.Info, mockConsoleHandler.Object);
            var logger = new Logger(config);
            
            logger.Log(LogLevel.Info, "Test message");
            
            mockConsoleHandler.Verify(h => h.Emit(It.IsAny<LogEntity>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Log_WithFileHandler_CallsFileWriteOnce()
        {
            var tempFilePath = Path.GetTempFileName();
            var fileHandler = new FileHandler(tempFilePath);
            var config = new LoggerConfig("Default Log Format", LogLevel.Info, fileHandler: fileHandler);
            var logger = new Logger(config);
            
            logger.Log(LogLevel.Info, "Test message");
            
            Assert.Contains("Test message", File.ReadAllText(tempFilePath));
            
            File.Delete(tempFilePath);
        }

        [Fact]
        public void Log_WithLogLevelBelowMinimum_DoesNotCallEmit()
        {
            var mockConsoleHandler = new Mock<IHandler>();
            var config = new LoggerConfig("Default Log Format", LogLevel.Info, mockConsoleHandler.Object);
            var logger = new Logger(config);
            
            logger.Log(LogLevel.Debug, "Test message");
            
            mockConsoleHandler.Verify(h => h.Emit(It.IsAny<LogEntity>(), It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void Log_WithLogLevelEqualOrAboveMinimum_CallsEmit()
        {
            var mockConsoleHandler = new Mock<IHandler>();
            var config = new LoggerConfig("Default Log Format", LogLevel.Info, mockConsoleHandler.Object);
            var logger = new Logger(config);
            
            logger.Log(LogLevel.Info, "Test message");
            
            mockConsoleHandler.Verify(h => h.Emit(It.IsAny<LogEntity>(), It.IsAny<string>()), Times.Once);
        }
        
        [Fact]
        public void Log_WithTimestamp_CreatesLogEntityWithTimestamp()
        {
            var mockHandler = new Mock<IHandler>();
            var config = new LoggerConfig("Default Log Format", LogLevel.Info, mockHandler.Object);
            var logger = new Logger(config);
            
            logger.Log(LogLevel.Info, "Test message");
            
            mockHandler.Verify(h => h.Emit(It.Is<LogEntity>(logEntity => logEntity.Timestamp != default), It.IsAny<string>()), Times.Once);
        }
    }
}
