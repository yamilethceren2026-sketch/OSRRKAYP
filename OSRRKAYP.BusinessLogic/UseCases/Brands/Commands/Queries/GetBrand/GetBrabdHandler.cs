using Mapster;
using MediatR;

using OSRRKAYP.BusinessLogic.DTOs;
using OSRRKAYP.DataAccess.Interfaces;
using OSRRKAYP.Entities;

namespace OSRRKAYP.BusinessLogic.UseCases.Brands.Queries.GetBrand;

internal sealed class GetBrandHandler(IEfRepository<IEfRepository<Manufacturer>> _repository)
    : IRequestHandler<GetBrandQuery, BrandResponse>
{
    public async Task<BrandResponse> Handle(GetBrandQuery query, CancellationToken cancellationToken)
    {
        var brand = await _repository.GetByIdAsync(query.brandId, cancellationToken);

        if (brand is null)
        {
            return new BrandResponse();
        }

        return brand.Adapt<BrandResponse>();
    }
}