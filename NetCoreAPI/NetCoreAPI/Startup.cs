using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCoreAPI.Data.EF;
using NetCoreAPI.Filters;
using NetCoreAPI.Helpers;
using NetCoreAPI.Serializers;
using NetCoreAPI.Validation;

namespace NetCoreAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddJsonLocalization();

            services
                .AddControllers(o =>
                {
                    o.Filters.Add<GlobalExceptionFilter>();
                })
                .ConfigureApiBehaviorOptions(o =>
                {
                    o.InvalidModelStateResponseFactory = ValidationErrorHandler.Handle;
                })
                .AddJsonOptions(o =>
                {
                    o.JsonSerializerOptions.Converters.Add(new DResponsErrorTypeSerializer());
                })
                .AddFluentValidation(f => 
                {
                    f.RegisterValidatorsFromAssembly(typeof(Startup).Assembly, lifetime: ServiceLifetime.Singleton);
                    f.ImplicitlyValidateChildProperties = true;
                    f.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                });

            services.AddDbContextPool<EFContext>(o =>
            {
                o.UseNpgsql(Configuration.GetConnectionString("Default"));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseJsonLocalization(Configuration.GetValue<string>("Locale:Default"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
