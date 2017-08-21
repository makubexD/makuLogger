using Maku.Logger.CommandModel;

namespace Maku.Logger.Repository.Interfaces.Commad
{
    public interface ILoggerRepositoryCommand
    {
        void LogToDatabase(Message message);
        void LogToFile(Message message);
        void LogToConsole(Message message);
        string GetLogTypeName(int id);
    }
}
