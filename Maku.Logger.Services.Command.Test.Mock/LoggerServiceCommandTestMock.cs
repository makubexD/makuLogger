using Moq;
using Maku.Logger.Services.Interfaces.Command;

namespace Maku.Logger.Services.Command.Test.Mock
{
    public class LoggerServiceCommandTestMock
    {
        public Mock<ILoggerServiceCommand> GenerateLoggerServiceCommandDataError()
        {
            var mockServiceCommand = new Mock<ILoggerServiceCommand>();
            mockServiceCommand.Setup(x => x.Error("Error Message", "Maku")).Returns(true);
            return mockServiceCommand;
        }

        public Mock<ILoggerServiceCommand> GenerateLoggerServiceCommandDataWarning()
        {
            var mockServiceCommand = new Mock<ILoggerServiceCommand>();
            mockServiceCommand.Setup(x => x.Warning("Warning Message", "Maku")).Returns(true);
            return mockServiceCommand;
        }

        public Mock<ILoggerServiceCommand> GenerateLoggerServiceCommandDataMessage()
        {
            var mockServiceCommand = new Mock<ILoggerServiceCommand>();
            mockServiceCommand.Setup(x => x.Message("Message Message", "Maku")).Returns(true);
            return mockServiceCommand;
        }

    }
}
