using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPI.Exceptions;
using System.Net.Mime;

namespace NetCoreAPI.Validation
{
    public static class ValidationErrorHandler
    {
        public static IActionResult Handle(ActionContext context)
        {
            throw new BindValidationException(context.ModelState.Values);
        }
    }
}
