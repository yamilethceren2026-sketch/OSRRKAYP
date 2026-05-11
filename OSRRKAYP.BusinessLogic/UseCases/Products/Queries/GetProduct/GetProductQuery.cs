using OSRRKAYP.BusinessLogic.DTOs;
using MediatR;

namespace OSRRKAYP.BusinessLogic.UseCases.Products.Queries.GetProduct;

public record GetProductQuery(long ProductId) : IRequest<BrandResponse>;
