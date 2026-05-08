using MediatR;
using OSRRKAYP.BusinessLogic.DTOs;

namespace OSRRKAYP.BusinessLogic.UseCases.MusicalInstruments.Queries.GetMusicalInstruments
{
    public record GetMusicalInstrumentsQuery()
        : IRequest<List<MusicalInstrumentResponse>>;
}