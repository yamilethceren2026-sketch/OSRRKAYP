using OSRRKAYP.Entities;

namespace OSRRKAYP.BusinessLogic.UseCases.MusicalInstrumentsTation.CreateMusicalInstruments
{
    internal interface ICreateProduct2
    {
        Task<long> Handle(Product request, CancellationToken cancellationToken);
    }
}