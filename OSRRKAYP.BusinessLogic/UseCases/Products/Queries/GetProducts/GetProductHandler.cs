using Mapster;
using MediatR;
using OSRRKAYP.BusinessLogic.DTOs;
using OSRRKAYP.DataAccess.Interfaces;
using OSRRKAYP.Entities;

namespace OSRRKAYP.BusinessLogic.UseCases.Products.Queries.GetProducts
{
    internal sealed class GetProductHandler(
        IEfRepository<Product> _repository
    ) : IRequestHandler<GetProductQuery, BrandResponse>
    {
        public async Task<BrandResponse> Handle(
            GetProductQuery query,
            CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(
                query.ProductId,
                cancellationToken);

            if (product is null)
            {
                return new BrandResponse();
            }

            return product.Adapt<BrandResponse>();
        }
    }
}
