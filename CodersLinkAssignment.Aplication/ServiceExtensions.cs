using System.Reflection;
using CodersLinkAssignment.Aplication.Behaivors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CodersLinkAssignment.Aplication
{
    public static class ServiceExtensions
    {
        public static void AddCodersLinkAssignmentAplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaivor<,>));

        }
    }
}
