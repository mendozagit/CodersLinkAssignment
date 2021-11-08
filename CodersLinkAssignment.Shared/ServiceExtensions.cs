using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodersLinkAssignment.Aplication.Interfaces;
using CodersLinkAssignment.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodersLinkAssignment.Shared
{
    public static class ServiceExtensions
    {
        public static void AddCodersLinkAssignmentSharedServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDateTimeService, DateTimeService>();

        }
    }
}
