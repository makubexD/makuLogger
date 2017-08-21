using Maku.Logger.Entities.Audit;

namespace Maku.Logger.CommandModel
{
    public class Message : AuditRecord
    {
        public int LoggerSeverity { get; set; }
        public string Description { get; set; }
    }
}
