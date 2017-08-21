using System;
using System.Configuration;
using Maku.Logger.CommandModel;
using Maku.Logger.Repository.Interfaces.Commad;
using Maku.Logger.Common;
using Maku.Logger.Services.Interfaces.Command;

namespace Maku.Logger.Services.Command
{
    public class LoggerServiceCommand : ILoggerServiceCommand
    {
        private readonly ILoggerRepositoryCommand _loggerRepositoryCommand;
        private readonly bool _logToFile;
        private readonly bool _logToConsole;
        private readonly bool _logToDatabase;
        private readonly Message _message;

        public LoggerServiceCommand(ILoggerRepositoryCommand loggerRepositoryCommand)
        {
            _loggerRepositoryCommand = loggerRepositoryCommand;
            _logToDatabase = Convert.ToBoolean(ConfigurationManager.AppSettings["LogToDatabase"]);
            _logToFile = Convert.ToBoolean(ConfigurationManager.AppSettings["LogToFile"]);
            _logToConsole = Convert.ToBoolean(ConfigurationManager.AppSettings["LogToConsole"]);

            _message = new Message { CreationDate = DateTime.Now };
        } 

        public bool Error(string messageDescription, string createdBy)
        {
            try
            {
                _message.CreatedBy = createdBy;
                _message.LoggerSeverity = Constants.LoggerSeverity.Error;
                _message.Description = messageDescription;
                AppenderLog(_message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Warning(string messageDescription, string createdBy)
        {
            try
            {
                _message.CreatedBy = createdBy;
                _message.LoggerSeverity = Constants.LoggerSeverity.Warning;;
                _message.Description = messageDescription;
                AppenderLog(_message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Message(string messageDescription, string createdBy)
        {
            try
            {
                _message.CreatedBy = createdBy;
                _message.LoggerSeverity = Constants.LoggerSeverity.Message;;
                _message.Description = messageDescription;
                AppenderLog(_message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void AppenderLog(Message message)
        {
            if (_logToDatabase)
                _loggerRepositoryCommand.LogToDatabase(message);

            if (_logToConsole)
                _loggerRepositoryCommand.LogToConsole(message);
            
            if (_logToFile)
                _loggerRepositoryCommand.LogToFile(message);
        }
    }
}
