using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArc.Application.Features.Products.Queries.GetProductById;

public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQueryRequest>
{
    public GetProductByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithName("Id")
            .WithMessage("Product Id cannot be empty")
            .GreaterThan(0)
            .WithMessage("Product Id must be greater than 0");
    }
}
