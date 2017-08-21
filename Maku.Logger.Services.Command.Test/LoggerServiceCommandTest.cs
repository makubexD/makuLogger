using Maku.Logger.Services.Command.Test.Mock;
using NUnit.Framework;
using Maku.Logger.Services.Interfaces.Command;

namespace Maku.Logger.Services.Command.Test
{
    [TestFixture]
    public class LoggerServiceCommandTest
    {
        private static LoggerServiceCommandTestMock _serviceCommandTestMock;

        [OneTimeSetUp]
        public static void SetupTestEnvironment()
        {
            _serviceCommandTestMock = new LoggerServiceCommandTestMock();
        }

        [Test]
        public void Error_InsertError_True()
        {
            var loggerServiceCommandErrorMock = _serviceCommandTestMock.GenerateLoggerServiceCommandDataError();

            ILoggerServiceCommand loggerServiceCommand = loggerServiceCommandErrorMock.Object;
            var result = loggerServiceCommand.Error("Error Message", "Maku");

            Assert.AreEqual(result,true);
        }

        [Test]
        public void Warning_InsertWarning_True()
        {
            var loggerServiceCommandErrorMock = _serviceCommandTestMock.GenerateLoggerServiceCommandDataWarning();

            ILoggerServiceCommand loggerServiceCommand = loggerServiceCommandErrorMock.Object;
            var result = loggerServiceCommand.Warning("Warning Message", "Maku");

            Assert.AreEqual(result,true);
        }

        [Test]
        public void Message_InsertMessage_True()
        {
            var loggerServiceCommandErrorMock = _serviceCommandTestMock.GenerateLoggerServiceCommandDataMessage();

            ILoggerServiceCommand loggerServiceCommand = loggerServiceCommandErrorMock.Object;
            var result = loggerServiceCommand.Message("Message Message", "Maku");

            Assert.AreEqual(result,true);
        }
    }
}
