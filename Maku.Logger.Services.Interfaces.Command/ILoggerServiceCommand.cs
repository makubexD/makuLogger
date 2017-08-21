namespace Maku.Logger.Services.Interfaces.Command
{
    public interface ILoggerServiceCommand
    {
        bool Error(string messageDescription, string createdBy);
        bool Warning(string messageDescription, string createdBy);
        bool Message(string messageDescription, string createdBy);
    }
}
