using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodersLinkAssignment.Aplication.Interfaces;
using CodersLinkAssignment.Persistence.Context;
using CodersLinkAssignment.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodersLinkAssignment.Persistence
{
    public static class ServiceExtensions
    {
        public static void AddCodersLinkAssignmentPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AplicationDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("Default"),
                b => b.MigrationsAssembly(typeof(AplicationDbContext).Assembly.FullName)));


            services.AddTransient(typeof(IRepositoryAsync<>), typeof(MyRepositoryAsycn<>));
        }
    }
}
