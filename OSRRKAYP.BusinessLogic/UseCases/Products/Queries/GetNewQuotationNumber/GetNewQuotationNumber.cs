using MediatR;

namespace OSRRKAYP.BusinessLogic.UseCases.Products.Queries.GetNewQuotationNumber
{
    public record GetNewQuotationNumberQuery : IRequest<long>;
}
