using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace NetCoreAPI.Validation
{
    public static class ValidationErrorHandler
    {
        public static IActionResult handle(ActionContext context)
        {
            return new ObjectResult("validation-error")
            {
                StatusCode = StatusCodes.Status422UnprocessableEntity,
                ContentTypes = new Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection { MediaTypeNames.Application.Json }
            };
        }
    }
}
