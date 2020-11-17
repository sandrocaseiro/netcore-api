using Microsoft.AspNetCore.Mvc;
using NetCoreApi.Exceptions;

namespace NetCoreApi.Validation
{
	public static class ValidationErrorHandler
    {
        public static IActionResult Handle(ActionContext context)
        {
            throw new BindValidationException(context.ModelState.Values);
        }
    }
}
