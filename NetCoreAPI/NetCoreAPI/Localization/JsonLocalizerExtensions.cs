using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace NetCoreAPI.Localization
{
    public static class JsonLocalizerExtensions
    {
        public static void AddJsonLocalization(this IServiceCollection services)
        {
            services.AddSingleton<IStringLocalizer, JsonStringLocalizer>();
        }
    }
}
