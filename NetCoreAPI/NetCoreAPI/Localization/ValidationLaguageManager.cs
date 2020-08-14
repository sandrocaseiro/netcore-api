using FluentValidation.Resources;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace NetCoreAPI.Localization
{
    public class ValidationLaguageManager : LanguageManager
    {
        public ValidationLaguageManager(IStringLocalizer localizer)
        {
            var jsonLocalizer = localizer as JsonStringLocalizer;
            foreach (CultureInfo culture in jsonLocalizer.GetAllCultures())
            {
                AddTranslation("", "NotNullValidator", "");
            }
            
        }
    }
}
