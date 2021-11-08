using CodersLinkAssignment.Aplication.Interfaces;
using System;

namespace CodersLinkAssignment.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
