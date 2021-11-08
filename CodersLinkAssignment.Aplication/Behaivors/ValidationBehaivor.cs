using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace CodersLinkAssignment.Aplication.Behaivors
{
    public class ValidationBehaivor<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaivor(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new FluentValidation.ValidationContext<TRequest>(request);
                var validationResults =
                    await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                {
                    throw new Exeptions.ValidationException(failures);
                }
            }
            return await next();
        }
    }
}
