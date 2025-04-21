using OnionArc.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArc.Application.Features.Products.Exceptions;

public class ProductTitleMustNotBeSameException : BaseException
{
    public ProductTitleMustNotBeSameException() : base("Aynı isme sahip zaten bir ürün var.") { }
}
