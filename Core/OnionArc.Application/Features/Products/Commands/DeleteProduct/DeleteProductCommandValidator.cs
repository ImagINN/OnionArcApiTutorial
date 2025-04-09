using FluentValidation;

namespace OnionArc.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommandRequest>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithName("Id")
            .WithMessage("Product Id cannot be empty")
            .GreaterThan(0)
            .WithMessage("Product Id must be greater than 0");
    }
}
