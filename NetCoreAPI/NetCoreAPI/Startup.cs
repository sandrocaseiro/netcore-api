using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using NetCoreAPI.Data.EF;
using NetCoreAPI.Filters;
using NetCoreAPI.Localization;
using NetCoreAPI.Validation;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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
                    o.InvalidModelStateResponseFactory = ValidationErrorHandler.handle;
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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            List<CultureInfo> supportedCultures = (app.ApplicationServices.GetService<IStringLocalizer>() as JsonStringLocalizer).GetAllCultures().ToList();
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(Configuration.GetValue<string>("Locale:Default")),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                RequestCultureProviders = new List<IRequestCultureProvider> { new AcceptLanguageHeaderRequestCultureProvider() }
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
