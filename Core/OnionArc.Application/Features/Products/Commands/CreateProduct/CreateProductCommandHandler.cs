using MediatR;
using Microsoft.AspNetCore.Http;
using OnionArc.Application.Bases;
using OnionArc.Application.Features.Products.Rules;
using OnionArc.Application.Interfaces.AutoMapper;
using OnionArc.Application.Interfaces.UnitOfWorks;
using OnionArc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArc.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : BaseHandler, IRequestHandler<CreateProductCommandRequest, Unit>
{
    private readonly ProductRules productRules;

    public CreateProductCommandHandler(ProductRules productRules, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
    }

    public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        IList<Product>products = await unitOfWork.GetReadRepository<Product>().GetAllAsync();

        await productRules.ProductTitleMustNotBeSame(products, request.Title); 

        Product product = new(request.Title, request.Description, request.BrandId, request.Price, request.Discount);

        await unitOfWork.GetWriteRepository<Product>().AddAsync(product);
        if (await unitOfWork.SaveChangesAsync() > 0)
        {
            foreach (var categoryId in request.CategoryIds)
            {
                await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                {
                    ProductId = product.Id,
                    CategoryId = categoryId
                });
            }

            await unitOfWork.SaveChangesAsync();
        }

        return Unit.Value;
    }
}
