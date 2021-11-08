using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using CodersLinkAssignment.Aplication.Interfaces;
using CodersLinkAssignment.Domain.Common;
using CodersLinkAssignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodersLinkAssignment.Persistence.Context
{
    public sealed class AplicationDbContext : DbContext
    {
        private readonly IDateTimeService _dateTimeService;
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options, IDateTimeService dateTimeService) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTimeService = dateTimeService;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = _dateTimeService.NowUtc;
                        entry.Entity.UpdatedBy = "TEST"; //Get from JWT 
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedAt = _dateTimeService.NowUtc;
                        entry.Entity.CreatedBy = "TEST"; //Get from JWT
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
