using MediatR;
using OutcomeOf;
using Product.Application.Common.DataReadingModels.ProductsData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Queries.Products.GetProductData
{
    public record GetProductDataQuery(Guid ProductId):IRequest<OutcomeOf<ProductDetailsReadModel>>;
}
