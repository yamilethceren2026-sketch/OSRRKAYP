using MediatR;
using Mapster;

using OSRRKAYP.DataAccess.Interfaces;


namespace OSRRKAYP.BusinessLogic.UseCases.Products.Queries.GetQuotation
{
    internal sealed class GetQuotationHandler
        (IEfRepository<Quotation> _repository)
        : IRequestHandler<GetQuotationQuery, QuotationDto>
    {
        public async Task<QuotationDto> Handle
            (GetQuotationQuery query, CancellationToken cancellationToken)
        {
            var quotation = await _repository.FirstOrDefaultAsync
                (new GetQuotationSpec(query.QuotationId), cancellationToken);

            if (quotation is null)
            {
                return new QuotationDto();
            }

            return quotation.Adapt<QuotationDto>();
        }
    }
}
