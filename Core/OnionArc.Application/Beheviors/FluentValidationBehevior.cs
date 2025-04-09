using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArc.Application.Beheviors;

public class FluentValidationBehevior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    //where TResponse : class
{
    private readonly IEnumerable<IValidator<TRequest>> validator;

    public FluentValidationBehevior(IEnumerable<IValidator<TRequest>> validator)
    {
        this.validator = validator;
    }

    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        
        var failures = validator
            .Select(x => x.Validate(context))
            .SelectMany(x => x.Errors) // Birden fazla hata da olabilir
            .GroupBy(x =>x.ErrorMessage)
            .Select(x => x.First()) // Hata mesajları birleştirildi
            .Where(x => x != null).ToList();

        if (failures.Count != 0)
            throw new ValidationException(failures);
        return next();
    }
}
