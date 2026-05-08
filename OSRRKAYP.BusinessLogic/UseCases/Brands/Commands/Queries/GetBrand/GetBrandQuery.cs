using MediatR;
using OSRRKAYP.BusinessLogic.DTOs;

namespace OSRRKAYP.BusinessLogic.UseCases.Brands.Queries.GetBrand;

public record GetBrandQuery(int brandId) : IRequest<BrandResponse>;