using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArc.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithName("Başlık")
            .WithMessage("Product title cannot be empty")
            .MinimumLength(2)
            .WithMessage("Product title must be at least 2 characters long");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithName("Açıklama")
            .WithMessage("Description cannot be empty")
            .MinimumLength(2)
            .WithMessage("Descrişption must be at least 2 characters long")
            .MaximumLength(1000)
            .WithMessage("Description must be at most 1000 characters long");

        RuleFor(x => x.BrandId)
            .NotEmpty()
            .WithName("Marka")
            .WithMessage("Brand cannot be empty")
            .GreaterThan(0)
            .WithMessage("Brand must be greater than 0");

        RuleFor(x => x.Price)
            .NotEmpty()
            .WithName("Fiyat")
            .WithMessage("Price cannot be empty")
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0");

        RuleFor(x => x.Discount)
            .NotEmpty()
            .WithName("İndirim")
            .WithMessage("Discount cannot be empty")
            .GreaterThanOrEqualTo(0)
            .WithMessage("Discount must be greater than or equal to 0")
            .LessThanOrEqualTo(100)
            .WithMessage("Discount must be less than or equal to 100");

        RuleFor(x => x.CategoryIds)
            .NotEmpty()
            .WithName("Kategoriler")
            .WithMessage("Category cannot be empty")
            .Must(x => x.Count > 0)
            .WithMessage("Category must be greater than 0")
            .Must(x => x.Distinct().Count() == x.Count)
            .WithMessage("Category must be distinct")
            .Must(categories => categories.Any());
    }
}
