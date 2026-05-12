using MediatR;
using Mapster;
using OSRRKAYP.DataAccess.Interfaces;
using OSRRKAYP.BusinessLogic.DTOs;
// Asegúrate de incluir el namespace donde definiste 'Quotation' y 'GetQuotationSpec'
using OSRRKAYP.BusinessLogic.UseCases.Products.Queries.GetQuotation;

namespace OSRRKAYP.BusinessLogic.UseCases.Products.Queries.GetQuotation
{
    internal sealed class GetQuotationHandler
        (IEfRepository<Quotation> _repository) // Constructor primario
        : IRequestHandler<GetQuotationQuery, QuotationDto>
    {
        public async Task<QuotationDto> Handle
            (GetQuotationQuery query, CancellationToken cancellationToken)
        {
            // Aquí usamos la especificación para filtrar por ID
            var quotation = await _repository.FirstOrDefaultAsync
                (new GetQuotationSpec(query.QuotationId), cancellationToken);

            if (quotation is null)
            {
                // Podrías lanzar una excepción o devolver un DTO vacío/null
                return new QuotationDto();
            }

            // Mapster hace la conversión mágica de la Entidad al DTO
            return quotation.Adapt<QuotationDto>();
        }
    }
}