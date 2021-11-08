using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using CodersLinkAssignment.Aplication;
using CodersLinkAssignment.Persistence;
using CodersLinkAssignment.Shared;
using CodersLinkAssignment.WebApi.Extensions;

namespace CodersLinkAssignment.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();


            // Add Aplication layer services
            services.AddCodersLinkAssignmentAplicationServices();

            // Add Persistence layer services
            services.AddCodersLinkAssignmentPersistenceServices(Configuration);

            // Add Shared layer services
            services.AddCodersLinkAssignmentSharedServices(Configuration);

            // Add WebApi layer services
            services.AddCodersLinkAssignmentWebApiServices();



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CodersLinkAssignment.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CodersLinkAssignment.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
