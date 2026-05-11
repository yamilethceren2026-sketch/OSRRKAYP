using MediatR;
using OSRRKAYP.BusinessLogic.DTOs;

namespace OSRRKAYP.BusinessLogic.UseCases.Products.Queries.GetQuotation
{
    public record GetQuotationQuery(long QuotationId)
        : IRequest<QuotationDto>;
}
