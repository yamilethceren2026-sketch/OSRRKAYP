using MediatR;
using OSRRKAYP.BusinessLogic.DTOs;

namespace OSRRKAYP.BusinessLogic.UseCases.Products.Queries.GetProducts
{
    public sealed record GetProductQuery(
        int ProductId
    ) : IRequest<BrandResponse>;
}