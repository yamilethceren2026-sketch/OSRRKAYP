using Mapster;
using MediatR;
using OSRRKAYP.BusinessLogic.DTOs;
using OSRRKAYP.DataAccess.Interfaces;
using OSRRKAYP.Entities;

namespace OSRRKAYP.BusinessLogic.UseCases.MusicalInstruments.Queries.GetMusicalInstruments
{
    internal sealed class GetMusicalInstrumentsHandler
        (IEfRepository<MusicalInstrument> _repository)
        : IRequestHandler<GetMusicalInstrumentsQuery, List<MusicalInstrumentResponse>>
    {
        public async Task<List<MusicalInstrumentResponse>> Handle
            (GetMusicalInstrumentsQuery request, CancellationToken cancellationToken)
        {
            var instruments = await _repository.ListAsync(cancellationToken);

            return instruments.Adapt<List<MusicalInstrumentResponse>>();
        }
    }
}