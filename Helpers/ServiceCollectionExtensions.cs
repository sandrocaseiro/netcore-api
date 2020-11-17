using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using NetCoreApi.Localization;

namespace NetCoreApi.Helpers
{
	public static class ServiceCollectionExtensions
    {
        public static void AddJsonLocalization(this IServiceCollection services)
        {
            services.AddSingleton<IStringLocalizer, JsonStringLocalizer>();
        }
    }
}
