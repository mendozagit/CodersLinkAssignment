using System;

namespace CodersLinkAssignment.Aplication.Interfaces
{
    public interface IDateTimeService
    {
        public DateTime NowUtc { get; }
    }
}