using MediatR;
using Microsoft.EntityFrameworkCore;
using OnionArc.Application.DTOs;
using OnionArc.Application.Interfaces.AutoMapper;
using OnionArc.Application.Interfaces.UnitOfWorks;
using OnionArc.Domain.Entities;

namespace OnionArc.Application.Features.Products.Queries.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, GetProductByIdQueryResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetProductByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var product = await unitOfWork.GetReadRepository<Product>().GetAsync(p => p.Id == request.Id, include: x => x.Include(b => b.Brand));

        var brand = mapper.Map<BrandDto, Brand>(new Brand());

        var map = mapper.Map<GetProductByIdQueryResponse, Product>(product);
        map.Price -= (map.Price * map.Discount / 100);

        return map;
    }
}
