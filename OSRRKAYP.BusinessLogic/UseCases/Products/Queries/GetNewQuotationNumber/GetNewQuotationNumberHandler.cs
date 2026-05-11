using MediatR;
using OSRRKAYP.BusinessLogic.UseCases.Products.Queries.GetQuotation;
using OSRRKAYP.DataAccess.Interfaces;
using OSRRKAYP.Entities;

namespace OSRRKAYP.BusinessLogic.UseCases.Products.Queries.GetNewQuotationNumber
{
    internal sealed class GetNewQuotationNumberHandler
        (IEfRepository<Quotation> _repository)
        : IRequestHandler<GetNewQuotationNumberQuery, long>
    {
        public async Task<long> Handle
            (GetNewQuotationNumberQuery query, CancellationToken cancellationToken)
        {
            var quotations = await _repository.ListAsync(cancellationToken);

            var lastQuotationNumber = quotations
                .OrderByDescending(q => q.QuotationNumber)
                .Select(q => q.QuotationNumber)
                .FirstOrDefault();

            return lastQuotationNumber + 1;
        }
    }
}
