using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace NetCoreAPI.Exceptions
{
    public class BindValidationException : BaseException
    {
        public BindValidationException(IEnumerable<ModelStateEntry> bindErrors)
        {
            BindErrors = bindErrors;
        }

        public IEnumerable<ModelStateEntry> BindErrors { get; private set; }
        public override AppErrors AppError => AppErrors.BindingValidationError;
    }
}
