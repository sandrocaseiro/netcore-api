using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using System;

namespace NetCoreAPI.Validation
{
    public class CustomClientErrorFactory : IClientErrorFactory
    {
        private readonly ILogger _logger;

        public CustomClientErrorFactory(ILogger<CustomClientErrorFactory> logger)
        {
            _logger = logger;
        }

        public IActionResult GetClientError(ActionContext actionContext, IClientErrorActionResult clientError)
        {
            _logger.LogInformation("Client Error Factory");
            throw new NotImplementedException();
        }
    }
}
