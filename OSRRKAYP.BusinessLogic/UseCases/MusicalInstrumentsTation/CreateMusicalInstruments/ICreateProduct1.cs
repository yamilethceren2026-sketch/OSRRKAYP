using OSRRKAYP.BusinessLogic.DTOs;

namespace OSRRKAYP.BusinessLogic.UseCases.MusicalInstrumentsTation.CreateMusicalInstruments
{
    internal interface ICreateProduct1
    {
        Task<long> Handle(Product request, CancellationToken cancellationToken);
        Task<long> Handle(Product CancellationToken, Product );
    }
}