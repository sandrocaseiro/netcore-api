using System.Globalization;
using FluentValidation.Resources;
using Microsoft.Extensions.Localization;

namespace NetCoreApi.Localization
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
