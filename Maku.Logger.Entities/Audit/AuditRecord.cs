using System;
using System.ComponentModel.DataAnnotations;

namespace Maku.Logger.Entities.Audit
{
    public class AuditRecord
    {
        [Required]
        [StringLength(64)]
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
