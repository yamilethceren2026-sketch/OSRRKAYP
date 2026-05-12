using OSRRKAYP.Entities;

namespace OSRRKAYP.BusinessLogic.UseCases.MusicalInstrumentsTation.CreateMusicalInstruments
{
    internal interface ICreateProductCommand
    {
        Task<long> Handle(Product request, CancellationToken cancellationToken);
    }
}