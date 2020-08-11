using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using NetCoreAPI.Models;
using System.Net.Mime;

namespace NetCoreAPI.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger _logger;
        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "Error");
            context.Result = new ObjectResult(DResponse<dynamic>.ToNotOk(500, "error"))
            {
                StatusCode = 500,
                ContentTypes = new Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection { MediaTypeNames.Application.Json }
            };
            context.ExceptionHandled = true;
        }
    }
}
