using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCoreApi.Data.EF;
using NetCoreApi.Filters;
using NetCoreApi.Helpers;
using NetCoreApi.Serializers;
using NetCoreApi.Validation;

namespace NetCoreApi
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

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
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
