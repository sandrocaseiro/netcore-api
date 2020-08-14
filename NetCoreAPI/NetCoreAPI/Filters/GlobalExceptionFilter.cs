using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using NetCoreAPI.Exceptions;
using NetCoreAPI.Helpers;
using NetCoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;

namespace NetCoreAPI.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger _logger;
        private readonly IStringLocalizer _localizer;
        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger, IStringLocalizer localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is BindValidationException)
            {
                var ex = (context.Exception as BindValidationException);
                var errors = ex.BindErrors
                    .SelectMany(e => e.Errors)
                    .Select(e => DResponse<dynamic>.Error.ToError(ex.AppError.ToCode(), e.ErrorMessage));
                
                context.Result = handleException(ex.AppError, errors, context.Exception);
            }
            else
                context.Result = handleException(AppErrors.ServerError, context.Exception);
            
            context.ExceptionHandled = true;
        }

        private IActionResult handleException(AppErrors error, Exception ex)
        {
            var message = _localizer.GetString(error.ToMessageRes());
            _logger.LogError(ex, message);

            return new ObjectResult(DResponse<dynamic>.ToNotOk(error.ToCode(), message))
            {
                StatusCode = error.ToHttpStatus(),
                ContentTypes = new Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection { MediaTypeNames.Application.Json }
            };
        }

        private IActionResult handleException(AppErrors error, IEnumerable<DResponse<dynamic>.Error> errors, Exception ex)
        {
            _logger.LogError(ex, "Error");

            return new ObjectResult(DResponse<dynamic>.ToNotOk(errors))
            {
                StatusCode = error.ToHttpStatus(),
                ContentTypes = new Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection { MediaTypeNames.Application.Json }
            };
        }
    }
}
