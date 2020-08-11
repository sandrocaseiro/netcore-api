using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAPI.Validation
{
    public class CustomProblemDetailsFactory : ProblemDetailsFactory
    {
        private readonly ILogger _logger;

        public CustomProblemDetailsFactory(ILogger<CustomProblemDetailsFactory> logger)
        {
            _logger = logger;
        }

        public override ProblemDetails CreateProblemDetails(HttpContext httpContext, int? statusCode = null, string title = null, string type = null, string detail = null, string instance = null)
        {
            _logger.LogInformation("Problem Details");
            throw new NotImplementedException();
        }

        public override ValidationProblemDetails CreateValidationProblemDetails(HttpContext httpContext, ModelStateDictionary modelStateDictionary, int? statusCode = null, string title = null, string type = null, string detail = null, string instance = null)
        {
            _logger.LogInformation("Validation Problem Details");
            return new ValidationProblemDetails();
        }
    }
}
