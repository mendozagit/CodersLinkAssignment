using System;

namespace CodersLinkAssignment.Domain.Common
{
    public class AuditableBaseEntity
    {
        public virtual int Id { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
