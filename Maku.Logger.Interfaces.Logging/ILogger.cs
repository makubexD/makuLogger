using Maku.Logger.CommandModel;

namespace Maku.Logger.Interfaces.Logging
{
    public interface ILogger
    {
        bool Error(string messageDescription, string createdBy);
        bool Warning(string messageDescription, string createdBy);
        bool Message(string messageDescription, string createdBy);
        //void AppenderLog(Message message);
    }
}
