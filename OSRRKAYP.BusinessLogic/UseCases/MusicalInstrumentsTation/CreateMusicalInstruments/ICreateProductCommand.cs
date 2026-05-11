using OSRRKAYP.BusinessLogic.DTOs;

namespace OSRRKAYP.BusinessLogic.UseCases.MusicalInstrumentsTation.CreateMusicalInstruments
{
    internal interface ICreateProductCommand
    {
        Task<long> Handle(CreateHanler CancellationToken, CreateHanler );
    }
}