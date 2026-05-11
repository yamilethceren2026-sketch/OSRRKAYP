using MediatR;
using OSRRKAYP.BusinessLogic.DTOs;

namespace OSRRKAYP.BusinessLogic.UseCases.MusicalInstruments.CreateMusicalInstruments
{
    public record CreateMusicalInstrumentsCommand(CreateManufacturerDto Request) : IRequest<int>;
}
