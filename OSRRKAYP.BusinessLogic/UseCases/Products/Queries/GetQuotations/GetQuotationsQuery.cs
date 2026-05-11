using MediatR;
using OSRRKAYP.BusinessLogic.DTOs;
using OSRRKAYP.BusinessLogic.UseCases.Products.Queries.GetQuotation;

namespace OSRRKAYP.BusinessLogic.UseCases.Products.Queries.GetQuotations
{
    public record GetQuotationsQuery
        : IRequest<List<QuotationDto>>;
}
