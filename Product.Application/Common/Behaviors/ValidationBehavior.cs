using FluentValidation;
using MediatR;
using OutcomeOf;
using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> 
        (IValidator<TRequest> _validator =null)
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IOutcomeOf
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validator is null)
            {
                return await next();
            }
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if(validationResult.IsValid)
            {
                return await next();
            }

            var error= validationResult.Errors
                        .Select(e =>Error.Validation(e.PropertyName,e.ErrorMessage))
                        .FirstOrDefault();

            return (dynamic)error;

        }
    }
}
