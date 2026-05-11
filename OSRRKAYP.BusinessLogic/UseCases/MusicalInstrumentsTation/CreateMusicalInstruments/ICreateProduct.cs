using OSRRKAYP.BusinessLogic.DTOs;

namespace OSRRKAYP.BusinessLogic.UseCases.MusicalInstrumentsTation.CreateMusicalInstruments
{
    internal interface ICreateProduct
    {
        Task<long> Handle(CreateHanler request, CancellationToken cancellationToken);
        Task<long> Handle(CreateHanler CancellationToken, CreateHanler );
    }
}