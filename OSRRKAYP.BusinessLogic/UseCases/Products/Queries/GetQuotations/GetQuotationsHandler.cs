using Mapster;
using MediatR;
using OSRRKAYP.BusinessLogic.DTOs;
using OSRRKAYP.BusinessLogic.UseCases.Products.Queries.GetQuotation;
using OSRRKAYP.BusinessLogic.UseCases.Products.Specifications;
using OSRRKAYP.DataAccess.Interfaces;
using OSRRKAYP.Entities;

namespace OSRRKAYP.BusinessLogic.UseCases.Products.Queries.GetQuotations
{
    internal sealed class GetQuotationsHandler
        : IRequestHandler<GetQuotationsQuery, List<QuotationDto>>
    {
        private readonly IEfRepository<Quotation> _repository;

        public GetQuotationsHandler
            (IEfRepository<Quotation> repository)
        {
            _repository = repository;
        }

        public async Task<List<QuotationDto>> Handle
        (
            GetQuotationsQuery query,
            CancellationToken cancellationToken
        )
        {
            var quotations = await _repository.ListAsync
            (
                new GetQuotationsSpec(),
                cancellationToken
            );

            if (quotations == null || !quotations.Any())
            {
                return new List<QuotationDto>();
            }

            return quotations.Adapt<List<QuotationDto>>();
        }
    }
}