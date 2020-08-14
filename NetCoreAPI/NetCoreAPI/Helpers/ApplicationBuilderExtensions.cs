using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using NetCoreAPI.Localization;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace NetCoreAPI.Helpers
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseJsonLocalization(this IApplicationBuilder app, string defaultLocale)
        {
            List<CultureInfo> supportedCultures = (app.ApplicationServices.GetService<IStringLocalizer>() as JsonStringLocalizer).GetAllCultures().ToList();
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultLocale),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                RequestCultureProviders = new List<IRequestCultureProvider> { new AcceptLanguageHeaderRequestCultureProvider() }
            });
        }
    }
}
