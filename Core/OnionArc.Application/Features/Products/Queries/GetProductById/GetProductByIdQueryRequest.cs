using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArc.Application.Features.Products.Queries.GetProductById;

public class GetProductByIdQueryRequest : IRequest<GetProductByIdQueryResponse>
{
    public int Id { get; set; }

    public GetProductByIdQueryRequest()
    {
        
    }

    public GetProductByIdQueryRequest(int ıd)
    {
        Id = ıd;
    }
}
